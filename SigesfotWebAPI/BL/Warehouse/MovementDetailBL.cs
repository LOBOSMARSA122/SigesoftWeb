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
                    //GesId =  new Utils().GetPrimaryKey(node usa),
                    r_StockMax = movementDetail.r_StockMax,
                    r_StockMin = movementDetail.r_StockMin,
                    i_MovementTypeId = movementDetail.i_MovementTypeId,
                    r_Quantity = movementDetail.r_Quantity,
                    r_Price = movementDetail.r_Price,
                    r_SubTotal = movementDetail.r_SubTotal,

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
        #region Bussines Logic
        public List<KeyValueDTO> Supplier()
        {
            try
            {
                var list = (from a in ctx.Supplier
                            select new KeyValueDTO
                            {
                                Id = a.v_SupplierId,
                                Value = a.v_Name
                            }
                            ).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<string> GetProductsString(string value)
        {
            try
            {
                var list = (from a in ctx.Product
                            where a.i_IsDeleted == 0 && a.v_Name.Contains(value)
                            select new 
                            {
                                v_Name = a.v_Name.ToUpper(),

                            }).ToList();
                
                       

                return list.Select(x => x.v_Name).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Products GetDataProduct(string ProductName)
        {
            try
            {
                int groupCategoryId = (int)Enumeratores.DataHierarchy.CategoryProd;
                var isDeleted = (int)Enumeratores.SiNo.No;
                var oDataProduct = (from a in ctx.Product
                                    join b in ctx.DataHierarchy on new { a = a.i_CategoryId.Value, b = groupCategoryId } equals new { a = b.i_ItemId, b = b.i_GroupId }
                                    where a.i_IsDeleted == isDeleted
                                  && (a.v_Name == ProductName) 
                            select new Products
                            {
                                ProductId = a.v_ProductId,
                                CategoryId = a.i_CategoryId,
                                Category = b.v_Value1,
                                Brand = a.v_Brand,
                                Model = a.v_Model,
                                ReferentialCostPrice = a.r_ReferentialCostPrice,
                            }).FirstOrDefault();


                return oDataProduct;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool MovementProductDataProcess(BoardMovementDataProcess data)
        {
            try
            {
                switch (data.RecordStatus)
                {
                    case (int)Enumeratores.RecordStatus.Agregar:
                        {
                            return SaveNewMovementProduct(data);
                        }
                        
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool SaveNewMovementProduct(BoardMovementDataProcess data)
        {
            
            try
            {
                foreach (var a in data.MovementProduct.FindAll(p => p.TotalQuantity.ToString() != null))
                {
                    MovementBE Movement = new MovementBE()
                    {

                        //v_Motive = a.MotiveTypeId,
                        //v_SupplierId = a.Supplier,
                        //d_Date = a.Date,
                        //v_ReferenceDocument = a.ReferenceDocument,
                        r_TotalQuantity = a.TotalQuantity,
                        d_UpdateDate = DateTime.UtcNow,

                    };
                    ctx.Movement.Add(Movement);
                    ctx.SaveChanges();
                };
                foreach (var b in data.MovementDetailProduct.FindAll(p => p.Price.ToString() != null))
                {
                    MovementDetailBE MovementDetail = new MovementDetailBE()
                    {
                        
                        d_UpdateDate= DateTime.UtcNow,
                        v_ProductId = b.ProductId,
                        r_Price = b.Price,
                    };
                    ctx.MovementDetail.Add(MovementDetail);
                }
                ctx.SaveChanges();

                ctx.Database.CurrentTransaction.Rollback();
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
