using Abi.Abstractions;
using Abi.Contexts;
using Abi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Abi.Controllers
{
    public class HomeController(AppDbContext _context,IEmailService _emailService) : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public async Task<IActionResult> Test()
        {
            await _emailService.SendEmailAsync("azimovseyidakif7@gmail.com", "Test Email", "<h1>This is a test email from ProniaWebSeyid</h1>");
            return Ok("OK");
        }
    }
}
