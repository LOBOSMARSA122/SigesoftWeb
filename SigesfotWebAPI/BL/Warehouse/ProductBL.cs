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
    public class ProductBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ProductBE GetProduct(string productId)
        {
            try
            {
                var objEntity = (from a in ctx.Product
                                 where a.ProductId == productId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ProductBE> GetAllProduct()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Product
                                 where a.IsDeleted == isDelete
                                 select new ProductBE()
                                 {
                                     ProductId = a.ProductId,
                                     CategoryId = a.CategoryId,
                                     Name = a.Name,
                                     GenericName = a.GenericName,
                                     BarCode = a.BarCode,
                                     ProductCode = a.ProductCode,
                                     Brand = a.Brand,
                                     Model = a.Model,
                                     SerialNumber = a.SerialNumber,
                                     ExpirationDate = a.ExpirationDate,
                                     MeasurementUnitId = a.MeasurementUnitId,
                                     ReferentialCostPrice = a.ReferentialCostPrice,
                                     ReferentialSalesPrice = a.ReferentialSalesPrice,
                                     Presentation = a.Presentation,
                                     AdditionalInformation = a.AdditionalInformation,
                                     Image = a.Image,
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

        public bool AddProduct(ProductBE product, int systemUserId)
        {
            try
            {
                ProductBE oProductBE = new ProductBE()
                {
                    ProductId = BE.Utils.GetPrimaryKey(1, 6, "PI"),
                    CategoryId = product.CategoryId,
                    Name = product.Name,
                    GenericName = product.GenericName,
                    BarCode = product.BarCode,
                    ProductCode = product.ProductCode,
                    Brand = product.Brand,
                    Model = product.Model,
                    SerialNumber = product.SerialNumber,
                    ExpirationDate = product.ExpirationDate,
                    MeasurementUnitId = product.MeasurementUnitId,
                    ReferentialCostPrice = product.ReferentialCostPrice,
                    ReferentialSalesPrice = product.ReferentialSalesPrice,
                    Presentation = product.Presentation,
                    AdditionalInformation = product.AdditionalInformation,
                    Image = product.Image,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Product.Add(oProductBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProduct(ProductBE product, int systemUserId)
        {
            try
            {
                var oProduct = (from a in ctx.Product
                            where a.ProductId == product.ProductId
                                select a).FirstOrDefault();

                if (oProduct == null)
                    return false;

                oProduct.CategoryId = product.CategoryId;
                oProduct.Name = product.Name;
                oProduct.GenericName = product.GenericName;
                oProduct.BarCode = product.BarCode;
                oProduct.ProductCode = product.ProductCode;
                oProduct.Brand = product.Brand;
                oProduct.Model = product.Model;
                oProduct.SerialNumber = product.SerialNumber;
                oProduct.ExpirationDate = product.ExpirationDate;
                oProduct.MeasurementUnitId = product.MeasurementUnitId;
                oProduct.ReferentialCostPrice = product.ReferentialCostPrice;
                oProduct.ReferentialSalesPrice = product.ReferentialSalesPrice;
                oProduct.Presentation = product.Presentation;
                oProduct.AdditionalInformation = product.AdditionalInformation;
                oProduct.Image = product.Image;

                //Auditoria

                oProduct.UpdateDate = DateTime.UtcNow;
                oProduct.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProducts(string productId, int systemUserId)
        {
            try
            {
                var oProduct = (from a in ctx.Product
                            where a.ProductId == productId
                            select a).FirstOrDefault();

                if (oProduct == null)
                    return false;

                oProduct.UpdateUserId = systemUserId;
                oProduct.UpdateDate = DateTime.UtcNow;
                oProduct.IsDeleted = (int)Enumeratores.SiNo.Si;

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
