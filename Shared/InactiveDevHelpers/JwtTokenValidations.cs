//using Bondlog.Shared.Domain.Models;
//using System.Security.Claims;
//using System.Text;

//namespace Bondlog.Shared.Helpers
//{
//    public class JwtTokenValidations
//    {
//        public UserSession GenerateJwtToken(string email, string role)
//        {
//            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey!));
//            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
//            var claimsIdentity = new ClaimsIdentity(new List<Claim>
//            {
//                new Claim(ClaimTypes.Name, email),
//                new Claim(ClaimTypes.Role, role)
//            });

//            var securityTokenDescriptor = new SecurityTokenDescriptor()
//            {
//                Subject = claimsIdentity,
//                Expires = DateTime.Now.AddDays(1),
//                SigningCredentials = credentials,
//            };

//            var jwtTokenHandler = new JwtSecurityTokenHandler();
//            var securityToken = jwtTokenHandler.CreateToken(securityTokenDescriptor);
//            var token = jwtTokenHandler.WriteToken(securityToken);

//            return new UserSession()
//            {
//                Role = role,
//                Username = email,
//                Token = token
//            };
//        }
//    }
//}
