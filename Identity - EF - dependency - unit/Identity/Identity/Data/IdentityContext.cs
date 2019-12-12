using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext (DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public DbSet<Identity.Models.Animals> Animals { get; set; }
    }
}
