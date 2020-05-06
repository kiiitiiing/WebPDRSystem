using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Data;
using WebPDRSystem.Models;

namespace WebPDRSystem.Controllers
{
    public class HelperController : Controller
    {
        private readonly WebPDRContext _context;

        public HelperController(WebPDRContext context)
        {
            _context = context;
        }

        [Route("helper/picture")]
        [HttpPost]
        public void SetPicture([FromBody]Picture picture)
        {
            var pdr = _context.Pdr
                .Include(x=>x.PatientNavigation)
                //.Where(x => x.BedNumber == picture.Id)
                .FirstOrDefault();


            if(pdr != null)
            {
                pdr.PatientNavigation.Picture = SavePicture(picture, pdr);
                _context.Update(pdr);
                _context.SaveChanges();
            }
        }

        public static string SavePicture(Picture picture, Pdr pdr)
        {
            string name = pdr.PatientNavigation.Firstname + pdr.PatientNavigation.Middlename + pdr.PatientNavigation.Lastname;
            string imageName = Guid.NewGuid() + name + ".jpg";
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "pdrs", imageName);

            string cleanData = picture.PhotoString.Replace("data:image/jpeg;base64,", "");
            byte[] data = Convert.FromBase64String(cleanData);
            MemoryStream ms = new MemoryStream(data);
            Image img = Image.FromStream(ms);
            img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            return imageName;
        }

        [Route("helper/barangays/{province}/{muncity}")]
        public async Task<List<Barangay>> GetBarangays(int province, int muncity)
        {
            var barangays = _context.Barangay.Where(x => x.ProvinceId == province && x.MuncityId == muncity);

            return await barangays.ToListAsync();
        }

        [Route("helper/muncities/{province}")]
        public async Task<List<Muncity>> GetMuncities(int province)
        {
            var muncities = _context.Muncity.Where(x => x.ProvinceId == province);

            return await muncities.ToListAsync();
        }
    }
}