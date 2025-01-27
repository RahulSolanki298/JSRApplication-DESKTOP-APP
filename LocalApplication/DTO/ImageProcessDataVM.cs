namespace LocalApplication.DTO
{
    public class ImageProcessDataVM
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string ProjectDetailsName { get; set; }

        public string ModuleSerialNo { get; set; }

        public string ModuleLocation { get; set; }

        public string ImageName { get; set; }

        public string ImageResult { get; set; }

        public string SeverityScore { get; set; }

        public string ModuleCountName { get; set; }

        public string DefectData { get; set; }

        public int? Crack { get; set; }

        public int? TreeCrack { get; set; }

        public int? DeadCell { get; set; }

        public int? DarkArea { get; set; }

        public int? OpenSoldering { get; set; }

        public int? FingerInteruption { get; set; }

        public int? BackSheetCut { get; set; }

        public string EmployeeName { get; set; }

        public string SoftwareKey { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsSuccess { get; set; }

        public string CompanyName { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }

        public string EmployeeCode { get; set; }

        public int? ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }

        public string BulkProcessCode { get; set; }
    }
}
