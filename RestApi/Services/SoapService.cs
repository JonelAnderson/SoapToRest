namespace RestApi.Services
{
    public class SoapService
    {
        public static string Url = "https://localhost:44332/CalculatorWS.asmx?WSDL";
        

        public static string GetRequestAccessToken(string userName, string password)
        {
            var request = "<soapenv:Envelope xmlns:soapenv = 'http://schemas.xmlsoap.org/soap/envelope/' xmlns:tem = 'http://tempuri.org/'>" +
       "<soapenv:Header>" +
          "<tem:HeaderSoapAccess>"+
                "<tem:UserName>"+userName+"</tem:UserName>" +
                "<tem:Password>"+password+"</tem:Password>"+
           "</tem:HeaderSoapAccess>"+
        "</soapenv:Header>" +
         "<soapenv:Body>"+
             "<tem:GetTokenAccess/>"+
         "</soapenv:Body>"+
        "</soapenv:Envelope>";

            return request;
        }

        public static string GetRequestCalculator(string valor1, string valor2, string token)
        {
          
            var request = "<soapenv:Envelope xmlns:soapenv = 'http://schemas.xmlsoap.org/soap/envelope/' xmlns:tem = 'http://tempuri.org/'>"+

       "<soapenv:Header>"+
           "<tem:HeaderSoapToken>"+
                "<tem:TokenAcceso>"+token+"</tem:TokenAcceso>"+
           "</tem:HeaderSoapToken>"+
        "</soapenv:Header>"+
           "<soapenv:Body>"+
             "<tem:CalculatorFast>" +
                "<tem:data>"+
                "<tem:Valor1>"+valor1+"</tem:Valor1>"+
                "<tem:Valor2>"+valor2+"</tem:Valor2>" +
               "</tem:data>"+
             "</tem:CalculatorFast>" +
          "</soapenv:Body>"+
        "</soapenv:Envelope>";

            return request;

        }
    }
}
