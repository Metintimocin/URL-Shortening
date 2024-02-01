using elekseUrlApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Serialization;

namespace elekseUrlApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("longUrl")]
        public IActionResult ShortenUrl([FromBody] object longUrl)
        {

            try
            {

                string longurl1 = longUrl.ToString();


                if (string.IsNullOrEmpty(longurl1.Trim()))
                {
                    return NotFound();
                }
                else
                    if (!string.IsNullOrEmpty(longurl1.Trim()))
                {
                    string newUrl = longurl1.Replace(" ", "");
                    string shortUrl = GetRandomUrl();
                    while (_context.Urls.Any(x => x.ShortUrl == shortUrl))
                    {
                        shortUrl = GetRandomUrl();
                    }
                    Url data = new Url();
                    data.LongUrl = newUrl;
                    data.ShortUrl = shortUrl;
                    _context.Urls.Add(data);
                    _context.SaveChanges();
                    return Ok("https://localhost:7115/" + shortUrl);
                }


                return NotFound();


            }
            catch (Exception ex)
            {

                return BadRequest("Geçersiz veri veya işlem hatası: " + ex.Message);
            }




        }
        private string GetRandomUrl()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var shortUrl = new string(
                Enumerable.Repeat(characters, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return shortUrl;
        }


    }
}
