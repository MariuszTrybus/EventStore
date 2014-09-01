using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using EventStore.Core.Authentication;
using EventStore.Core.Services.Monitoring;

namespace EventStore.Core.Cluster.Settings
{
    public class ClusterVNodeSettingsBuilder
    {
        private IPEndPoint _internalTcp;
        private IPEndPoint _internalSecureTcp;
        private IPEndPoint _externalTcp;
        private IPEndPoint _externalSecureTcp;
        private IPEndPoint _internalHttp;
        private IPEndPoint _externalHttp;

        private string[] _httpPrefixes;
        private bool _enableTrustedAuth;
        private X509Certificate2 _certificate;
        private int _workerThreads;

        private bool _discoverViaDns;
        private string _clusterDns;
        private IPEndPoint[] _gossipSeeds;

        private TimeSpan _minFlushDelay;

        private int _clusterNodeCount;
        private int _prepareAckCount;
        private int _commitAckCount;
        private TimeSpan _prepareTimeout;
        private TimeSpan _commitTimeout;

        private int _nodePriority;

        private bool _useSsl;
        private string _sslTargetHost;
        private bool _sslValidateServer;

        private TimeSpan _statsPeriod;
        private StatsStorage _statsStorage;

        private IAuthenticationProviderFactory _authenticationProviderFactory;
        private bool _disableScavengeMerging;
        private bool _adminOnPublic;
        private bool _statsOnPublic;
        private bool _gossipOnPublic;
        private TimeSpan _gossipInterval;
        private TimeSpan _gossipAllowedTimeDifference;
        private TimeSpan _gossipTimeout;
        private TimeSpan _tcpTimeout;
        private bool _verifyDbHashes;
        private int _maxMemtableSize;


        private ClusterVNodeSettingsBuilder()
        {
            _statsStorage = StatsStorage.None;
            _sslTargetHost = "";
            _sslValidateServer = false;
            _minFlushDelay = TimeSpan.FromMilliseconds(2);
            _gossipInterval = TimeSpan.FromSeconds(1);
            _gossipAllowedTimeDifference = TimeSpan.FromSeconds(30);
            _gossipTimeout = TimeSpan.FromSeconds(1);
            _tcpTimeout = TimeSpan.FromSeconds(5);
            _statsPeriod = TimeSpan.FromSeconds(15);
            _prepareTimeout = TimeSpan.FromSeconds(2);
            _commitTimeout = TimeSpan.FromSeconds(2);
            _gossipOnPublic = true;
            _adminOnPublic = true;
            _statsOnPublic = true;
            _disableScavengeMerging = false;
            _nodePriority = 1;
            _enableTrustedAuth = false;
            _authenticationProviderFactory = new InternalAuthenticationProviderFactory();
        }

        /// <summary>
        /// Returns a builder set to construct options for a single node instance
        /// </summary>
        /// <returns></returns>
        public static ClusterVNodeSettingsBuilder AsSingleNode()
        {
            var ret = new ClusterVNodeSettingsBuilder
            {
                _clusterNodeCount = 1,
                _prepareAckCount = 1,
                _commitAckCount = 1
            };
            return ret;
        }

        /// <summary>
        /// Returns a builder set to construct options for a cluster node instance with a cluster size 
        /// </summary>
        /// <returns></returns>
        public static ClusterVNodeSettingsBuilder AsClusterMember(int clusterSize)
        {
            int quorumSize = clusterSize/2;
            var ret = new ClusterVNodeSettingsBuilder
            {
                _clusterNodeCount = clusterSize,
                _prepareAckCount = quorumSize,
                _commitAckCount = quorumSize
            };
            return ret;
        }

        /// <summary>
        /// Sets the default endpoints on localhost (1113 tcp, 2113 http)
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder OnDefaultEndpoints()
        {
            _externalHttp = new IPEndPoint(IPAddress.Loopback, 2113);
            _externalTcp = new IPEndPoint(IPAddress.Loopback, 1113);
            return this;
        }

        /// <summary>
        /// Sets the internal http endpoint to the specified value
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithInternalHttpOn(IPEndPoint endpoint)
        {
            _internalHttp = endpoint;
            return this;
        }

        /// <summary>
        /// Sets the external http endpoint to the specified value
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithExternalHttpOn(IPEndPoint endpoint)
        {
            _externalHttp = endpoint;
            return this;
        }

        /// <summary>
        /// Sets the internal tcp endpoint to the specified value
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithInternalTcpOn(IPEndPoint endpoint)
        {
            _internalTcp = endpoint;
            return this;
        }

        /// <summary>
        /// Sets the internal tcp endpoint to the specified value
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithInternalSecureTcpOn(IPEndPoint endpoint)
        {
            _internalSecureTcp = endpoint;
            return this;
        }

        /// <summary>
        /// Sets the external tcp endpoint to the specified value
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithExternalTcpOn(IPEndPoint endpoint)
        {
            _externalTcp = endpoint;
            return this;
        }

        /// <summary>
        /// Sets the external tcp endpoint to the specified value
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithExternalSecureTcpOn(IPEndPoint endpoint)
        {
            _externalSecureTcp = endpoint;
            return this;
        }


        /// <summary>
        /// Sets that SSL should be used on connections
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder EnableSSL()
        {
            _useSsl = true;
            return this;
        }

        /// <summary>
        /// Sets the certificate to be used with SSL
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithCertificate(X509Certificate2 certificate)
        {
            _certificate = certificate;
            return this;
        }

        /// <summary>
        /// Sets the gossip seeds this node should talk to
        /// </summary>
        /// <param name="endpoints">The gossip seeds this node should try to talk to</param>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithGossipSeeds(params IPEndPoint[] endpoints)
        {
            _gossipSeeds = endpoints;
            _discoverViaDns = false;
            return this;
        }

        /// <summary>
        /// Sets the maximum size a memtable is allowed to reach (in count) before being moved to be a ptable
        /// </summary>
        /// <param name="size">The maximum count</param>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder MaximumMemoryTableSizeOf(int size)
        {
            _maxMemtableSize = size;
            return this;
        }

        /// <summary>
        /// Marks that the existing database files should not be checked for checksums on startup.
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder DoNotVerifyDBHashes()
        {
            _verifyDbHashes = false;
            return this;
        }

        /// <summary>
        /// Disables gossip on the public (client) interface
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder NoGossipOnPublicInterface()
        {
            _gossipOnPublic = false;
            return this;
        }

        /// <summary>
        /// Disables the admin interface on the public (client) interface
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder NoAdminOnPublicInterface()
        {
            _adminOnPublic = false;
            return this;
        }

        /// <summary>
        /// Disables statistics screens on the public (client) interface
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder NoStatsOnPublicInterface()
        {
            _adminOnPublic = false;
            return this;
        }

        /// <summary>
        /// Marks that the existing database files should be checked for checksums on startup.
        /// </summary>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder VerifyDBHashes()
        {
            _verifyDbHashes = true;
            return this;
        }

        /// <summary>
        /// Sets the dns name used for the discovery of other cluster nodes
        /// </summary>
        /// <param name="name">The dns name the node should use to discover gossip partners</param>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithClusterDnsName(string name)
        {
            _clusterDns = name;
            _discoverViaDns = true;
            return this;
        }

        /// <summary>
        /// Sets the number of worker threads to use in shared threadpool
        /// </summary>
        /// <param name="count">The number of worker threads</param>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder WithWorkerThreads(int count)
        {
            _workerThreads = count;
            return this;
        }

        /// <summary>
        /// Adds a http prefix for the external http endpoint
        /// </summary>
        /// <param name="prefix">The prefix to add</param>
        /// <returns>A <see cref="ClusterVNodeSettingsBuilder"/> with the options set</returns>
        public ClusterVNodeSettingsBuilder AddHttpPrefix(string prefix)
        {
            var prefixes = new List<string>();
            if(_httpPrefixes != null) prefixes.AddRange(_httpPrefixes);
            prefixes.Add(prefix);
            _httpPrefixes = prefixes.ToArray();
            return this;
        }

        public static implicit operator ClusterVNodeSettings(ClusterVNodeSettingsBuilder builder)
        {
            return new ClusterVNodeSettings(Guid.NewGuid(),
                0,
                builder._internalTcp,
                builder._internalSecureTcp,
                builder._externalTcp,
                builder._externalSecureTcp,
                builder._internalHttp,
                builder._externalHttp,
                builder._httpPrefixes,
                builder._enableTrustedAuth,
                builder._certificate,
                builder._workerThreads,
                builder._discoverViaDns,
                builder._clusterDns,
                builder._gossipSeeds,
                builder._minFlushDelay,
                builder._clusterNodeCount,
                builder._prepareAckCount,
                builder._commitAckCount,
                builder._prepareTimeout,
                builder._commitTimeout,
                builder._useSsl,
                builder._sslTargetHost,
                builder._sslValidateServer,
                builder._statsPeriod,
                builder._statsStorage,
                builder._nodePriority,
                builder._authenticationProviderFactory,
                builder._disableScavengeMerging,
                builder._adminOnPublic,
                builder._statsOnPublic,
                builder._gossipOnPublic,
                builder._gossipInterval,
                builder._gossipAllowedTimeDifference,
                builder._gossipTimeout,
                builder._tcpTimeout,
                builder._verifyDbHashes,
                builder._maxMemtableSize);
        }
    }
}