using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_Loader.Models
{
    public class ImageContext : DbContext
    {
        public ImageContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Image> images { get; set; }
    }
}
