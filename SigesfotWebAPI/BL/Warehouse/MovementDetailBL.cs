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
                                v_ProductId = a.v_ProductId,
                                v_Name = a.v_Name.ToUpper(),
                                i_CategoryId = a.i_CategoryId,
                                v_Brand = a.v_Brand,
                                v_Model = a.v_Model,

                            }).ToList();
                
                       

                return list.Select(x => x.v_Name).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ProductBE GetDataProducts(string data)
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var oDataProduct = (from a in ctx.Product
                            where a.i_IsDeleted == isDeleted
                                  && (a.v_Name == data)
                            select new ProductBE
                            {
                                v_ProductId = a.v_ProductId,
                                i_CategoryId = a.i_CategoryId,
                                v_Brand = a.v_Brand,
                                v_Model = a.v_Model,
                            }).FirstOrDefault();


                return oDataProduct;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
