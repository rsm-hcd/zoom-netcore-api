namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomClient
    {
        /// <summary>
        /// Meetings Client
        /// </summary>
        IZoomMeetingsClient Meetings { get; }

        /// <summary>
        /// Reports Client
        /// </summary>
        IZoomReportsClient Reports { get; }

        /// <summary>
        /// Users Client
        /// </summary>
        IZoomUsersClient Users { get; }
    }
}
