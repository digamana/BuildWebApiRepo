namespace BuildWebAPI.Model
{
    public class Devices
    {
        public int Id { get; set; }
        public int DeviceTypeId { get; set; } //設備類型
        public string ItemName { get; set; } //設備品名
        public string ItemDescription { get; set; } //物品描述
        public string PCName { get; set; } //電腦名稱
        public string AssetId { get; set; } //設備編號
        public int DeviceStatusId { get; set; }//狀態Id
        public int LocationId { get; set; } //設備ID
        public DateTime? WarehousingDate { get; set; } //入庫時間
        public string Custodian { get; set; } //保管人-代號
        public string CustodianName { get; set; }//保管人-姓名
        public string Department { get; set; }//部門編號
        public string DepartmentName { get; set; }//部門名稱
        public string Brand { get; set; }//設備品牌1
        public string Model { get; set; }//設備品牌2
        public string SerialNo { get; set; }//設備序號
        public string System { get; set; }//系統
        public string Ram { get; set; }//RAM
        public string Disk { get; set; }//硬碟
        public string OfficeVersion { get; set; }//Office版本
        public string Mac01 { get; set; }//無線Mac
        public string Mac02 { get; set; }//有線Mac
        public string Remark { get; set; }//備註
        public string Borrower { get; set; }//借用人工號
        public string BorrowerName { get; set; }//借用人姓名
        public DateTime? BorrowingDate { get; set; }//借用日期
    }
}
