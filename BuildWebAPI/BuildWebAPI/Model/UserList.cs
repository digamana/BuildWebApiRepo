namespace BuildWebAPI.Model
{
 
    public class UserList
    {
        public List<LocalUser> GetUser()
        {
            return  new List<LocalUser> {
            new LocalUser(){ id=1,Name="LILLY",Password="Pa",Role="Admin",UserName="LILLY"},
            new LocalUser(){ id=2,Name="CASEY ",Password="Pb",Role="RoleB",UserName="CASEY"},
            new LocalUser(){ id=3,Name="CHLOE",Password="Pc",Role="RoleC",UserName="CHLOE"},
            new LocalUser(){ id=4,Name="BENNETT",Password="Pd",Role="RoleD",UserName="BENNETT"},
            new LocalUser(){ id=5,Name="NIKOLAS",Password="Pe",Role="RoleE",UserName="NIKOLAS"},
        };
        }

    }
}
