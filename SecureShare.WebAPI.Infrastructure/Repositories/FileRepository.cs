using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using SecureShare.WebApi.Core.Models;
using SecureShare.WebAPI.Core.Interfaces;
using SecureShare.WebAPI.Data;

namespace SecureShare.WebAPI.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly SecureShareWebAPIContext _context;

        public FileRepository(SecureShareWebAPIContext context)
        {
            _context = context;
        }

        public IEnumerable<File> GetAll()
        {
            return _context.File;
        }

        public Task<File> GetById(Guid id)
        {
            return _context.File.FindAsync(id);
        }

        public async Task DeleteById(Guid id)
        {
            _context.File.Remove(await _context.File.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(File file)
        {
            await _context.AddAsync(file);
            await _context.SaveChangesAsync();
        }
    }
}
