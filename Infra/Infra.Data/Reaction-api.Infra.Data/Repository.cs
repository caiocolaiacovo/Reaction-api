using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Reaction_api.Domain;

namespace Reaction_api.Infra.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;

        public DbSet<T> _entidades { get; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entidades = context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _entidades;
        }
    }
}