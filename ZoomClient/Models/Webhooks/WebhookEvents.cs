namespace AndcultureCode.ZoomClient.Models.Webhooks
{
    public static class WebhookEvents
    {
        public static string MeetingStarted               = "meeting_started";
        public static string MeetingEnded                 = "meeting_ended";
        public static string MeetingJoinBeforeHost        = "meeting_jbh";
        public static string MeetingJoin                  = "meeting_join";
        public static string RecordingCompleted           = "recording_completed";
        public static string ParticipantJoined            = "participant_joined";
        public static string ParticipantLeft              = "participant_left";
        public static string MeetingRegistered            = "meeting_registered";
        public static string RecordingTranscriptCompleted = "recording_transcript_completed";
    }
}
