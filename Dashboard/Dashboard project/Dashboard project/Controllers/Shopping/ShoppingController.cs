using Dashboard_project.Data;
using Dashboard_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using MailKit.Security;
using Microsoft.AspNetCore.Html;
using Humanizer;

namespace Dashboard_project.Controllers.Shopping
{
    public class ShoppingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public string CostumerId { get; private set; }

        public ShoppingController(ApplicationDbContext context)
        {
            _context = context;
        }
	
	public IActionResult Index()
        {
            var product = _context.ProductDetails.ToList();
            return View(product);
        }





		public async Task<string> SendMail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test ", ""));
            message.To.Add(MailboxAddress.Parse(""));
            message.Subject = "test message email";
            message.Body = new TextPart("<p> first message </p> ");

            using (var clint = new SmtpClient())

                try
                {
                    clint.Connect("smtp.gmail.com", 587);
                    clint.Authenticate("", "");
                    await clint.SendAsync(message);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    clint.Disconnect(true);

                }





            return "ok";

        }


        public IActionResult ProductDetails(int id)
        {

            var ProductDetails = _context.ProductDetails.Where(p => p.Id == id).ToList();
            return View(ProductDetails);
        }




        [Authorize]
        public IActionResult Checkout(int id)
        {
            var user = HttpContext.User.Identity.Name;
            var productDetails = _context.ProductDetails.SingleOrDefault(p => p.Id == id);
            var Cart = new carts()
            {
                IdCostumer = user,
                MyProductId = productDetails.ProductId,
                Color = productDetails.color,
                Price = productDetails.Price,
                Total = productDetails.Price * (15 / 100) + productDetails.Price,
                ProductName = productDetails.ProductName,
                Image = productDetails.Image,
                Qty = productDetails.Qty,
                Capacity = productDetails.Capacity,




            };
            _context.carts.Add(Cart);
            _context.SaveChanges();
            return View(Cart);
        }




public async Task<IActionResult> Invoice(int id)
        {
            var user = HttpContext.User.Identity.Name;
            var cartsinvoice = _context.carts.SingleOrDefault(x => x.Id == id);
            var invoice = new Invoice()
            {
                CostumerId = user,
                ProductId = cartsinvoice.MyProductId,
                Color = cartsinvoice.Color,
                Price = cartsinvoice.Price,
                ProductName = cartsinvoice.ProductName,
                Capacity = cartsinvoice.Capacity,
                Total = cartsinvoice.Total,
                DateTime= DateTime.Now,
            };
            _context.Invoice.Add(invoice);
            _context.SaveChanges();


            var emailContent = "<html>" +
                      "<body>" +
                      "<h4>Thank You For Ordering From Our Store </h4>" +
                      "<h5>Your Order Details:</h5>" +
                      "<li >Product Name: "    + invoice.ProductName + "</li>" +
                      "<li>Price:   "   + invoice.Price + "SAR"+ "</li>" +
                      "<li>Order Date:    "   + invoice.DateTime + "</li>" +
                      "</ul>"+
                      "</body>" +
                      "</html>";

            await SendEmailToUser(user, "Order Details", emailContent);
            
            return View(invoice);

    }

    public async Task SendEmailToUser(string userEmail, string subject, string content)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Amira", "")); 
            message.To.Add(new MailboxAddress("", userEmail)); 
            message.Subject = subject;
            {
                message.Body = new TextPart("html")
                {
                    Text = content
                };

            };

            var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls); 
            await smtpClient.AuthenticateAsync("", "");

            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);


        }

    }

}