using BE.Warehouse;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Warehouse
{
    public class ProductsForMigrationBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public bool AddProductsForMigration(ProductsForMigrationBE productsForMigration, int systemUserId)
        {
            try
            {
                ProductsForMigrationBE oProductsForMigrationBE = new ProductsForMigrationBE()
                {
                    //ProductsForMigrationId =  new Utils().GetPrimaryKey(no usa),
                    WarehouseId = productsForMigration.WarehouseId,
                    ProductId = productsForMigration.ProductId,
                    CategoryId = productsForMigration.CategoryId,
                    Name = productsForMigration.Name,
                    StockMin = productsForMigration.StockMin,
                    StockMax = productsForMigration.StockMax,
                    StockActual = productsForMigration.StockActual,
                    MovementTypeId = productsForMigration.MovementTypeId,
                    MovementType = productsForMigration.MovementType,
                    MotiveTypeId = productsForMigration.MotiveTypeId,
                    MotiveType = productsForMigration.MotiveType,
                    MovementDate = productsForMigration.MovementDate,

                    //Auditoria
                    InsertDate = DateTime.UtcNow,

                };

                ctx.ProductsForMigration.Add(oProductsForMigrationBE);

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
