using BE.Common;
using BE.Warehouse;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Warehouse
{
    public class MovementDetailBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD

        public bool AddMovementDetail(MovementDetailBE movementDetail, int systemUserId)
        {
            try
            {
                MovementDetailBE oMovementDetailBE = new MovementDetailBE()
                {
                    //GesId = BE.Utils.GetPrimaryKey(node usa),
                    StockMax = movementDetail.StockMax,
                    StockMin = movementDetail.StockMin,
                    MovementTypeId = movementDetail.MovementTypeId,
                    Quantity = movementDetail.Quantity,
                    Price = movementDetail.Price,
                    SubTotal = movementDetail.SubTotal,

                    //sin Auditoria

                };

                ctx.MovementDetail.Add(oMovementDetailBE);

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
