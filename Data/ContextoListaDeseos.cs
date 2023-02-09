using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Examen.Models;

    public class ContextoListaDeseos : DbContext
    {
        public ContextoListaDeseos (DbContextOptions<ContextoListaDeseos> options)
            : base(options)
        {
        }

        public DbSet<Examen.Models.ListaDeseo> ListaDeseo { get; set; } = default!;
    }
