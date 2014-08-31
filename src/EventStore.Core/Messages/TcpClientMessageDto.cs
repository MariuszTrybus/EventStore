//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ClientMessageDtos.proto
using System;
using System.ComponentModel;
using System.Collections.Generic;
using ProtoBuf;

namespace EventStore.Core.Messages
{
  public static partial class TcpClientMessageDto
  {
  [Serializable, ProtoContract(Name=@"NewEvent")]
  public partial class NewEvent
  {
    [ProtoMember(1, IsRequired = true, Name=@"event_id", DataFormat = DataFormat.Default)]
    public readonly byte[] EventId;
  
    [ProtoMember(2, IsRequired = true, Name=@"event_type", DataFormat = DataFormat.Default)]
    public readonly string EventType;
  
    [ProtoMember(3, IsRequired = true, Name=@"data_content_type", DataFormat = DataFormat.TwosComplement)]
    public readonly int DataContentType;
  
    [ProtoMember(4, IsRequired = true, Name=@"metadata_content_type", DataFormat = DataFormat.TwosComplement)]
    public readonly int MetadataContentType;
  
    [ProtoMember(5, IsRequired = true, Name=@"data", DataFormat = DataFormat.Default)]
    public readonly byte[] Data;
  
    [ProtoMember(6, IsRequired = false, Name=@"metadata", DataFormat = DataFormat.Default)]
    public readonly byte[] Metadata;
  
    private NewEvent() {}
  
    public NewEvent(byte[] eventId, string eventType, int dataContentType, int metadataContentType, byte[] data, byte[] metadata)
    {
        EventId = eventId;
        EventType = eventType;
        DataContentType = dataContentType;
        MetadataContentType = metadataContentType;
        Data = data;
        Metadata = metadata;
    }
  }
  
  [Serializable, ProtoContract(Name=@"EventRecord")]
  public partial class EventRecord
  {
    [ProtoMember(1, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(2, IsRequired = true, Name=@"event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int EventNumber;
  
    [ProtoMember(3, IsRequired = true, Name=@"event_id", DataFormat = DataFormat.Default)]
    public readonly byte[] EventId;
  
    [ProtoMember(4, IsRequired = true, Name=@"event_type", DataFormat = DataFormat.Default)]
    public readonly string EventType;
  
    [ProtoMember(5, IsRequired = true, Name=@"data_content_type", DataFormat = DataFormat.TwosComplement)]
    public readonly int DataContentType;
  
    [ProtoMember(6, IsRequired = true, Name=@"metadata_content_type", DataFormat = DataFormat.TwosComplement)]
    public readonly int MetadataContentType;
  
    [ProtoMember(7, IsRequired = true, Name=@"data", DataFormat = DataFormat.Default)]
    public readonly byte[] Data;
  
    [ProtoMember(8, IsRequired = false, Name=@"metadata", DataFormat = DataFormat.Default)]
    public readonly byte[] Metadata;
  
    [ProtoMember(9, IsRequired = false, Name=@"created", DataFormat = DataFormat.TwosComplement)]
    public readonly long? Created;
  
    [ProtoMember(10, IsRequired = false, Name=@"created_epoch", DataFormat = DataFormat.TwosComplement)]
    public readonly long? CreatedEpoch;
  
    private EventRecord() {}
  
    public EventRecord(string eventStreamId, int eventNumber, byte[] eventId, string eventType, int dataContentType, int metadataContentType, byte[] data, byte[] metadata, long? created, long? createdEpoch)
    {
        EventStreamId = eventStreamId;
        EventNumber = eventNumber;
        EventId = eventId;
        EventType = eventType;
        DataContentType = dataContentType;
        MetadataContentType = metadataContentType;
        Data = data;
        Metadata = metadata;
        Created = created;
        CreatedEpoch = createdEpoch;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ResolvedIndexedEvent")]
  public partial class ResolvedIndexedEvent
  {
    [ProtoMember(1, IsRequired = true, Name=@"event", DataFormat = DataFormat.Default)]
    public readonly EventRecord Event;
  
    [ProtoMember(2, IsRequired = false, Name=@"link", DataFormat = DataFormat.Default)]
    public readonly EventRecord Link;
  
    private ResolvedIndexedEvent() {}
  
    public ResolvedIndexedEvent(EventRecord @event, EventRecord link)
    {
        Event = @event;
        Link = link;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ResolvedEvent")]
  public partial class ResolvedEvent
  {
    [ProtoMember(1, IsRequired = true, Name=@"event", DataFormat = DataFormat.Default)]
    public readonly EventRecord Event;
  
    [ProtoMember(2, IsRequired = false, Name=@"link", DataFormat = DataFormat.Default)]
    public readonly EventRecord Link;
  
    [ProtoMember(3, IsRequired = true, Name=@"commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long CommitPosition;
  
    [ProtoMember(4, IsRequired = true, Name=@"prepare_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long PreparePosition;
  
    private ResolvedEvent() {}
  
    public ResolvedEvent(EventRecord @event, EventRecord link, long commitPosition, long preparePosition)
    {
        Event = @event;
        Link = link;
        CommitPosition = commitPosition;
        PreparePosition = preparePosition;
    }
  }
  
  [Serializable, ProtoContract(Name=@"WriteEvents")]
  public partial class WriteEvents
  {
    [ProtoMember(1, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(2, IsRequired = true, Name=@"expected_version", DataFormat = DataFormat.TwosComplement)]
    public readonly int ExpectedVersion;
  
    [ProtoMember(3, Name=@"events", DataFormat = DataFormat.Default)]
    public readonly NewEvent[] Events;
  
    [ProtoMember(4, IsRequired = true, Name=@"require_master", DataFormat = DataFormat.Default)]
    public readonly bool RequireMaster;
  
    private WriteEvents() {}
  
    public WriteEvents(string eventStreamId, int expectedVersion, NewEvent[] events, bool requireMaster)
    {
        EventStreamId = eventStreamId;
        ExpectedVersion = expectedVersion;
        Events = events;
        RequireMaster = requireMaster;
    }
  }
  
  [Serializable, ProtoContract(Name=@"WriteEventsCompleted")]
  public partial class WriteEventsCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly OperationResult Result;
  
    [ProtoMember(2, IsRequired = false, Name=@"message", DataFormat = DataFormat.Default)]
    public readonly string Message;
  
    [ProtoMember(3, IsRequired = true, Name=@"first_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int FirstEventNumber;
  
    [ProtoMember(4, IsRequired = true, Name=@"last_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int LastEventNumber;
  
    [ProtoMember(5, IsRequired = false, Name=@"prepare_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long? PreparePosition;
  
    [ProtoMember(6, IsRequired = false, Name=@"commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long? CommitPosition;
  
    private WriteEventsCompleted() {}
  
    public WriteEventsCompleted(OperationResult result, string message, int firstEventNumber, int lastEventNumber, long? preparePosition, long? commitPosition)
    {
        Result = result;
        Message = message;
        FirstEventNumber = firstEventNumber;
        LastEventNumber = lastEventNumber;
        PreparePosition = preparePosition;
        CommitPosition = commitPosition;
    }
  }
  
  [Serializable, ProtoContract(Name=@"DeleteStream")]
  public partial class DeleteStream
  {
    [ProtoMember(1, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(2, IsRequired = true, Name=@"expected_version", DataFormat = DataFormat.TwosComplement)]
    public readonly int ExpectedVersion;
  
    [ProtoMember(3, IsRequired = true, Name=@"require_master", DataFormat = DataFormat.Default)]
    public readonly bool RequireMaster;
  
    [ProtoMember(4, IsRequired = false, Name=@"hard_delete", DataFormat = DataFormat.Default)]
    public readonly bool? HardDelete;
  
    private DeleteStream() {}
  
    public DeleteStream(string eventStreamId, int expectedVersion, bool requireMaster, bool? hardDelete)
    {
        EventStreamId = eventStreamId;
        ExpectedVersion = expectedVersion;
        RequireMaster = requireMaster;
        HardDelete = hardDelete;
    }
  }
  
  [Serializable, ProtoContract(Name=@"DeleteStreamCompleted")]
  public partial class DeleteStreamCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly OperationResult Result;
  
    [ProtoMember(2, IsRequired = false, Name=@"message", DataFormat = DataFormat.Default)]
    public readonly string Message;
  
    [ProtoMember(3, IsRequired = false, Name=@"prepare_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long? PreparePosition;
  
    [ProtoMember(4, IsRequired = false, Name=@"commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long? CommitPosition;
  
    private DeleteStreamCompleted() {}
  
    public DeleteStreamCompleted(OperationResult result, string message, long? preparePosition, long? commitPosition)
    {
        Result = result;
        Message = message;
        PreparePosition = preparePosition;
        CommitPosition = commitPosition;
    }
  }
  
  [Serializable, ProtoContract(Name=@"TransactionStart")]
  public partial class TransactionStart
  {
    [ProtoMember(1, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(2, IsRequired = true, Name=@"expected_version", DataFormat = DataFormat.TwosComplement)]
    public readonly int ExpectedVersion;
  
    [ProtoMember(3, IsRequired = true, Name=@"require_master", DataFormat = DataFormat.Default)]
    public readonly bool RequireMaster;
  
    private TransactionStart() {}
  
    public TransactionStart(string eventStreamId, int expectedVersion, bool requireMaster)
    {
        EventStreamId = eventStreamId;
        ExpectedVersion = expectedVersion;
        RequireMaster = requireMaster;
    }
  }
  
  [Serializable, ProtoContract(Name=@"TransactionStartCompleted")]
  public partial class TransactionStartCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"transaction_id", DataFormat = DataFormat.TwosComplement)]
    public readonly long TransactionId;
  
    [ProtoMember(2, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly OperationResult Result;
  
    [ProtoMember(3, IsRequired = false, Name=@"message", DataFormat = DataFormat.Default)]
    public readonly string Message;
  
    private TransactionStartCompleted() {}
  
    public TransactionStartCompleted(long transactionId, OperationResult result, string message)
    {
        TransactionId = transactionId;
        Result = result;
        Message = message;
    }
  }
  
  [Serializable, ProtoContract(Name=@"TransactionWrite")]
  public partial class TransactionWrite
  {
    [ProtoMember(1, IsRequired = true, Name=@"transaction_id", DataFormat = DataFormat.TwosComplement)]
    public readonly long TransactionId;
  
    [ProtoMember(2, Name=@"events", DataFormat = DataFormat.Default)]
    public readonly NewEvent[] Events;
  
    [ProtoMember(3, IsRequired = true, Name=@"require_master", DataFormat = DataFormat.Default)]
    public readonly bool RequireMaster;
  
    private TransactionWrite() {}
  
    public TransactionWrite(long transactionId, NewEvent[] events, bool requireMaster)
    {
        TransactionId = transactionId;
        Events = events;
        RequireMaster = requireMaster;
    }
  }
  
  [Serializable, ProtoContract(Name=@"TransactionWriteCompleted")]
  public partial class TransactionWriteCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"transaction_id", DataFormat = DataFormat.TwosComplement)]
    public readonly long TransactionId;
  
    [ProtoMember(2, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly OperationResult Result;
  
    [ProtoMember(3, IsRequired = false, Name=@"message", DataFormat = DataFormat.Default)]
    public readonly string Message;
  
    private TransactionWriteCompleted() {}
  
    public TransactionWriteCompleted(long transactionId, OperationResult result, string message)
    {
        TransactionId = transactionId;
        Result = result;
        Message = message;
    }
  }
  
  [Serializable, ProtoContract(Name=@"TransactionCommit")]
  public partial class TransactionCommit
  {
    [ProtoMember(1, IsRequired = true, Name=@"transaction_id", DataFormat = DataFormat.TwosComplement)]
    public readonly long TransactionId;
  
    [ProtoMember(2, IsRequired = true, Name=@"require_master", DataFormat = DataFormat.Default)]
    public readonly bool RequireMaster;
  
    private TransactionCommit() {}
  
    public TransactionCommit(long transactionId, bool requireMaster)
    {
        TransactionId = transactionId;
        RequireMaster = requireMaster;
    }
  }
  
  [Serializable, ProtoContract(Name=@"TransactionCommitCompleted")]
  public partial class TransactionCommitCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"transaction_id", DataFormat = DataFormat.TwosComplement)]
    public readonly long TransactionId;
  
    [ProtoMember(2, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly OperationResult Result;
  
    [ProtoMember(3, IsRequired = false, Name=@"message", DataFormat = DataFormat.Default)]
    public readonly string Message;
  
    [ProtoMember(4, IsRequired = true, Name=@"first_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int FirstEventNumber;
  
    [ProtoMember(5, IsRequired = true, Name=@"last_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int LastEventNumber;
  
    [ProtoMember(6, IsRequired = false, Name=@"prepare_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long? PreparePosition;
  
    [ProtoMember(7, IsRequired = false, Name=@"commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long? CommitPosition;
  
    private TransactionCommitCompleted() {}
  
    public TransactionCommitCompleted(long transactionId, OperationResult result, string message, int firstEventNumber, int lastEventNumber, long? preparePosition, long? commitPosition)
    {
        TransactionId = transactionId;
        Result = result;
        Message = message;
        FirstEventNumber = firstEventNumber;
        LastEventNumber = lastEventNumber;
        PreparePosition = preparePosition;
        CommitPosition = commitPosition;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ReadEvent")]
  public partial class ReadEvent
  {
    [ProtoMember(1, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(2, IsRequired = true, Name=@"event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int EventNumber;
  
    [ProtoMember(3, IsRequired = true, Name=@"resolve_link_tos", DataFormat = DataFormat.Default)]
    public readonly bool ResolveLinkTos;
  
    [ProtoMember(4, IsRequired = true, Name=@"require_master", DataFormat = DataFormat.Default)]
    public readonly bool RequireMaster;
  
    private ReadEvent() {}
  
    public ReadEvent(string eventStreamId, int eventNumber, bool resolveLinkTos, bool requireMaster)
    {
        EventStreamId = eventStreamId;
        EventNumber = eventNumber;
        ResolveLinkTos = resolveLinkTos;
        RequireMaster = requireMaster;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ReadEventCompleted")]
  public partial class ReadEventCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly ReadEventCompleted.ReadEventResult Result;
  
    [ProtoMember(2, IsRequired = true, Name=@"event", DataFormat = DataFormat.Default)]
    public readonly ResolvedIndexedEvent Event;
  
    [ProtoMember(3, IsRequired = false, Name=@"error", DataFormat = DataFormat.Default)]
    public readonly string Error;
  
    [ProtoContract(Name=@"ReadEventResult")]
    public enum ReadEventResult
    {
            
      [ProtoEnum(Name=@"Success", Value=0)]
      Success = 0,
            
      [ProtoEnum(Name=@"NotFound", Value=1)]
      NotFound = 1,
            
      [ProtoEnum(Name=@"NoStream", Value=2)]
      NoStream = 2,
            
      [ProtoEnum(Name=@"StreamDeleted", Value=3)]
      StreamDeleted = 3,
            
      [ProtoEnum(Name=@"Error", Value=4)]
      Error = 4,
            
      [ProtoEnum(Name=@"AccessDenied", Value=5)]
      AccessDenied = 5
    }
  
    private ReadEventCompleted() {}
  
    public ReadEventCompleted(ReadEventCompleted.ReadEventResult result, ResolvedIndexedEvent @event, string error)
    {
        Result = result;
        Event = @event;
        Error = error;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ReadStreamEvents")]
  public partial class ReadStreamEvents
  {
    [ProtoMember(1, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(2, IsRequired = true, Name=@"from_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int FromEventNumber;
  
    [ProtoMember(3, IsRequired = true, Name=@"max_count", DataFormat = DataFormat.TwosComplement)]
    public readonly int MaxCount;
  
    [ProtoMember(4, IsRequired = true, Name=@"resolve_link_tos", DataFormat = DataFormat.Default)]
    public readonly bool ResolveLinkTos;
  
    [ProtoMember(5, IsRequired = true, Name=@"require_master", DataFormat = DataFormat.Default)]
    public readonly bool RequireMaster;
  
    private ReadStreamEvents() {}
  
    public ReadStreamEvents(string eventStreamId, int fromEventNumber, int maxCount, bool resolveLinkTos, bool requireMaster)
    {
        EventStreamId = eventStreamId;
        FromEventNumber = fromEventNumber;
        MaxCount = maxCount;
        ResolveLinkTos = resolveLinkTos;
        RequireMaster = requireMaster;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ReadStreamEventsCompleted")]
  public partial class ReadStreamEventsCompleted
  {
    [ProtoMember(1, Name=@"events", DataFormat = DataFormat.Default)]
    public readonly ResolvedIndexedEvent[] Events;
  
    [ProtoMember(2, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly ReadStreamEventsCompleted.ReadStreamResult Result;
  
    [ProtoMember(3, IsRequired = true, Name=@"next_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int NextEventNumber;
  
    [ProtoMember(4, IsRequired = true, Name=@"last_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int LastEventNumber;
  
    [ProtoMember(5, IsRequired = true, Name=@"is_end_of_stream", DataFormat = DataFormat.Default)]
    public readonly bool IsEndOfStream;
  
    [ProtoMember(6, IsRequired = true, Name=@"last_commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long LastCommitPosition;
  
    [ProtoMember(7, IsRequired = false, Name=@"error", DataFormat = DataFormat.Default)]
    public readonly string Error;
  
    [ProtoContract(Name=@"ReadStreamResult")]
    public enum ReadStreamResult
    {
            
      [ProtoEnum(Name=@"Success", Value=0)]
      Success = 0,
            
      [ProtoEnum(Name=@"NoStream", Value=1)]
      NoStream = 1,
            
      [ProtoEnum(Name=@"StreamDeleted", Value=2)]
      StreamDeleted = 2,
            
      [ProtoEnum(Name=@"NotModified", Value=3)]
      NotModified = 3,
            
      [ProtoEnum(Name=@"Error", Value=4)]
      Error = 4,
            
      [ProtoEnum(Name=@"AccessDenied", Value=5)]
      AccessDenied = 5
    }
  
    private ReadStreamEventsCompleted() {}
  
    public ReadStreamEventsCompleted(ResolvedIndexedEvent[] events, ReadStreamEventsCompleted.ReadStreamResult result, int nextEventNumber, int lastEventNumber, bool isEndOfStream, long lastCommitPosition, string error)
    {
        Events = events;
        Result = result;
        NextEventNumber = nextEventNumber;
        LastEventNumber = lastEventNumber;
        IsEndOfStream = isEndOfStream;
        LastCommitPosition = lastCommitPosition;
        Error = error;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ReadAllEvents")]
  public partial class ReadAllEvents
  {
    [ProtoMember(1, IsRequired = true, Name=@"commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long CommitPosition;
  
    [ProtoMember(2, IsRequired = true, Name=@"prepare_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long PreparePosition;
  
    [ProtoMember(3, IsRequired = true, Name=@"max_count", DataFormat = DataFormat.TwosComplement)]
    public readonly int MaxCount;
  
    [ProtoMember(4, IsRequired = true, Name=@"resolve_link_tos", DataFormat = DataFormat.Default)]
    public readonly bool ResolveLinkTos;
  
    [ProtoMember(5, IsRequired = true, Name=@"require_master", DataFormat = DataFormat.Default)]
    public readonly bool RequireMaster;
  
    private ReadAllEvents() {}
  
    public ReadAllEvents(long commitPosition, long preparePosition, int maxCount, bool resolveLinkTos, bool requireMaster)
    {
        CommitPosition = commitPosition;
        PreparePosition = preparePosition;
        MaxCount = maxCount;
        ResolveLinkTos = resolveLinkTos;
        RequireMaster = requireMaster;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ReadAllEventsCompleted")]
  public partial class ReadAllEventsCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long CommitPosition;
  
    [ProtoMember(2, IsRequired = true, Name=@"prepare_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long PreparePosition;
  
    [ProtoMember(3, Name=@"events", DataFormat = DataFormat.Default)]
    public readonly ResolvedEvent[] Events;
  
    [ProtoMember(4, IsRequired = true, Name=@"next_commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long NextCommitPosition;
  
    [ProtoMember(5, IsRequired = true, Name=@"next_prepare_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long NextPreparePosition;
  
    [ProtoMember(6, IsRequired = false, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly ReadAllEventsCompleted.ReadAllResult Result;
  
    [ProtoMember(7, IsRequired = false, Name=@"error", DataFormat = DataFormat.Default)]
    public readonly string Error;
  
    [ProtoContract(Name=@"ReadAllResult")]
    public enum ReadAllResult
    {
            
      [ProtoEnum(Name=@"Success", Value=0)]
      Success = 0,
            
      [ProtoEnum(Name=@"NotModified", Value=1)]
      NotModified = 1,
            
      [ProtoEnum(Name=@"Error", Value=2)]
      Error = 2,
            
      [ProtoEnum(Name=@"AccessDenied", Value=3)]
      AccessDenied = 3
    }
  
    private ReadAllEventsCompleted() {}
  
    public ReadAllEventsCompleted(long commitPosition, long preparePosition, ResolvedEvent[] events, long nextCommitPosition, long nextPreparePosition, ReadAllEventsCompleted.ReadAllResult result, string error)
    {
        CommitPosition = commitPosition;
        PreparePosition = preparePosition;
        Events = events;
        NextCommitPosition = nextCommitPosition;
        NextPreparePosition = nextPreparePosition;
        Result = result;
        Error = error;
    }
  }
  
  [Serializable, ProtoContract(Name=@"CreatePersistentSubscription")]
  public partial class CreatePersistentSubscription
  {
    [ProtoMember(1, IsRequired = true, Name=@"subscription_group_name", DataFormat = DataFormat.Default)]
    public readonly string SubscriptionGroupName;
  
    [ProtoMember(2, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(3, IsRequired = true, Name=@"resolve_link_tos", DataFormat = DataFormat.Default)]
    public readonly bool ResolveLinkTos;
  
    [ProtoMember(4, IsRequired = true, Name=@"start_from_beginning", DataFormat = DataFormat.Default)]
    public readonly bool StartFromBeginning;
  
    private CreatePersistentSubscription() {}
  
    public CreatePersistentSubscription(string subscriptionGroupName, string eventStreamId, bool resolveLinkTos, bool startFromBeginning)
    {
        SubscriptionGroupName = subscriptionGroupName;
        EventStreamId = eventStreamId;
        ResolveLinkTos = resolveLinkTos;
        StartFromBeginning = startFromBeginning;
    }
  }
  
  [Serializable, ProtoContract(Name=@"DeletePersistentSubscription")]
  public partial class DeletePersistentSubscription
  {
    [ProtoMember(1, IsRequired = true, Name=@"subscription_group_name", DataFormat = DataFormat.Default)]
    public readonly string SubscriptionGroupName;
  
    [ProtoMember(2, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    private DeletePersistentSubscription() {}
  
    public DeletePersistentSubscription(string subscriptionGroupName, string eventStreamId)
    {
        SubscriptionGroupName = subscriptionGroupName;
        EventStreamId = eventStreamId;
    }
  }
  
  [Serializable, ProtoContract(Name=@"CreatePersistentSubscriptionCompleted")]
  public partial class CreatePersistentSubscriptionCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly CreatePersistentSubscriptionCompleted.CreatePersistentSubscriptionResult Result;
  
    [ProtoMember(2, IsRequired = false, Name=@"reason", DataFormat = DataFormat.Default)]
    public readonly string Reason;
  
    [ProtoContract(Name=@"CreatePersistentSubscriptionResult")]
    public enum CreatePersistentSubscriptionResult
    {
            
      [ProtoEnum(Name=@"Success", Value=0)]
      Success = 0,
            
      [ProtoEnum(Name=@"AlreadyExists", Value=1)]
      AlreadyExists = 1,
            
      [ProtoEnum(Name=@"Fail", Value=2)]
      Fail = 2,
            
      [ProtoEnum(Name=@"AccessDenied", Value=3)]
      AccessDenied = 3
    }
  
    private CreatePersistentSubscriptionCompleted() {}
  
    public CreatePersistentSubscriptionCompleted(CreatePersistentSubscriptionCompleted.CreatePersistentSubscriptionResult result, string reason)
    {
        Result = result;
        Reason = reason;
    }
  }
  
  [Serializable, ProtoContract(Name=@"DeletePersistentSubscriptionCompleted")]
  public partial class DeletePersistentSubscriptionCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly DeletePersistentSubscriptionCompleted.DeletePersistentSubscriptionResult Result;
  
    [ProtoMember(2, IsRequired = false, Name=@"reason", DataFormat = DataFormat.Default)]
    public readonly string Reason;
  
    [ProtoContract(Name=@"DeletePersistentSubscriptionResult")]
    public enum DeletePersistentSubscriptionResult
    {
            
      [ProtoEnum(Name=@"Success", Value=0)]
      Success = 0,
            
      [ProtoEnum(Name=@"DoesNotExist", Value=1)]
      DoesNotExist = 1,
            
      [ProtoEnum(Name=@"Fail", Value=2)]
      Fail = 2,
            
      [ProtoEnum(Name=@"AccessDenied", Value=3)]
      AccessDenied = 3
    }
  
    private DeletePersistentSubscriptionCompleted() {}
  
    public DeletePersistentSubscriptionCompleted(DeletePersistentSubscriptionCompleted.DeletePersistentSubscriptionResult result, string reason)
    {
        Result = result;
        Reason = reason;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ConnectToPersistentSubscription")]
  public partial class ConnectToPersistentSubscription
  {
    [ProtoMember(1, IsRequired = true, Name=@"subscription_id", DataFormat = DataFormat.Default)]
    public readonly string SubscriptionId;
  
    [ProtoMember(2, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(3, IsRequired = true, Name=@"allowed_in_flight_messages", DataFormat = DataFormat.TwosComplement)]
    public readonly int AllowedInFlightMessages;
  
    private ConnectToPersistentSubscription() {}
  
    public ConnectToPersistentSubscription(string subscriptionId, string eventStreamId, int allowedInFlightMessages)
    {
        SubscriptionId = subscriptionId;
        EventStreamId = eventStreamId;
        AllowedInFlightMessages = allowedInFlightMessages;
    }
  }
  
  [Serializable, ProtoContract(Name=@"PersistentSubscriptionAckEvents")]
  public partial class PersistentSubscriptionAckEvents
  {
    [ProtoMember(1, IsRequired = true, Name=@"subscription_id", DataFormat = DataFormat.Default)]
    public readonly string SubscriptionId;
  
    [ProtoMember(3, Name=@"processed_event_ids", DataFormat = DataFormat.Default)]
    public readonly byte[][] ProcessedEventIds;
  
    private PersistentSubscriptionAckEvents() {}
  
    public PersistentSubscriptionAckEvents(string subscriptionId, byte[][] processedEventIds)
    {
        SubscriptionId = subscriptionId;
        ProcessedEventIds = processedEventIds;
    }
  }
  
  [Serializable, ProtoContract(Name=@"PersistentSubscriptionNakEvents")]
  public partial class PersistentSubscriptionNakEvents
  {
    [ProtoMember(1, IsRequired = true, Name=@"subscription_id", DataFormat = DataFormat.Default)]
    public readonly string SubscriptionId;
  
    [ProtoMember(3, Name=@"processed_event_ids", DataFormat = DataFormat.Default)]
    public readonly byte[][] ProcessedEventIds;
  
    private PersistentSubscriptionNakEvents() {}
  
    public PersistentSubscriptionNakEvents(string subscriptionId, byte[][] processedEventIds)
    {
        SubscriptionId = subscriptionId;
        ProcessedEventIds = processedEventIds;
    }
  }
  
  [Serializable, ProtoContract(Name=@"PersistentSubscriptionConfirmation")]
  public partial class PersistentSubscriptionConfirmation
  {
    [ProtoMember(1, IsRequired = true, Name=@"last_commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long LastCommitPosition;
  
    [ProtoMember(2, IsRequired = false, Name=@"last_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int? LastEventNumber;
  
    private PersistentSubscriptionConfirmation() {}
  
    public PersistentSubscriptionConfirmation(long lastCommitPosition, int? lastEventNumber)
    {
        LastCommitPosition = lastCommitPosition;
        LastEventNumber = lastEventNumber;
    }
  }
  
  [Serializable, ProtoContract(Name=@"PersistentSubscriptionStreamEventAppeared")]
  public partial class PersistentSubscriptionStreamEventAppeared
  {
    [ProtoMember(1, IsRequired = true, Name=@"event", DataFormat = DataFormat.Default)]
    public readonly ResolvedIndexedEvent Event;
  
    private PersistentSubscriptionStreamEventAppeared() {}
  
    public PersistentSubscriptionStreamEventAppeared(ResolvedIndexedEvent @event)
    {
        Event = @event;
    }
  }
  
  [Serializable, ProtoContract(Name=@"SubscribeToStream")]
  public partial class SubscribeToStream
  {
    [ProtoMember(1, IsRequired = true, Name=@"event_stream_id", DataFormat = DataFormat.Default)]
    public readonly string EventStreamId;
  
    [ProtoMember(2, IsRequired = true, Name=@"resolve_link_tos", DataFormat = DataFormat.Default)]
    public readonly bool ResolveLinkTos;
  
    private SubscribeToStream() {}
  
    public SubscribeToStream(string eventStreamId, bool resolveLinkTos)
    {
        EventStreamId = eventStreamId;
        ResolveLinkTos = resolveLinkTos;
    }
  }
  
  [Serializable, ProtoContract(Name=@"SubscriptionConfirmation")]
  public partial class SubscriptionConfirmation
  {
    [ProtoMember(1, IsRequired = true, Name=@"last_commit_position", DataFormat = DataFormat.TwosComplement)]
    public readonly long LastCommitPosition;
  
    [ProtoMember(2, IsRequired = false, Name=@"last_event_number", DataFormat = DataFormat.TwosComplement)]
    public readonly int? LastEventNumber;
  
    private SubscriptionConfirmation() {}
  
    public SubscriptionConfirmation(long lastCommitPosition, int? lastEventNumber)
    {
        LastCommitPosition = lastCommitPosition;
        LastEventNumber = lastEventNumber;
    }
  }
  
  [Serializable, ProtoContract(Name=@"StreamEventAppeared")]
  public partial class StreamEventAppeared
  {
    [ProtoMember(1, IsRequired = true, Name=@"event", DataFormat = DataFormat.Default)]
    public readonly ResolvedEvent Event;
  
    private StreamEventAppeared() {}
  
    public StreamEventAppeared(ResolvedEvent @event)
    {
        Event = @event;
    }
  }
  
  [Serializable, ProtoContract(Name=@"UnsubscribeFromStream")]
  public partial class UnsubscribeFromStream
  {
    public UnsubscribeFromStream()
    {
    }
  }
  
  [Serializable, ProtoContract(Name=@"SubscriptionDropped")]
  public partial class SubscriptionDropped
  {
    [ProtoMember(1, IsRequired = false, Name=@"reason", DataFormat = DataFormat.TwosComplement)]
    public readonly SubscriptionDropped.SubscriptionDropReason Reason;
  
    [ProtoContract(Name=@"SubscriptionDropReason")]
    public enum SubscriptionDropReason
    {
            
      [ProtoEnum(Name=@"Unsubscribed", Value=0)]
      Unsubscribed = 0,
            
      [ProtoEnum(Name=@"AccessDenied", Value=1)]
      AccessDenied = 1,
            
      [ProtoEnum(Name=@"NotFound", Value=2)]
      NotFound = 2,
            
      [ProtoEnum(Name=@"PersistentSubscriptionDeleted", Value=3)]
      PersistentSubscriptionDeleted = 3
    }
  
    private SubscriptionDropped() {}
  
    public SubscriptionDropped(SubscriptionDropped.SubscriptionDropReason reason)
    {
        Reason = reason;
    }
  }
  
  [Serializable, ProtoContract(Name=@"NotHandled")]
  public partial class NotHandled
  {
    [ProtoMember(1, IsRequired = true, Name=@"reason", DataFormat = DataFormat.TwosComplement)]
    public readonly NotHandled.NotHandledReason Reason;
  
    [ProtoMember(2, IsRequired = false, Name=@"additional_info", DataFormat = DataFormat.Default)]
    public readonly byte[] AdditionalInfo;
  
  [Serializable, ProtoContract(Name=@"MasterInfo")]
  public partial class MasterInfo
  {
    [ProtoMember(1, IsRequired = true, Name=@"external_tcp_address", DataFormat = DataFormat.Default)]
    public readonly string ExternalTcpAddress;
  
    [ProtoMember(2, IsRequired = true, Name=@"external_tcp_port", DataFormat = DataFormat.TwosComplement)]
    public readonly int ExternalTcpPort;
  
    [ProtoMember(3, IsRequired = true, Name=@"external_http_address", DataFormat = DataFormat.Default)]
    public readonly string ExternalHttpAddress;
  
    [ProtoMember(4, IsRequired = true, Name=@"external_http_port", DataFormat = DataFormat.TwosComplement)]
    public readonly int ExternalHttpPort;
  
    [ProtoMember(5, IsRequired = false, Name=@"external_secure_tcp_address", DataFormat = DataFormat.Default)]
    public readonly string ExternalSecureTcpAddress;
  
    [ProtoMember(6, IsRequired = false, Name=@"external_secure_tcp_port", DataFormat = DataFormat.TwosComplement)]
    public readonly int? ExternalSecureTcpPort;
  
    private MasterInfo() {}
  
    public MasterInfo(string externalTcpAddress, int externalTcpPort, string externalHttpAddress, int externalHttpPort, string externalSecureTcpAddress, int? externalSecureTcpPort)
    {
        ExternalTcpAddress = externalTcpAddress;
        ExternalTcpPort = externalTcpPort;
        ExternalHttpAddress = externalHttpAddress;
        ExternalHttpPort = externalHttpPort;
        ExternalSecureTcpAddress = externalSecureTcpAddress;
        ExternalSecureTcpPort = externalSecureTcpPort;
    }
  }
  
    [ProtoContract(Name=@"NotHandledReason")]
    public enum NotHandledReason
    {
            
      [ProtoEnum(Name=@"NotReady", Value=0)]
      NotReady = 0,
            
      [ProtoEnum(Name=@"TooBusy", Value=1)]
      TooBusy = 1,
            
      [ProtoEnum(Name=@"NotMaster", Value=2)]
      NotMaster = 2
    }
  
    private NotHandled() {}
  
    public NotHandled(NotHandled.NotHandledReason reason, byte[] additionalInfo)
    {
        Reason = reason;
        AdditionalInfo = additionalInfo;
    }
  }
  
  [Serializable, ProtoContract(Name=@"ScavengeDatabase")]
  public partial class ScavengeDatabase
  {
    public ScavengeDatabase()
    {
    }
  }
  
  [Serializable, ProtoContract(Name=@"ScavengeDatabaseCompleted")]
  public partial class ScavengeDatabaseCompleted
  {
    [ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = DataFormat.TwosComplement)]
    public readonly ScavengeDatabaseCompleted.ScavengeResult Result;
  
    [ProtoMember(2, IsRequired = false, Name=@"error", DataFormat = DataFormat.Default)]
    public readonly string Error;
  
    [ProtoMember(3, IsRequired = true, Name=@"total_time_ms", DataFormat = DataFormat.TwosComplement)]
    public readonly int TotalTimeMs;
  
    [ProtoMember(4, IsRequired = true, Name=@"total_space_saved", DataFormat = DataFormat.TwosComplement)]
    public readonly long TotalSpaceSaved;
  
    [ProtoContract(Name=@"ScavengeResult")]
    public enum ScavengeResult
    {
            
      [ProtoEnum(Name=@"Success", Value=0)]
      Success = 0,
            
      [ProtoEnum(Name=@"InProgress", Value=1)]
      InProgress = 1,
            
      [ProtoEnum(Name=@"Failed", Value=2)]
      Failed = 2
    }
  
    private ScavengeDatabaseCompleted() {}
  
    public ScavengeDatabaseCompleted(ScavengeDatabaseCompleted.ScavengeResult result, string error, int totalTimeMs, long totalSpaceSaved)
    {
        Result = result;
        Error = error;
        TotalTimeMs = totalTimeMs;
        TotalSpaceSaved = totalSpaceSaved;
    }
  }
  
    [ProtoContract(Name=@"OperationResult")]
    public enum OperationResult
    {
            
      [ProtoEnum(Name=@"Success", Value=0)]
      Success = 0,
            
      [ProtoEnum(Name=@"PrepareTimeout", Value=1)]
      PrepareTimeout = 1,
            
      [ProtoEnum(Name=@"CommitTimeout", Value=2)]
      CommitTimeout = 2,
            
      [ProtoEnum(Name=@"ForwardTimeout", Value=3)]
      ForwardTimeout = 3,
            
      [ProtoEnum(Name=@"WrongExpectedVersion", Value=4)]
      WrongExpectedVersion = 4,
            
      [ProtoEnum(Name=@"StreamDeleted", Value=5)]
      StreamDeleted = 5,
            
      [ProtoEnum(Name=@"InvalidTransaction", Value=6)]
      InvalidTransaction = 6,
            
      [ProtoEnum(Name=@"AccessDenied", Value=7)]
      AccessDenied = 7
    }
  
  }
}