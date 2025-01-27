namespace LocalApplication.DTO
{
    public class CompanyCustomerVM
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string AboutCustomer { get; set; }

        public string SoftwareKey { get; set; }

        public string CompanyName { get; set; }

        public bool IsActive { get; set; } = false;

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }

        public int ReplicateHistoryId { get; set; }

        public string ReplicateHistoryCode { get; set; }
    }
}
