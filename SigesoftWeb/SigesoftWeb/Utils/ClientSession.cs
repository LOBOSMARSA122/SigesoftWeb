using SigesoftWeb.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigesoftWeb.Utils
{
    public class ClientSession
    {
        public int SystemUserId { get; set; }
        public string PersonId { get; set; }       
        public string UserName { get; set; }
        public string FullName { get; set; }    
        public byte[] PersonImage { get; set; }
        public List<Permission> Permissions { get; set; }
        
    }
}