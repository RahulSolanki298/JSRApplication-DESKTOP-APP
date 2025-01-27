using System.ComponentModel.DataAnnotations;

namespace LocalApplication.DTO
{
    public class ProjectDetailsVM
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string Softwarekey { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeCode { get; set; }

        public string ProjectName { get; set; }

        public string WP_Product { get; set; }

        public DateTime? Date { get; set; }

        public string Shift { get; set; }

        public string ManufacturerName { get; set; }

        public string ManufacturingBy { get; set; }

        public string CustomerName { get; set; }

        public string CriteriaBasketName { get; set; }

        public string SubCriteriaBasketName { get; set; }

        public string ModuleMatrix { get; set; }

        public string ElementWith { get; set; }

        public int CellSize { get; set; }

        public string SiteName { get; set; }

        public string CompanyName { get; set; }

        public string UploadStatus { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }

        public string ProjectStatus { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }
    }
}
