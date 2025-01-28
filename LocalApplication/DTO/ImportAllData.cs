namespace LocalApplication.DTO
{
    public class ImportAllData
    {
        public CompanyVM Company { get; set; }
        public List<SiteVM> SiteList { get; set; }
        public List<CompanyEmployeeVM> CompanyEmployeeList { get; set; }
        public List<CompanyCustomerVM> CompanyCustomerList { get; set; }
        public List<CriteriaBasketVM> CriteriaBasketList { get; set; }
        public List<AcceptanceCriteriaMainVM> AcceptanceCriteriaMainList { get; set; }
        public List<AcceptanceCriteriaVM> AcceptanceCriteriaList { get; set; }
        public List<ProjectDetailsVM> ProjectDetailsList { get; set; }
        public List<TextInImageVM> TextInImageList { get; set; }
        public List<ImageProcessReqVM> ImageProcessReqList { get; set; }
        public List<BulkImageDataVM> BulkImageDataList { get; set; }
        public List<ImageProcessDataVM> ImageProcessDataList { get; set; }
        public List<ReplicateHistoryVM> ReplicateHistoryList { get; set; }
    }
}
