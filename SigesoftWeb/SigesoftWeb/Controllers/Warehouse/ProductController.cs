using Newtonsoft.Json;
using SigesoftWeb.Controllers.Security;
using SigesoftWeb.Models;
using SigesoftWeb.Models.Warehouse;
using SigesoftWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWeb.Controllers.Warehouse
{
    public class ProductController : Controller
    {
        [GeneralSecurity(Rol = "Product-BoardProduct")]
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult FilterProduct(BoardProduct data)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "ProductCode",data.ProductCode.ToString()},
                { "Name", data.Name.ToString()},
                { "Index", data.Index.ToString()},
                { "Take", data.Take.ToString()}
            };
            ViewBag.Products = API.Post<BoardProduct>("Product/GetBoardProduct", arg);
            return PartialView("_BoardProductsPartial");
        }

        [GeneralSecurity(Rol = "Product-CreateProduct")]
        public ActionResult CreateProduct(string id)
        {
            Api API = new Api();
            ViewBag.Product = API.Get<Products>("Product/GetProductById", new Dictionary<string, string> { { "productId", id } });
            return View();
        }

        [GeneralSecurity(Rol = "Product-CreateProduct")]
        public ActionResult Product()
        {
            ViewBag.Product = new BoardProduct() { List = new List<Products>(), Take = 10 };
            return View();
        }

        [GeneralSecurity(Rol = "Product-CreateProduct")]
        public JsonResult DeleteProduct(string id)
        {
            Api API = new Api();
            Dictionary<string, string> args = new Dictionary<string, string>
            {
                { "String1", id.ToString() },
                { "Int2", ViewBag.USER.SystemUserId.ToString() }
            };
            bool response = API.Post<bool>("Product/DeleteProduct", args);
            return Json(response);
        }

        [GeneralSecurity(Rol = "Product-CreateProduct")]
        public JsonResult EditProduct(Products data)
        {
            Api API = new Api();
            Dictionary<string, string> args = new Dictionary<string, string>
            {
                { "String1", JsonConvert.SerializeObject(data) },
                { "Int1", ViewBag.USER.SystemUserId.ToString() }
            };
            bool response = API.Post<bool>("Product/EditProducts", args);
            return Json(response);
        }

        [GeneralSecurity(Rol = "Product-CreateProduct")]
        public JsonResult AddProduct(Products product)
        {
            Api API = new Api();
            Dictionary<string, string> args = new Dictionary<string, string>
            {
                { "String1", JsonConvert.SerializeObject(product) },
                { "Int1", ViewBag.USER.SystemUserId.ToString() }
            };
            bool response = API.Post<bool>("Product/AddProduct", args);
            return Json(response);
        }
    }

}