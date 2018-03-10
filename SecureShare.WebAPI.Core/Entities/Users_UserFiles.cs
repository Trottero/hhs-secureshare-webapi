using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecureShare.WebAPI.Core.Entities
{
    public class Users_UserFiles : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PermissionId { get; set; }
        public Guid UserId { get; set; }
        public Guid UserFileId { get; set; }

        public User User { get; set; }
        public UserFile UserFile { get; set; }

        public DateTime ExpiringDate { get; set; }
    }
}
