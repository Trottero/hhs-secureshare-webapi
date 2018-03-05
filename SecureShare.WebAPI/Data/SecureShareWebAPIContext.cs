using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecureShare.WebApi.Core.Models;

    public class SecureShareWebAPIContext : DbContext
    {
        public SecureShareWebAPIContext (DbContextOptions<SecureShareWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SecureShare.WebApi.Core.Models.File> File { get; set; }
    }
