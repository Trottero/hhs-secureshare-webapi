using Microsoft.EntityFrameworkCore;

namespace SecureShare.WebAPI.Data
{
    public class SecureShareWebAPIContext : DbContext
    {
        public SecureShareWebAPIContext (DbContextOptions<SecureShareWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SecureShare.WebApi.Core.Models.File> File { get; set; }
    }
}
