using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAI.Data;

namespace CAI.Controllers
{
    public class ProductsController : Controller
    {
        //Get :/Products/
        private ProductRepository _repository = new ProductRepository();

        //return a category of products
        public ActionResult  Index(string category )
        {
            //stock a collection of products
            IEnumerable<Product> products;

            products = !string.IsNullOrEmpty(category) ?
                _repository.GetByCategory(category) : _repository.GetAll();

             if(!products.Any())
                {
                    return HttpNotFound();
                 }

            return View(products);
        }

        //
        public Action Details(int productId) 
        {

            var product = _repository.GetById(productId);

            if (product == null)
            {

                return HttpNotFound();
            }

            return View(product);

        }


    }
}