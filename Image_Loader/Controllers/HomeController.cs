using Image_Loader.Data;
using Image_Loader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Image_Loader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IRepository<Image> repository;

        public HomeController(IRepository<Image> repository)
        {
            this.repository = repository;
        }


        [Route("Images")]
        [HttpGet]
        public async Task<List<Image>> Get()
        {
            return await repository.GetAll();
        }

        [Route("Upload")]
        [HttpPost]
        public async Task<Image> Upload()
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            
            Image image = new Image();
            image.Name = file.FileName;
            
            
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            
            image.ImageData = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray(), 0, Convert.ToInt32(ms.Length));
            
            ms.Close();
            ms.Dispose();

            await repository.Add(image);
            return image;
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<Image> Delete(int id)
        {
            return await repository.Delete(id);
        }
    }
}
