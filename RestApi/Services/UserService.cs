using Newtonsoft.Json;
using RestApi.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class  UserService
    {
        public static async Task<User> GetAccessToken(string userName, string password)
        {
            try
            {
                var result = new User();

                using (var client = new HttpClient())
                {
                    var request = SoapService.GetRequestAccessToken(userName, password);
                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    var action = "http://tempuri.org/GetTokenAccess";

                    client.DefaultRequestHeaders.Add("SOAPAction", action);

                    using (var response = await client.PostAsync(SoapService.Url, content))
                    {
                        var asyncstring = await response.Content.ReadAsStringAsync();
                        var soapResponse = Transform.Exec(asyncstring);
                        var serialize = JsonConvert.DeserializeObject<TokenRoot>(soapResponse);

                        result = serialize.Envelope.Body.GetTokenAccessResponse.GetTokenAccessResult;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static async Task<CalculatorFastResult> GetCalculator(string valor1, string valor2, string token)
        {
            try
            {
                var result = new CalculatorFastResult();
                using (var client = new HttpClient())
                {
                    var request = SoapService.GetRequestCalculator(valor1, valor2, token);
                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    var action = "http://tempuri.org/CalculatorFast";

                    client.DefaultRequestHeaders.Add("SOAPAction", action);

                    using (var response = await client.PostAsync(SoapService.Url, content))
                    {
                        var asyncstring = await response.Content.ReadAsStringAsync();
                        var soapResponse = Transform.Exec(asyncstring);
                        var serialize = JsonConvert.DeserializeObject<CalculatorRoot>(soapResponse);

                        result = serialize.Envelope.Body.CalculatorFastResponse.CalculatorFastResult;
                    }
                }

                return result;

            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
