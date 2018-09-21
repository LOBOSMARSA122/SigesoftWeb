using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class LogBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        
        public bool AddLog(LogBE log, int systemUserId)
        {
            try
            {
                LogBE oLogBE = new LogBE()
                {
                    LogId = BE.Utils.GetPrimaryKey(1, 7, "ZZ"),
                    NodeLogId = log.NodeLogId,
                    EventTypeId = log.EventTypeId,
                    OrganizationId = log.OrganizationId,
                    Date = log.Date,
                    SystemUserId = log.SystemUserId,
                    ProcessEntity = log.ProcessEntity,
                    ElementItem = log.ElementItem,
                    Success = log.Success,
                    ErrorException = log.ErrorException,

                    //Auditoria
                };

                ctx.Log.Add(oLogBE);

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
