using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<BucketList> BucketLists { get; set; }
        public DbSet<Item> Items { get; set; }
    }

}
