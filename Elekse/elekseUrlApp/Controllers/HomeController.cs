using elekseUrlApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Serialization;

namespace elekseUrlApp.Controllers
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


        #region Post
        //[HttpPost("shorten")]
        //public IActionResult ShortenUrl([FromBody] object longUrl)
        //{
        //    string longurl1 = longUrl.ToString();

        //    try
        //    {
        //        //Veritabanında bu uzun URL le ait kısa URL varsa, kısa URL'yi döndür.
        //        if (!string.IsNullOrEmpty(longurl1.Trim()))
        //        {
        //            var incomingurl = _context.Urls.FirstOrDefault(u => u.LongUrl == longurl1);
        //            if (incomingurl != null)
        //            {
        //                return Ok(incomingurl.ShortUrl);
        //            }

        //        }
        //        else
        //        if (string.IsNullOrEmpty(longurl1.Trim()))
        //        {
        //            return NotFound();
        //        }


        //        // Eğer yoksa, yeni bir kısa URL oluştur ve kaydet.
        //        string shortUrl = GetRandomUrl();
        //        while (_context.Urls.Any(x => x.ShortUrl == shortUrl))
        //        {
        //            shortUrl = GetRandomUrl();
        //        }
        //        Url data = new Url();
        //        data.LongUrl = longurl1;
        //        data.ShortUrl = shortUrl;
        //        _context.Urls.Add(data);
        //        _context.SaveChanges();
        //        return Ok("https://localhost:7115/api/Home/" + shortUrl);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest("Geçersiz veri veya işlem hatası: " + ex.Message);
        //    }




        //}
        #endregion





        [HttpGet("{shortUrl}")]
        public IActionResult RedirectToLongUrl(string shortUrl)
        {
            try
            {
                // Veritabanında bu kısa URL'ye ait uzun URL varsa, yönlendir.
                var entry = _context.Urls.FirstOrDefault(u => u.ShortUrl == shortUrl);
                if (entry != null)
                {
                    return Redirect(entry.LongUrl);
                }

                // Eğer yoksa, hata döndür. 
                return NotFound();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }











    }
}
