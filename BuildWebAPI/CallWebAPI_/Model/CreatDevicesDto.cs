namespace CallWebAPI.Model
{
    public class CreatDevicesDto
    {
        public int Id { get; set; }
        public int DeviceTypeId { get; set; } //設備類型
        public string ItemName { get; set; } //設備品名
        public string ItemDescription { get; set; } //物品描述
    }
}
