using Image_Loader.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Image_Loader.Models
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public string Name { get; set; }
        public string ImageData { get; set; }
    }
}
