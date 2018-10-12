using BE.Warehouse;
using BL.Common;
using BL.Warehouse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SigesoftWebAPI.Controllers.Warehouse
{
    public class ProductController : ApiController
    {
        private ProductBL oProductBL = new ProductBL();

        [HttpPost]
        public IHttpActionResult GetBoardProduct(BoardProduct data)
        {
            var result = oProductBL.GetAllProducts(data);
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetProductById(string productId)
        {
            var result = oProductBL.GetProductById(productId);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult AddProduct(MultiDataModel data)
        {
            Products product = JsonConvert.DeserializeObject<Products>(data.String1);
            bool result = oProductBL.AddProduct(product, data.Int1);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult EditProducts(MultiDataModel data)
        {
            Products product = JsonConvert.DeserializeObject<Products>(data.String1);
            bool result = oProductBL.EditProduct(product, data.Int1);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult DeleteProduct(MultiDataModel data)
        {
            bool result = oProductBL.DeleteProduct(data.String1, data.Int2);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult BandejaReporteProducto(BoardProduct data)
        {
            var result = oProductBL.BandejaReporteProducto(data);
            return Ok(result);
        }

    }
}