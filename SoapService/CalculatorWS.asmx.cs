using SoapService.Models;
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace SoapService
{
    /// <summary>
    /// Summary description for CalculatorWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculatorSW : System.Web.Services.WebService, ICalculator
    {
        public HeaderSoapAccess headerSoapAccess;
        public HeaderSoapToken headerSoapToken;

        [WebMethod]
        [SoapHeader("headerSoapAccess")]
        public TokenAccess GetTokenAccess()
        {
            string user;
            string password;
            string token = string.Empty;
            TokenAccess tokenAcceso;

            if (headerSoapAccess == null ||
                string.IsNullOrEmpty(headerSoapAccess?.UserName) ||
                string.IsNullOrEmpty(headerSoapAccess?.Password))
            {
                throw new SoapException("Acceso no autorizado", SoapException.ClientFaultCode,
                    new Exception(@"Se requiere Usuario y Contraseña en la Cabecera de la petición."));
            }
            else
            {

                user = headerSoapAccess.UserName;
                password = headerSoapAccess.Password;
            }


            tokenAcceso = headerSoapAccess.ValidarUsuario(user, password);
            if (tokenAcceso != null)
            {

                tokenAcceso.Token = Guid.NewGuid();

                HttpRuntime.Cache.Add(
                    tokenAcceso.Token.ToString(),
                    tokenAcceso,
                    null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration,
                    TimeSpan.FromMinutes(5),
                    System.Web.Caching.CacheItemPriority.NotRemovable,
                    null
                );
            }
            else
            {
                throw new SoapException("Acceso no autorizado", SoapException.ClientFaultCode,
                    new Exception(@"EL Usuario y/o Contraseña no son válidos."));
            }


            if (!string.IsNullOrEmpty(tokenAcceso.Token.ToString()))
            {
                return tokenAcceso;
            }
            else
            {
                throw new SoapException("Acceso no autorizado", SoapException.ClientFaultCode,
                    new Exception(@"ERROR. No se ha podido generar el Token de acceso."));
            }
        }


        [WebMethod]
        [SoapHeader("headerSoapToken")]
        public Result CalculatorFast(TwoSteep data)
        {
            var result = (data.Valor2 / data.Valor1) * 100;

            if (headerSoapToken == null || string.IsNullOrEmpty(headerSoapToken.TokenAcceso))
            {
                throw new SoapException("Acceso no autorizado", SoapException.ClientFaultCode,
                    new Exception(@"Se requiere un Token de acceso en la cabecera de la petición. 
                                    Llamar primero al método GetTokenAcceso() para obtener el Token de acceso."));
            }
            else
            {

                if (!headerSoapToken.ValidarTokenAcceso(headerSoapToken.TokenAcceso))
                {

                    throw new SoapException("Acceso no autorizado", SoapException.ClientFaultCode,
                    new Exception(@"El Token de acceso es incorrecto o ha caducado."));
                }
                else
                {
                    return new Result()
                    {
                        Calculated = Math.Round(result, 4)
                    };
                }
            }

            
        }
    }
}
