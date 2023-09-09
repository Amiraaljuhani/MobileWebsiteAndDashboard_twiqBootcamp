using Dashboard_project.Data;
using Dashboard_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dashboard_project.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext context;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }

		//add
		public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
		public IActionResult CreatNewProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //delet
        public IActionResult Delete( int id)
        {
            var product=context.Products.SingleOrDefault(p => p.Id == id);  
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();

			}
			return RedirectToAction("Index");

		}

        
		public IActionResult DeletFromDetails(int id)
		{
			var product = context.ProductDetails.SingleOrDefault(p => p.Id == id);
			if (product != null)
			{
				context.ProductDetails.Remove(product);
				context.SaveChanges();

			}
			return RedirectToAction("ProductDetails");

		}
		//edit UpdateProducts
		public ActionResult Edit(int id) 
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);
            return View(product);

        }
        public ActionResult UpdateProducts(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");

        }


		//edit UpdateProducts
		public ActionResult EditFromDetails(int id)
		{
			var product = context.ProductDetails.SingleOrDefault(p => p.Id == id);
			return View(product);
		}

		[HttpPost]
		public ActionResult UpdateProductsDetails(ProductDetails product)
		{
			var existingProduct = context.ProductDetails.SingleOrDefault(p => p.Id == product.Id);

			if (existingProduct != null)
			{
				existingProduct.ProductName = product.ProductName;
				existingProduct.Price = product.Price;
				existingProduct.Model = product.Model;
				existingProduct.Qty = product.Qty;
				existingProduct.Deisplay = product.Deisplay;
				existingProduct.color = product.color;
				existingProduct.Image = product.Image;
				existingProduct.Capacity = product.Capacity;
				existingProduct.MoreDetails = product.MoreDetails;

				context.ProductDetails.Update(existingProduct);
				context.SaveChanges();
			}

			return RedirectToAction("ProductDetails");
		}

		[Authorize]
        public IActionResult Index()
        {
            var FirstName = HttpContext.User.Identity.Name; //Mangment state (http)
            //CookieOptions options=new CookieOptions(); //Mangment state (cookie)
            //options.Expires = DateTime.Now.AddMinutes(15);  
            //Response.Cookies.Append("FirstName", FirstName, options);
            //HttpContext.Session.SetString("FirstName", FirstName);//session
			ViewBag.FirstName = FirstName;
            var proudct=context.Products.ToList();   
            return View(proudct);
        }
        [HttpPost]
        public IActionResult Index(string ProductName)
        {
            var product =context.Products.Where(x => x.ProductName.Contains(ProductName)).ToList();

			return View(product);
        }


		public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            //ViewBag.FirstName = Request.Cookies["FirstName"];
            //ViewBag.FirstName = HttpContext.Session.GetString("FirstName"); //session
			var proudct =context.Products.ToList();
            var ProductDetails=context.ProductDetails.ToList();
            ViewBag.ProductDetails = ProductDetails;
			return View(proudct);
        }

		//page product details
		public IActionResult AddProductDetails(ProductDetails productDetails)
		{
			context.ProductDetails.Add(productDetails);
			context.SaveChanges();
			return RedirectToAction("ProductDetails");
		}

        //select  in product details page

        [HttpPost]
		public IActionResult ProductDetails(int id)
		{
			var ProductDetails = context.ProductDetails.Where(p => p.ProductId == id).ToList();
			var product = context.Products.ToList();
			ViewBag.ProductDetails = ProductDetails;
			return View(product);
		}

        public IActionResult PaymentAccept()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PaymentAccept(PaymentAccept paymentAccept)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}