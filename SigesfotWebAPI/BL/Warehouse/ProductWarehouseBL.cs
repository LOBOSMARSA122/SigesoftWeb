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
    public class ProductWarehouseBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ProductWarehouseBE GetProductWarehouse(string productWarehouseId, string productId)
        {
            try
            {
                var objEntity = (from a in ctx.ProductWarehouse
                                 where a.WarehouseId == productWarehouseId && a.ProductId == productId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ProductWarehouseBE> GetAllProductWarehouse()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ProductWarehouse
                                 where a.IsDeleted == isDelete
                                 select new ProductWarehouseBE()
                                 {
                                     WarehouseId = a.WarehouseId,
                                     ProductId = a.ProductId,
                                     StockMin = a.StockMin,
                                     StockMax = a.StockMax,
                                     StockActual = a.StockActual,
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

        public bool AddProductWarehouse(ProductWarehouseBE productWarehouse, int systemUserId)
        {
            try
            {
                ProductWarehouseBE oProductWarehouseBE = new ProductWarehouseBE()
                {
                    //ProductWarehouseId = BE.Utils.GetPrimaryKey(no usa),
                    //ProductId = productWarehouse.ProductId (llave compuesta),
                    StockMin = productWarehouse.StockMin,
                    StockMax = productWarehouse.StockMax,
                    StockActual = productWarehouse.StockActual,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.ProductWarehouse.Add(oProductWarehouseBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProductWarehouse(ProductWarehouseBE productWarehouse, int systemUserId)
        {
            try
            {
                var oProductWarehouse = (from a in ctx.ProductWarehouse
                                         where a.WarehouseId == productWarehouse.WarehouseId && a.ProductId == productWarehouse.ProductId
                                         select a).FirstOrDefault();

                if (oProductWarehouse == null)
                    return false;

                oProductWarehouse.StockMin = productWarehouse.StockMin;
                oProductWarehouse.StockMax = productWarehouse.StockMax;
                oProductWarehouse.StockActual = productWarehouse.StockActual;

                //Auditoria

                oProductWarehouse.UpdateDate = DateTime.UtcNow;
                oProductWarehouse.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProductWarehouse(string productWarehouseId, string productId, int systemUserId)
        {
            try
            {
                var oProductWarehouse = (from a in ctx.ProductWarehouse
                                         where a.WarehouseId == productWarehouseId && a.ProductId == productId
                                         select a).FirstOrDefault();

                if (oProductWarehouse == null)
                    return false;

                oProductWarehouse.UpdateUserId = systemUserId;
                oProductWarehouse.UpdateDate = DateTime.UtcNow;
                oProductWarehouse.IsDeleted = (int)Enumeratores.SiNo.Si;

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
