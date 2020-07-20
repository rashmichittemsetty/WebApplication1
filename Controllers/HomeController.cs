using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using MimeKit;
using WebApplication1.Models;
using WebApplication1.Repository;
//using SmtpClient = System.Net.Mail.SmtpClient;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _userRepository;
        private IHostingEnvironment _hostingEnvironment;

        public HomeController(IRepository userRepository)
        {
            _userRepository = userRepository;
            
        }
        public IActionResult Index()
        {          
            return View();
        }

        public IActionResult Create()
        {
            return View();
           
        }       
        
 
        [HttpPost]
        public IActionResult Create(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                var messsage = new MimeMessage();
                Random random = new Random();
                String number = random.Next(0, 999999).ToString("D6");

                messsage.From.Add(new MailboxAddress("Test Address", "rashmichittemsetty@gmail.com"));
                messsage.To.Add(new MailboxAddress("Test", "rashmichittemsetty@gmail.com"));
                messsage.Subject = "testmail";
                messsage.Body = new TextPart("plain")
                {
                    //"Dear " + signUpModel.Email + ", <br /><br /> '" + number + "' is the password to Register  <br /><br /> Thanks & Regards, <br />Rashmi";

                    Text = "Dear " + userDetails.Name + ", <br /><br /> '" + number + "' is the password to Register  <br /><br /> Thanks & Regards, <br />Rashmi"
                };
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("", "");
                    client.Send(messsage);
                    client.Disconnect(true);

                }
                return RedirectToAction("about", "home");
            }
            return View();
        }
                

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
            

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
