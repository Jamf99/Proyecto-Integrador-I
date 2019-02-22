using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EzParty.Models
{
    public class EzPartyContext : DbContext
    {
        public EzPartyContext (DbContextOptions<EzPartyContext> options)
            : base(options)
        {
        }

        public DbSet<EzParty.Models.Party> Party { get; set; }
    }
}
