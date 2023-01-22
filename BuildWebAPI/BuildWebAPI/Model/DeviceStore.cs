namespace BuildWebAPI.Model
{
    public static class DeviceStore
    {
        public static List<Devices> GetDevices=new List<Devices> {
            new Devices() {ItemName="Server 伺服器",ItemDescription="型號A00",AssetId="1001",Borrower="",BorrowerName="",Department=""},
            new Devices() {ItemName="筆電A",ItemDescription="型號A01",AssetId="1101",Borrower="",BorrowerName="",Department="" },
            new Devices() {ItemName="桌電A",ItemDescription="型號A02",AssetId="1010",Borrower="",BorrowerName="",Department="" },
            new Devices() {ItemName="顯示器A",ItemDescription="型號A03",AssetId="1011",Borrower="",BorrowerName="",Department="" },
            new Devices() {ItemName="投影機A",ItemDescription="型號A04",AssetId="1111",Borrower="",BorrowerName="",Department="" }
        };
    }
    public class DeviceList
    {
        public async Task<List<DevicesDto>> GetDevices()
        {
            return  new List<DevicesDto> {
            new DevicesDto() {ItemName="Server 伺服器",ItemDescription="型號A00",AssetId="1001",Borrower="",BorrowerName="",Department=""},
            new DevicesDto() {ItemName="筆電A",ItemDescription="型號A01",AssetId="1101",Borrower="",BorrowerName="",Department="" },
            new DevicesDto() {ItemName="桌電A",ItemDescription="型號A02",AssetId="1010",Borrower="",BorrowerName="",Department="" },
            new DevicesDto() {ItemName="顯示器A",ItemDescription="型號A03",AssetId="1011",Borrower="",BorrowerName="",Department="" },
            new DevicesDto() {ItemName="投影機A",ItemDescription="型號A04",AssetId="1111",Borrower="",BorrowerName="",Department="" }
        };
        }

    }
    public class MyDatabase
    {
        public List<Devices> CurrentDevicesData { get; set; }

        public MyDatabase()
        {
            CurrentDevicesData = new List<Devices>();
        }
        public async Task<List<Devices>> GetDevices()
        {
            CurrentDevicesData.Clear();
            CurrentDevicesData = new List<Devices> {
            new Devices() {ItemName="Server 伺服器",ItemDescription="型號A00",AssetId="1001",Borrower="",BorrowerName="",Department=""},
            new Devices() {ItemName="筆電A",ItemDescription="型號A01",AssetId="1101",Borrower="",BorrowerName="",Department="" },
            new Devices() {ItemName="桌電A",ItemDescription="型號A02",AssetId="1010",Borrower="",BorrowerName="",Department="" },
            new Devices() {ItemName="顯示器A",ItemDescription="型號A03",AssetId="1011",Borrower="",BorrowerName="",Department="" },
            new Devices() {ItemName="投影機A",ItemDescription="型號A04",AssetId="1111",Borrower="",BorrowerName="",Department="" }
            };
            return CurrentDevicesData;
        }
        public List<Devices> Add(Devices devices)
        {
            CurrentDevicesData.Add(devices);
            return CurrentDevicesData;
        }
    }
}
