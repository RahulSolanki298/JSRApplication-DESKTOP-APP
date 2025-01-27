namespace LocalApplication.DTO
{
    public class BulkImageDataVM
    {
        public int Id { get; set; }

        public string BulkImageDataName { get; set; }

        public string ProjectName { get; set; }

        public string BulkProcessCode { get; set; }

        public string ExcelFilePath { get; set; }

        public int NoOfImages { get; set; }

        public int NoOfProcess { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string ProcessResult { get; set; }

        public string InputFolder { get; set; }

        public string ReplicateId { get; set; }
        public string SoftwareKey { get; set; }

        public string ReplicateStatus { get; set; }

        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }
    }
}
