using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalApplication.DTO
{
    public class UserVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsActive { get; set; }
    }

    public class SoftwareVersionVM
    {
        public int Id { get; set; }
        public string VersionName { get; set; }
        //public DateTime? PublishDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }

    public class CompanyVM
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string UserName { get; set; }

        public int NoOfSoftware { get; set; }
        public bool IsSubscription { get; set; } = false;

        public int SubscriptionDays { get; set; } = 0;

        public string SoftwareKey { get; set; }

        public bool IsNoOfImages { get; set; } = false;

        public int NoOfImages { get; set; } = 0;

        public DateTime? RegisterDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }
    }

    public class CompanySoftwareVM
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int SoftwareVersionId { get; set; }
        public string CompanySectionName { get; set; }
        public string SoftwareKey { get; set; }

        public string ProductKey { get; set; }
        public bool IsActive { get; set; }
    }

    public class CompanyAdminVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SoftwareId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public string AdminCode { get; set; }
    }

    public class CompanyEmployeeVM
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string SoftwareKey { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeCode { get; set; }
        public string ReplicateId { get; set; }
        public string ReplicateStatus { get; set; }

        public string EmployeeType { get; set; }
        public string ManageBy { get; set; }

        public string CreatedById { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }
    }

    public class CriteriaBasketVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SoftwareKey { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }
        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }
    }

    public class AcceptanceCriteriaMainVM
    {
        public int Id { get; set; }

        public string BasketName { get; set; }

        public string AcceptanceOptions { get; set; }

        public string CriteriaBasketName { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }

        public string SoftwareKey { get; set; }

        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }

    }

    public class AcceptanceCriteriaVM
    {
        public int Id { get; set; }

        public string DefectTypeName { get; set; }

        public string UnitOfMeasurement { get; set; }

        public string AcceptableMeasurement { get; set; }

        public string QuantityAcceptable { get; set; }

        public string FactoryLineName { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }

        public string SoftwareKey { get; set; }

        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }

    }

    public class UploadDataVM
    {
        public UserVM Users { get; set; }
        public SoftwareVersionVM[] SoftwareVersion { get; set; }
        public CompanyVM Company { get; set; }
        public CompanySoftwareVM CompanySoftware { get; set; }
        public CompanyAdminVM[] CompanyAdmin { get; set; }
        public DefectTypeDTO[] DefectType { get; set; }
    }
}
