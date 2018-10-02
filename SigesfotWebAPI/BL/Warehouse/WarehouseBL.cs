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
    public class WarehouseBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public WarehouseBE GetWarehouse(string warehouseId)
        {
            try
            {
                var objEntity = (from a in ctx.Warehouse
                                 where a.v_WarehouseId == warehouseId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<WarehouseBE> GetAllWarehouse()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Warehouse
                                 where a.i_IsDeleted == isDelete
                                 select new WarehouseBE()
                                 {
                                     v_WarehouseId = a.v_WarehouseId,
                                     v_OrganizationId = a.v_OrganizationId,
                                     v_LocationId = a.v_LocationId,
                                     v_Name = a.v_Name,
                                     v_AdditionalInformation = a.v_AdditionalInformation,
                                     i_CostCenterId = a.i_CostCenterId,
                                     i_IsDeleted = a.i_IsDeleted,
                                     i_InsertUserId = a.i_InsertUserId,
                                     d_InsertDate = a.d_InsertDate,
                                     d_UpdateDate = a.d_UpdateDate,
                                     i_UpdateUserId = a.i_UpdateUserId
                                 }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddWarehouse(WarehouseBE warehouse, int systemUserId)
        {
            try
            {
                WarehouseBE oWarehouseBE = new WarehouseBE()
                {
                    v_WarehouseId =  new Utils().GetPrimaryKey(1, 2, "WW"),
                    v_OrganizationId = warehouse.v_OrganizationId,
                    v_LocationId = warehouse.v_LocationId,
                    v_Name = warehouse.v_Name,
                    v_AdditionalInformation = warehouse.v_AdditionalInformation,
                    i_CostCenterId = warehouse.i_CostCenterId,

                    //Auditoria
                    i_IsDeleted = (int)Enumeratores.SiNo.No,
                    d_InsertDate = DateTime.UtcNow,
                    i_InsertUserId = systemUserId,
                };

                ctx.Warehouse.Add(oWarehouseBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateWarehouse(WarehouseBE warehouse, int systemUserId)
        {
            try
            {
                var oWarehouse = (from a in ctx.Warehouse
                                  where a.v_WarehouseId == warehouse.v_WarehouseId
                                  select a).FirstOrDefault();

                if (oWarehouse == null)
                    return false;

                oWarehouse.v_OrganizationId = warehouse.v_OrganizationId;
                oWarehouse.v_LocationId = warehouse.v_LocationId;
                oWarehouse.v_Name = warehouse.v_Name;
                oWarehouse.v_AdditionalInformation = warehouse.v_AdditionalInformation;
                oWarehouse.i_CostCenterId = warehouse.i_CostCenterId;

                //Auditoria

                oWarehouse.d_UpdateDate = DateTime.UtcNow;
                oWarehouse.i_UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteWarehouse(string warehouseId, int systemUserId)
        {
            try
            {
                var oWarehouse = (from a in ctx.Warehouse
                                  where a.v_WarehouseId == warehouseId
                                  select a).FirstOrDefault();

                if (oWarehouse == null)
                    return false;

                oWarehouse.i_UpdateUserId = systemUserId;
                oWarehouse.d_UpdateDate = DateTime.UtcNow;
                oWarehouse.i_IsDeleted = (int)Enumeratores.SiNo.Si;

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
