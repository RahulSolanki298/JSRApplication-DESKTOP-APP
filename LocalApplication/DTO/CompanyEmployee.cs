using System.ComponentModel.DataAnnotations;

namespace LocalApplication.DTO
{
    public class CompanyEmployee
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string EmployeeCode { get; set; }

        public string EmployeeType { get; set; }

        [Required]
        public int SoftwareId { get; set; }

        public bool? IsActive { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int CompanyId { get; set; }

    }
}
