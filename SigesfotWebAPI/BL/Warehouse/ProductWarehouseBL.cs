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


        #region BL

        public BoardProductWarehouse GetAllProductsWarehouse(BoardProductWarehouse data)
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                int groupCategoryId = (int)Enumeratores.DataHierarchy.CategoryProd;
                int skip = (data.Index - 1) * data.Take;

                var filterWarehouseId = data.WarehouseId == null ? "-1" : data.WarehouseId;
                var filterCategoryId = data.CategoryId == null ? -1 : data.CategoryId;
                string filterProductCode = string.IsNullOrWhiteSpace(data.ProductCode) ? "" : data.ProductCode;
                string filterName = string.IsNullOrWhiteSpace(data.Name) ? "" : data.Name;

                var list = (from a in ctx.Product
                            join b in ctx.DataHierarchy on new { a = a.i_CategoryId.Value, b = groupCategoryId } equals new { a = b.i_ItemId, b = b.i_GroupId }
                            join c in ctx.ProductWarehouse on a.v_ProductId equals c.v_ProductId           
                            where a.i_IsDeleted == isDeleted && (a.v_ProductCode.Contains(filterProductCode))
                                  && (a.v_Name.Contains(filterName)
                                  && (data.WarehouseId == "-1" || c.v_WarehouseId == filterWarehouseId)) 
                                  && (data.CategoryId == -1 || a.i_CategoryId == filterCategoryId)

                            select new ProductWarehouse
                            {
                                StockActual = c.r_StockActual,
                                ProductName = a.v_Name,
                                Category = b.v_Value1,
                                
                                
                            }).ToList();
                 int totalRecords = list.Count;

                if (data.Take > 0)
                    list = list.Skip(skip).Take(data.Take).ToList();

                data.TotalRecords = totalRecords;
                data.List = list;

                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        } 


        //public ProductWarehouse GetProductWarehouseById(string productId)
        //{
        //    try
        //    {
        //        var isDeleted = (int)Enumeratores.SiNo.No;

        //        var data = (from a in ctx.ProductWarehouse
        //                    join b in ctx.Product on a.v_ProductId equals b.v_ProductId
        //                    where b.i_IsDeleted == isDeleted
        //                    select new ProductWarehouse()
        //                    {
        //                        ProductId = a.v_ProductId,
        //                        StockActual = a.r_StockActual,
        //                    }).FirstOrDefault();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public List<KeyValueDTO> GetJoinOrganizationAndLocationNotInRestricted(int nodeId)
        {
            //mon.IsActive = true;
            try
            {

                var query = (from n in ctx.Node
                             join a in ctx.NodeOrganizationLocationProfile on n.i_NodeId.Value equals a.i_NodeId.Value
                             join J1 in ctx.NodeOrganizationProfile on new { a = a.i_NodeId.Value, b = a.v_OrganizationId }
                                                      equals new { a = J1.i_NodeId.Value, b = J1.v_OrganizationId } into j1_join
                             from J1 in j1_join.DefaultIfEmpty()
                             join J2 in ctx.NodeOrganizationLocationWarehouseProfile on new { a = a.i_NodeId.Value, b = a.v_OrganizationId, c = a.v_LocationId }
                                                      equals new { a = J2.i_NodeId.Value, b = J2.v_OrganizationId, c = J2.v_LocationId } into j2_join
                             from J2 in j2_join.DefaultIfEmpty()
                             join b in ctx.Organization on J1.v_OrganizationId equals b.v_OrganizationId
                             join c in ctx.Location on a.v_LocationId equals c.v_LocationId
                             where n.i_NodeId.Value == nodeId &&
                                   n.i_IsDeleted == 0 &&
                                   a.i_IsDeleted == 0 &&
                                   J2.i_IsDeleted == 0
                             select new RestrictedWarehouseProfileListBE
                             {
                                 OrganizationName = b.v_Name,
                                 LocationName = c.v_Name,
                                 LocationId = c.v_LocationId,
                                 OrganizationId = b.v_OrganizationId,
                                 NodeId = J1.i_NodeId.Value
                             }
                          ).Distinct();

                var q = from a in query.ToList()
                        select new KeyValueDTO
                        {
                            Id = string.Format("{0}|{1}|{2}", a.NodeId, a.OrganizationId, a.LocationId),
                            Value = string.Format("Empresa: {0} / Sede: {1} ",
                                     a.OrganizationName,
                                     a.LocationName)
                        };



                List<KeyValueDTO> WarehouseList = q.OrderBy(p => p.Value).ToList();
                return WarehouseList;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<KeyValueDTO> GetWarehouseNotInRestricted(int nodeId, string OrganizationId, string LocationId)
        {
            

            try
            {

                var query = (from a in ctx.NodeOrganizationLocationWarehouseProfile
                             join b in ctx.Warehouse on a.v_WarehouseId equals b.v_WarehouseId
                             where a.i_NodeId == nodeId &&
                                   a.v_OrganizationId == OrganizationId &&
                                   a.v_LocationId == LocationId &&
                                   a.i_IsDeleted == 0
                             select new KeyValueDTO
                             {
                                 Id = a.v_WarehouseId,
                                 Value = b.v_Name
                             });

                // Excluir almacenes restringidos
                var queryNotIn = (from a in query.ToList()
                                  where !(from r in ctx.RestrictedWarehouseProfile
                                          where r.i_IsDeleted == 0
                                          select r.v_WarehouseId).Contains(a.Id)
                                  select a);

                List<KeyValueDTO> WarehouseList = queryNotIn.OrderBy(p => p.Value).ToList();

                return WarehouseList;
            }
            catch (Exception ex)
            {

                return null;
            }
        }



        #endregion
        #region CRUD
        public ProductWarehouseBE GetProductWarehouse(string productWarehouseId, string productId)
        {
            try
            {
                var objEntity = (from a in ctx.ProductWarehouse
                                 join b in ctx.Product on a.v_ProductId equals b.v_ProductId
                                 where a.v_WarehouseId == productWarehouseId && a.v_ProductId == productId
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
                                 join b in ctx.Product on a.v_ProductId equals b.v_ProductId
                                 where b.i_IsDeleted == isDelete
                                 select new ProductWarehouseBE()
                                 {
                                     v_WarehouseId = a.v_WarehouseId,
                                     v_ProductId = a.v_ProductId,
                                     r_StockMin = a.r_StockMin,
                                     r_StockMax = a.r_StockMax,
                                     r_StockActual = a.r_StockActual,
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

        public bool AddProductWarehouse(ProductWarehouseBE productWarehouse, int systemUserId)
        {
            try
            {
                ProductWarehouseBE oProductWarehouseBE = new ProductWarehouseBE()
                {
                    //ProductWarehouseId =  new Utils().GetPrimaryKey(no usa),
                    //ProductId = productWarehouse.ProductId (llave compuesta),
                    r_StockMin = productWarehouse.r_StockMin,
                    r_StockMax = productWarehouse.r_StockMax,
                    r_StockActual = productWarehouse.r_StockActual,

                    //Auditoria
                    //IsDeleted = (int)Enumeratores.SiNo.No,
                    d_InsertDate = DateTime.UtcNow,
                    i_InsertUserId = systemUserId,
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
        #endregion
    }
}
