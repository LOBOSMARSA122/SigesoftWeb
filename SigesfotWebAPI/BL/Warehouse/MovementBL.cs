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
    public class MovementBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public MovementBE GetMovement(string movementId)
        {
            try
            {
                var objEntity = (from a in ctx.Movement
                                 where a.MovementId == movementId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MovementBE> GetAllMovement()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Movement
                                 where a.IsDeleted == isDelete
                                 select new MovementBE()
                                 {
                                     MovementId = a.MovementId,
                                     WarehouseId = a.WarehouseId,
                                     SupplierId = a.SupplierId,
                                     ProcessTypeId = a.ProcessTypeId,
                                     ParentMovementId = a.ParentMovementId,
                                     Motive = a.Motive,
                                     MotiveTypeId = a.MotiveTypeId,
                                     Date = a.Date,
                                     TotalQuantity = a.TotalQuantity,
                                     MovementTypeId = a.MovementTypeId,
                                     RequireRemoteProcess = a.RequireRemoteProcess,
                                     RemoteWarehouseId = a.RemoteWarehouseId,
                                     CurrencyId = a.CurrencyId,
                                     ExchangeRate = a.ExchangeRate,
                                     ReferenceDocument = a.ReferenceDocument,
                                     CostCenterId = a.CostCenterId,
                                     Observations = a.Observations,
                                     IsLocallyProcessed = a.IsLocallyProcessed,
                                     IsRemoteProcessed = a.IsRemoteProcessed,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateDate = a.UpdateDate,
                                     UpdateUserId = a.UpdateUserId,
                                     UpdateNodeId = a.UpdateNodeId
                                 }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddMovement(MovementBE movement, int systemUserId)
        {
            try
            {
                MovementBE oMovementBE = new MovementBE()
                {
                    MovementId =  new Common.PersonBL().GetPrimaryKey(1, 3, "MM"),
                    WarehouseId = movement.WarehouseId,
                    SupplierId = movement.SupplierId,
                    ProcessTypeId = movement.ProcessTypeId,
                    ParentMovementId = movement.ParentMovementId,
                    Motive = movement.Motive,
                    MotiveTypeId = movement.MotiveTypeId,
                    Date = movement.Date,
                    TotalQuantity = movement.TotalQuantity,
                    MovementTypeId = movement.MovementTypeId,
                    RequireRemoteProcess = movement.RequireRemoteProcess,
                    RemoteWarehouseId = movement.RemoteWarehouseId,
                    CurrencyId = movement.CurrencyId,
                    ExchangeRate = movement.ExchangeRate,
                    ReferenceDocument = movement.ReferenceDocument,
                    CostCenterId = movement.CostCenterId,
                    Observations = movement.Observations,
                    IsLocallyProcessed = movement.IsLocallyProcessed,
                    IsRemoteProcessed = movement.IsRemoteProcessed,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Movement.Add(oMovementBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMovement(MovementBE movement, int systemUserId)
        {
            try
            {
                var oMovement = (from a in ctx.Movement
                                 where a.MovementId == movement.MovementId
                                 select a).FirstOrDefault();

                if (oMovement == null)
                    return false;

                oMovement.WarehouseId = movement.WarehouseId;
                oMovement.SupplierId = movement.SupplierId;
                oMovement.ProcessTypeId = movement.ProcessTypeId;
                oMovement.ParentMovementId = movement.ParentMovementId;
                oMovement.Motive = movement.Motive;
                oMovement.MotiveTypeId = movement.MotiveTypeId;
                oMovement.Date = movement.Date;
                oMovement.TotalQuantity = movement.TotalQuantity;
                oMovement.MovementTypeId = movement.MovementTypeId;
                oMovement.RequireRemoteProcess = movement.RequireRemoteProcess;
                oMovement.RemoteWarehouseId = movement.RemoteWarehouseId;
                oMovement.CurrencyId = movement.CurrencyId;
                oMovement.ExchangeRate = movement.ExchangeRate;
                oMovement.ReferenceDocument = movement.ReferenceDocument;
                oMovement.CostCenterId = movement.CostCenterId;
                oMovement.Observations = movement.Observations;
                oMovement.IsLocallyProcessed = movement.IsLocallyProcessed;
                oMovement.IsRemoteProcessed = movement.IsRemoteProcessed;

                //Auditoria

                oMovement.UpdateDate = DateTime.UtcNow;
                oMovement.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMovement(string movementId, int systemUserId)
        {
            try
            {
                var oMovement = (from a in ctx.Movement
                                 where a.MovementId == movementId
                                 select a).FirstOrDefault();

                if (oMovement == null)
                    return false;

                oMovement.UpdateUserId = systemUserId;
                oMovement.UpdateDate = DateTime.UtcNow;
                oMovement.IsDeleted = (int)Enumeratores.SiNo.Si;

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
