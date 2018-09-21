using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    class EmailBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD 
        public bool AddEmail(EmailBE email, int systemUserId)
        {
            try
            {
                EmailBE oEmailBE = new EmailBE()
                {
                    //EmailId = BE.Utils.GetPrimaryKey("no usa"),
                    Email = email.Email,


                    //Auditoria

                };

                ctx.Email.Add(oEmailBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
