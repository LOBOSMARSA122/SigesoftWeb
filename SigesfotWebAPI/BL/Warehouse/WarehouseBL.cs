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
                                 where a.WarehouseId == warehouseId
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
                                 where a.IsDeleted == isDelete
                                 select new WarehouseBE()
                                 {
                                     WarehouseId = a.WarehouseId,
                                     OrganizationId = a.OrganizationId,
                                     LocationId = a.LocationId,
                                     Name = a.Name,
                                     AdditionalInformation = a.AdditionalInformation,
                                     CostCenterId = a.CostCenterId,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateDate = a.UpdateDate,
                                     UpdateUserId = a.UpdateUserId
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
                    WarehouseId = BE.Utils.GetPrimaryKey(1, 2, "WW"),
                    OrganizationId = warehouse.OrganizationId,
                    LocationId = warehouse.LocationId,
                    Name = warehouse.Name,
                    AdditionalInformation = warehouse.AdditionalInformation,
                    CostCenterId = warehouse.CostCenterId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
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
                                  where a.WarehouseId == warehouse.WarehouseId
                                  select a).FirstOrDefault();

                if (oWarehouse == null)
                    return false;

                oWarehouse.OrganizationId = warehouse.OrganizationId;
                oWarehouse.LocationId = warehouse.LocationId;
                oWarehouse.Name = warehouse.Name;
                oWarehouse.AdditionalInformation = warehouse.AdditionalInformation;
                oWarehouse.CostCenterId = warehouse.CostCenterId;

                //Auditoria

                oWarehouse.UpdateDate = DateTime.UtcNow;
                oWarehouse.UpdateUserId = systemUserId;

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
                                  where a.WarehouseId == warehouseId
                                  select a).FirstOrDefault();

                if (oWarehouse == null)
                    return false;

                oWarehouse.UpdateUserId = systemUserId;
                oWarehouse.UpdateDate = DateTime.UtcNow;
                oWarehouse.IsDeleted = (int)Enumeratores.SiNo.Si;

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
