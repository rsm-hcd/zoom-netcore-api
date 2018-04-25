namespace AndcultureCode.ZoomClient.Models
{
    public abstract class BaseList
    {
        /// <summary>
        /// Zoom Property: page_count
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Zoom Property: page_number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Zoom Property: page_size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Zoom Property: total_records
        /// </summary>
        public int TotalRecords { get; set; }
    }
}
