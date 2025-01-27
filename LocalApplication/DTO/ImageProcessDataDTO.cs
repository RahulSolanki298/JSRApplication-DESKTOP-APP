namespace LocalApplication.DTO
{
    public class ImageProcessDataDTO
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string ImageNumber { get; set; }

        public int? PDId { get; set; }

        public int? SoftwareId { get; set; }

        public string ModuleSerialNo { get; set; } = "";

        public string ModuleLocation { get; set; } = "";

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string AddBy { get; set; }

        public int? BulkId { get; set; }
    }
}
