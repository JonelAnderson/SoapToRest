
using System;

namespace SoapService.Models
{
    public class TokenAccess
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public Guid Token { get; set; }
    }
}