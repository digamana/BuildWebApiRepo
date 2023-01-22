using BuildWebAPI.Model;
using BuildWebAPI.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuildWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private string secretKey;
        public UserRepository(IConfiguration configuration)
        {
            this.secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsUniqueUser(string username)
        {
           var GetDB_User = new UserList().GetUser(); /*與DB有關的部分*/
           var user = GetDB_User.FirstOrDefault(c=>c.UserName==username);
            if(user==null)return true;
            return false;
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var GetDB_User = new UserList().GetUser(); /*與DB有關的部分*/
            var user = GetDB_User.FirstOrDefault(c=>c.UserName.ToLower()== loginRequestDTO.UserName.ToLower()&&
            c.Password==loginRequestDTO.Password);
            if (user == null) return new LoginResponseDTO { Token="",User=null };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescript = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),/*設定過期日期*/
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescript);/*產生token*/
            LoginResponseDTO loginResponseDTO= new LoginResponseDTO {User=user,Token= tokenHandler.WriteToken(token) };
            return loginResponseDTO;
        }
        public async Task<LocalUser> Register(RegisterRequestDTO registerRequestDTO)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registerRequestDTO.UserName,
                Password = registerRequestDTO.Password,
                Name = registerRequestDTO.Name,
                Role = registerRequestDTO.Role
            };
            var GetDB_User = new UserList().GetUser(); /*與DB有關的部分*/
            GetDB_User.Add(user);
            return user;

        }
    }
}
