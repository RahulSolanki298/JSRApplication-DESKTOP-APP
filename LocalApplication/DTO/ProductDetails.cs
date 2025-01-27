namespace LocalApplication.DTO
{
    public class ProjectDetails
    {
        public int Id { get; set; }

        public int SoftwareId { get; set; }

        public string ProjectName { get; set; }

        public string WP_Product { get; set; }

        public DateTime Date { get; set; }

        public string Shift { get; set; }

        public string ManufacturerName { get; set; }

        public string ManufacturingBy { get; set; }

        public int? CustomerId { get; set; }

        public string CriteriaBasket { get; set; }

        public string ModuleMatrix { get; set; }

        public string ElementWith { get; set; }

        public int CellSize { get; set; }

        public string SiteName { get; set; }

        public bool IsComplate { get; set; } = false;

        public string ProjectStatus { get; set; }

    }
}
