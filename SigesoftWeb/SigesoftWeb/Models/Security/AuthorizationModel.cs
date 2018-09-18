using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigesoftWeb.Models.Security
{
    public class UserLogin
    {
        public int SystemUserId { get; set; }
        public string PersonId { get; set; }       
        public byte[] ImagePerson { get; set; }
        public string FullName { get; set; }       
        public string Password { get; set; }
     
        public List<AuthorizationModel> Authorizations { get; set; }
    }

    public class AuthorizationModel
    {

    }
}