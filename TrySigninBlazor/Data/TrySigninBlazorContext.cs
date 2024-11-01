using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrySigninBlazor.Data
{
    public class TrySigninBlazorContext : DbContext
    {
        public TrySigninBlazorContext (DbContextOptions<TrySigninBlazorContext> options)
            : base(options)
        {
        }

        public DbSet<TrySigninBlazor.Data.Post> Post { get; set; } = default!;
    }
}
