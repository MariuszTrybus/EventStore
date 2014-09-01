using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using EventStore.Common.Utils;
using EventStore.Core.Authentication;
using EventStore.Core.Data;
using EventStore.Core.Services.Monitoring;

namespace EventStore.Core.Cluster.Settings
{
    public class ClusterVNodeSettings
    {
        public readonly VNodeInfo NodeInfo;
        public readonly string[] HttpPrefixes;
        public readonly bool EnableTrustedAuth;
        public readonly X509Certificate2 Certificate;
        public readonly int WorkerThreads;

        public readonly bool DiscoverViaDns;
        public readonly string ClusterDns;
        public readonly IPEndPoint[] GossipSeeds;

        public readonly TimeSpan MinFlushDelay;

        public readonly int ClusterNodeCount;
        public readonly int PrepareAckCount;
        public readonly int CommitAckCount;
        public readonly TimeSpan PrepareTimeout;
        public readonly TimeSpan CommitTimeout;

        public readonly int NodePriority;

        public readonly bool UseSsl;
        public readonly string SslTargetHost;
        public readonly bool SslValidateServer;

        public readonly TimeSpan StatsPeriod;
        public readonly StatsStorage StatsStorage;

        public readonly IAuthenticationProviderFactory AuthenticationProviderFactory;
        public readonly bool DisableScavengeMerging;
        public bool AdminOnPublic;
        public bool StatsOnPublic;
        public bool GossipOnPublic;
        public readonly TimeSpan GossipInterval;
        public readonly TimeSpan GossipAllowedTimeDifference;
        public readonly TimeSpan GossipTimeout;
        public readonly TimeSpan TcpTimeout;
        public readonly bool VerifyDbHashes;
        public readonly int MaxMemtableSize;

        public ClusterVNodeSettings(Guid instanceId, int debugIndex,
                                    IPEndPoint internalTcpEndPoint,
                                    IPEndPoint internalSecureTcpEndPoint,
                                    IPEndPoint externalTcpEndPoint,
                                    IPEndPoint externalSecureTcpEndPoint,
                                    IPEndPoint internalHttpEndPoint,
                                    IPEndPoint externalHttpEndPoint,
                                    string[] httpPrefixes,
                                    bool enableTrustedAuth,
                                    X509Certificate2 certificate,
                                    int workerThreads,
                                    bool discoverViaDns,
                                    string clusterDns,
                                    IPEndPoint[] gossipSeeds,
                                    TimeSpan minFlushDelay,
                                    int clusterNodeCount,
                                    int prepareAckCount,
                                    int commitAckCount,
                                    TimeSpan prepareTimeout,
                                    TimeSpan commitTimeout,
                                    bool useSsl,
                                    string sslTargetHost,
                                    bool sslValidateServer,
                                    TimeSpan statsPeriod,
                                    StatsStorage statsStorage,
                                    int nodePriority,
                                    IAuthenticationProviderFactory authenticationProviderFactory,
                                    bool disableScavengeMerging,
                                    bool adminOnPublic,
                                    bool statsOnPublic,
                                    bool gossipOnPublic,
                                    TimeSpan gossipInterval,
                                    TimeSpan gossipAllowedTimeDifference,
                                    TimeSpan gossipTimeout,
                                    TimeSpan tcpTimeout, bool verifyDbHashes, int maxMemtableSize)
        {
            Ensure.NotEmptyGuid(instanceId, "instanceId");
            Ensure.NotNull(internalTcpEndPoint, "internalTcpEndPoint");
            Ensure.NotNull(externalTcpEndPoint, "externalTcpEndPoint");
            Ensure.NotNull(internalHttpEndPoint, "internalHttpEndPoint");
            Ensure.NotNull(externalHttpEndPoint, "externalHttpEndPoint");
            Ensure.NotNull(httpPrefixes, "httpPrefixes");
            if (internalSecureTcpEndPoint != null || externalSecureTcpEndPoint != null)
                Ensure.NotNull(certificate, "certificate");
            Ensure.Positive(workerThreads, "workerThreads");
            Ensure.NotNull(clusterDns, "clusterDns");
            Ensure.NotNull(gossipSeeds, "gossipSeeds");
            Ensure.Positive(clusterNodeCount, "clusterNodeCount");
            Ensure.Positive(prepareAckCount, "prepareAckCount");
            Ensure.Positive(commitAckCount, "commitAckCount");

            if (discoverViaDns && string.IsNullOrWhiteSpace(clusterDns))
                throw new ArgumentException("Either DNS Discovery must be disabled (and seeds specified), or a cluster DNS name must be provided.");

            if (useSsl)
                Ensure.NotNull(sslTargetHost, "sslTargetHost");

            NodeInfo = new VNodeInfo(instanceId, debugIndex,
                                     internalTcpEndPoint, internalSecureTcpEndPoint,
                                     externalTcpEndPoint, externalSecureTcpEndPoint,
                                     internalHttpEndPoint, externalHttpEndPoint);
            HttpPrefixes = httpPrefixes;
            EnableTrustedAuth = enableTrustedAuth;
            Certificate = certificate;
            WorkerThreads = workerThreads;

            DiscoverViaDns = discoverViaDns;
            ClusterDns = clusterDns;
            GossipSeeds = gossipSeeds;

            ClusterNodeCount = clusterNodeCount;
            MinFlushDelay = minFlushDelay;
            PrepareAckCount = prepareAckCount;
            CommitAckCount = commitAckCount;
            PrepareTimeout = prepareTimeout;
            CommitTimeout = commitTimeout;

            UseSsl = useSsl;
            SslTargetHost = sslTargetHost;
            SslValidateServer = sslValidateServer;

            StatsPeriod = statsPeriod;
            StatsStorage = statsStorage;

            AuthenticationProviderFactory = authenticationProviderFactory;

            NodePriority = nodePriority;
            DisableScavengeMerging = disableScavengeMerging;
            AdminOnPublic = adminOnPublic;
            StatsOnPublic = statsOnPublic;
            GossipOnPublic = gossipOnPublic;
            GossipInterval = gossipInterval;
            GossipAllowedTimeDifference = gossipAllowedTimeDifference;
            GossipTimeout = gossipTimeout;
            TcpTimeout = tcpTimeout;
            VerifyDbHashes = verifyDbHashes;
            MaxMemtableSize = maxMemtableSize;
        }
    }
}
