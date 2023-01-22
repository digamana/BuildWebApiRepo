namespace BuildWebAPI.Model
{
    public class DevicesDto
    {
        public string AssetId { get; set; }// 財產編號
        public string ItemName { get; set; }// 描述
        public string ItemDescription { get; set; }// 部門
        public string DepartmentId { get; set; }// 部門ID
        public string Department { get; set; }// 部門
        public string Borrower { get; set; }//借用人工號
        public string BorrowerName { get; set; }//借用人姓名

    }
}
