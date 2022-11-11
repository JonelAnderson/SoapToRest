using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
   
    public class TokenRoot
    {
        public TokenEnvelope Envelope { get; set; }
    }
    public class TokenEnvelope
    {
        public TokenBody Body { get; set; }
    }
    public class TokenBody
    {
        public GetTokenAccessResponse GetTokenAccessResponse { get; set; }
    }
    public class GetTokenAccessResponse
    {
        public User GetTokenAccessResult { get; set; }
    }
   
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public Guid Token { get; set; }
    }
   

}
