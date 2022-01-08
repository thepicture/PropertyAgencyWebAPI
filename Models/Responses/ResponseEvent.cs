using PropertyAgencyWebAPI.Models.Entities;

namespace PropertyAgencyWebAPI.Models.Responses
{
    [System.Diagnostics.CodeAnalysis
    .SuppressMessage("Style", "IDE1006:Naming Styles",
    Justification =
    "Specifications and " +
    "DataContractJsonSerializer are defined such that the violation exists")]
    public class ResponseEvent
    {
        public ResponseEvent(Event @event)
        {
            uuid = @event.UUID;
            agent_id = @event.AgentId;
            datetime = @event.DateTime;
            duration = @event.DurationInSeconds;
            type = @event.EventType.EventTypeName;
            comment = @event.Comment;
        }


        public string uuid { get; set; }
        public int agent_id { get; set; }
        public long datetime { get; set; }
        public int? duration { get; set; }
        public string type { get; set; }
        public string comment { get; set; }
    }
}