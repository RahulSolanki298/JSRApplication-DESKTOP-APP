using System.ComponentModel.DataAnnotations;

namespace LocalApplication.DTO
{
    public class SiteVM
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ReplicateId { get; set; }

        public string ReplicateStatus { get; set; }

        public string SoftwareKey { get; set; }

        public int ReplicateHistoryId { get; set; }
        public string ReplicateHistoryCode { get; set; }
    }
}
