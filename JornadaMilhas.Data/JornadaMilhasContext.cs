using JornadaMilhas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Data
{
    public class JornadaMilhasContext : DbContext
    {
        public JornadaMilhasContext(DbContextOptions opt) : base(opt)
        { }

        public DbSet<Depoimento> Depoimentos { get; set; }
        public DbSet<Destino> Destinos { get; set; }
    }
}
