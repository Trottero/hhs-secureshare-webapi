﻿using System;

namespace SecureShare.WebAPI.Core.Entities
{
    public class UserFile: Entity
    {
        [Key]
        public Guid UserFileId { get; set; }
    }
}
