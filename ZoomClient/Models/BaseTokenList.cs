namespace AndcultureCode.ZoomClient.Models
{
    public abstract class BaseTokenList : BaseList
    {
        /// <summary>
        /// Zoom Property: next_page_token
        /// </summary>
        public string NextPageToken { get; set; }
    }
}
