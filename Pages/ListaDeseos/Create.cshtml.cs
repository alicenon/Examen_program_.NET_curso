using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Examen.Models;

namespace Examen.Pages.ListaDeseos
{
    public class CreateModel : PageModel
    {
        private readonly ContextoListaDeseos _context;

        public CreateModel(ContextoListaDeseos context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ListaDeseo ListaDeseo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ListaDeseo == null || ListaDeseo == null)
            {
                return Page();
            }

            _context.ListaDeseo.Add(ListaDeseo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
