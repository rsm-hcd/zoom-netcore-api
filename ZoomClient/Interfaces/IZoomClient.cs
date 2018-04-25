namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomClient
    {
        /// <summary>
        /// Meetings Client
        /// </summary>
        ZoomMeetingsClient Meetings { get; }

        /// <summary>
        /// Reports Client
        /// </summary>
        ZoomReportsClient Reports { get; }

        /// <summary>
        /// Users Client
        /// </summary>
        ZoomUsersClient Users { get; }
    }
}
