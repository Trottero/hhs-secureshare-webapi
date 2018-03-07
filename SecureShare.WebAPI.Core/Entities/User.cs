using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecureShare.WebAPI.Core.Entities
{
    public class User : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }

        //public IEnumerable<UserFile> Files { get; set; }
        public ICollection<Users_UserFiles> FilesSharedWithUser { get; set; }
    }
}
