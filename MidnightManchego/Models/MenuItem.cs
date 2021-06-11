using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Midnight_Manchego.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string SubMenu { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Price { get; set; }

        // ImageStream is for inserting image into database
        public string ImageStream { get; set; }

        // ImageFile is for uploading images from view
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        // Convert IFormFIle ImageFile to a data-string as string ImageStream
        public async void ConvertStream()
        {
            using (var ms = new MemoryStream())
            {
                
                var fileType = ImageFile.ContentType;
                await ImageFile.CopyToAsync(ms);
                var msArray = ms.ToArray();
                ImageStream = "data:" + fileType + ";base64," + Convert.ToBase64String(msArray, 0, msArray.Length);
            }
        }
    }

    


}
