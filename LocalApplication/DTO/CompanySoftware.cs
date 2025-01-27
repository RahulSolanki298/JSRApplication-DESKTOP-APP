using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalApplication.DTO
{
    public class CompanySoftware
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public string CompanySectionName { get; set; }

        public string SoftwareKey { get; set; }

        public bool IsActive { get; set; }
    }
}
