using System;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.IO;
using DAL;
using BE.Common;
using System.Linq;

namespace BL
{
    public class Utils
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region Encription
        public static string Encrypt(string pData)
        {
            UnicodeEncoding parser = new UnicodeEncoding();
            byte[] _original = parser.GetBytes(pData);
            MD5CryptoServiceProvider Hash = new MD5CryptoServiceProvider();
            byte[] _encrypt = Hash.ComputeHash(_original);
            return Convert.ToBase64String(_encrypt);
        }
        #endregion

        #region Mail
        public static bool SendMail(string body, string subject, List<string> adresses, string SystemAdress, string SystemAdressPassword, string SMTPHost, string MailDisplayName = "Sistema")
        {
            try
            {
                MailMessage Mail = new MailMessage();
                Mail.Body = body;
                Mail.BodyEncoding = Encoding.UTF8;
                Mail.From = new MailAddress(SystemAdress, MailDisplayName);
                Mail.IsBodyHtml = true;
                Mail.Priority = MailPriority.Normal;
                Mail.Subject = subject;
                Mail.To.Add(string.Join(",", adresses));

                SmtpClient Client = new SmtpClient();
                Client.Host = SMTPHost;
                Client.EnableSsl = true;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.Port = 587;
                Client.UseDefaultCredentials = false;
                Client.Credentials = new NetworkCredential(SystemAdress, SystemAdressPassword);

                Client.Send(Mail);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool SendMail(string body, string subject, List<string> adresses, string SystemAdress, string SystemAdressPassword, string SMTPHost, Dictionary<string, MemoryStream> streamAttach, string MailDisplayName = "Sistema")
        {
            try
            {
                MailMessage Mail = new MailMessage();
                Mail.Body = body;
                Mail.BodyEncoding = Encoding.UTF8;
                Mail.From = new MailAddress(SystemAdress, MailDisplayName);
                Mail.IsBodyHtml = true;
                Mail.Priority = MailPriority.Normal;
                Mail.Subject = subject;
                Mail.To.Add(string.Join(",", adresses));

                foreach (var Attach in streamAttach)
                {
                    Mail.Attachments.Add(new Attachment(Attach.Value, Attach.Key));
                }

                SmtpClient Client = new SmtpClient();
                Client.Host = SMTPHost;
                Client.EnableSsl = true;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.Port = 587;
                Client.UseDefaultCredentials = false;
                Client.Credentials = new NetworkCredential(SystemAdress, SystemAdressPassword);

                Client.Send(Mail);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        public static int GetAge(DateTime birthdate)
        {
            return int.Parse((DateTime.Today.AddTicks(-birthdate.Ticks).Year - 1).ToString());
        }

        #region PK
        public string GetPrimaryKey(int nodeId, int tableId, string pre)
        {
            var secuentialId = GetNextSecuentialId(nodeId, tableId);
            return string.Format("N{0}-{1}{2}", nodeId.ToString("000"), pre, secuentialId.ToString("000000000"));
        }

        public int GetNextSecuentialId(int pintNodeId, int pintTableId)
        {

            var objSecuential = (from a in ctx.Secuential
                                 where a.i_TableId == pintTableId && a.i_NodeId == pintNodeId
                                 select a).SingleOrDefault();

            // Actualizar el campo con el nuevo valor a efectos de reservar el ID autogenerado para evitar colisiones entre otros nodos
            if (objSecuential != null)
            {
                objSecuential.i_SecuentialId = objSecuential.i_SecuentialId + 1;
            }
            else
            {
                objSecuential = new SecuentialBE();
                objSecuential.i_NodeId = pintNodeId;
                objSecuential.i_TableId = pintTableId;
                objSecuential.i_SecuentialId = 0;
                ctx.Secuential.Add(objSecuential);
            }
           
            int rows = ctx.SaveChanges();

            return objSecuential.i_SecuentialId.Value;
        }
        #endregion
    }
}
