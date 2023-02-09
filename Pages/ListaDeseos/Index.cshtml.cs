using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Models;

namespace Examen.Pages.ListaDeseos
{
    public class IndexModel : PageModel
    {
        private readonly ContextoListaDeseos _context;

        public IndexModel(ContextoListaDeseos context)
        {
            _context = context;
        }

        public IList<ListaDeseo> ListaDeseo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ListaDeseo != null)
            {
                ListaDeseo = await _context.ListaDeseo.ToListAsync();
            }
        }
    }
}
