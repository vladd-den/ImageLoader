using Image_Loader.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_Loader.Models
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly ImageContext _context;
        public ImageRepository(ImageContext context)
        {
            _context = context;
        }

        public async Task<List<Image>> GetAll()
        {
            return await _context.images.ToListAsync();
        }

        public async Task<Image> Add(Image image)
        {
            await _context.images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> Delete(int id)
        {
            var image = await _context.images.FindAsync(id);
             _context.images.Remove(image);
             await _context.SaveChangesAsync();
            return image;
        }
    }
}
