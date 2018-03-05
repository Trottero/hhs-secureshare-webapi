using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SecureShare.WebAPI.Core.Models;

namespace SecureShare.WebApi.Core.Models
{
    public class File
    {
        [Key]
        public Guid FileGuid { get; set; }
        public string FileName { get; set; }
        public DateTime UploadTime { get; set; }
        public DateTime DownloadTime { get; set; }
        public string Description { get; set; }
        public Guid OwnerGuid { get; set; }
        public User Owner { get; set; }
    }
}
