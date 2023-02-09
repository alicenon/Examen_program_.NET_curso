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
    public class DetailsModel : PageModel
    {
        private readonly ContextoListaDeseos _context;

        public DetailsModel(ContextoListaDeseos context)
        {
            _context = context;
        }

      public ListaDeseo ListaDeseo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ListaDeseo == null)
            {
                return NotFound();
            }

            var listadeseo = await _context.ListaDeseo.FirstOrDefaultAsync(m => m.Id == id);
            if (listadeseo == null)
            {
                return NotFound();
            }
            else 
            {
                ListaDeseo = listadeseo;
            }
            return Page();
        }
    }
}
