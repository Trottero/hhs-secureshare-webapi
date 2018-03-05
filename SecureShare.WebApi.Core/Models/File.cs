using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecureShare.WebApi.Core.Models
{
    public class File
    {
        [Key]
        public Guid FileId { get; set; }
    }
}
