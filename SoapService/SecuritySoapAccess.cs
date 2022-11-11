
using SoapService.Models;
using System;
using System.Web;
using System.Web.Services.Protocols;

namespace SoapService
{
    public class HeaderSoapAccess : SoapHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        private static readonly string _userName = "Admin";
        private static readonly string _password = "admin123";

        public TokenAccess ValidarUsuario(string userName, string password)
        {
            if (userName == _userName && password == _password)
            {                
                TokenAccess tokenAcceso = new TokenAccess()
                {
                    Id = Guid.NewGuid(),
                    Name = "Jack",
                    LastName = "Solsol",
                    Email = "solsol@gmail.com",
                    Rol = "Administrador"
                };
                return tokenAcceso;
            }
            else
            {
                return null;
            }
        }

    }
    public class HeaderSoapToken : SoapHeader
    {
        public string TokenAcceso { get; set; }

        public bool ValidarTokenAcceso(string tokenAcceso)
        {
            if (!string.IsNullOrEmpty(tokenAcceso))
            {
                TokenAccess _tokenAcceso = HttpRuntime.Cache[tokenAcceso] as TokenAccess;

                if (_tokenAcceso?.Token.ToString() == tokenAcceso)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}