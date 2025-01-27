namespace LocalApplication.DTO
{
    public class ImageProcessReqVM
    {
        public int Id { get; set; }

        public string SoftwareKey { get; set; }

        public bool? IsExposureSet { get; set; }

        public string ExposureSetValue { get; set; }

        public bool? IsDefectMarking { get; set; }

        public bool? IsPerspectiveCorrection { get; set; }

        public bool? IsRename { get; set; }

        public string RenameWith { get; set; }

        public bool? IsTextInImage { get; set; }

        public string TextInImage { get; set; }

        public bool? IsImageFullScreen { get; set; }

        public bool? IsSeverityScore { get; set; }

        public string AcceptanceCriteria { get; set; }

        public string ProjectName { get; set; }

        public string CompanyName { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }

        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }
    }
}
