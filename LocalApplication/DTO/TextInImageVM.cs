namespace LocalApplication.DTO
{
    public class TextInImageVM
    {
        public int Id { get; set; }

        public bool? IsImageName { get; set; }

        public bool? WPOfProduct { get; set; }

        public bool? DateAndShift { get; set; }

        public bool? IsManufacturer { get; set; }

        public bool? ManufacturingPlantAndLine { get; set; }

        public bool? SiteName { get; set; }

        public bool? CustomerName { get; set; }

        public bool? CriteriaName { get; set; }

        public string SoftwareKey { get; set; }

        public string ProjectName { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }

        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }
    }
}
