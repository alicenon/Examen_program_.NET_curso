using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen.Models;

namespace Examen.Pages.ListaDeseos
{
    public class EditModel : PageModel
    {
        private readonly ContextoListaDeseos _context;

        public EditModel(ContextoListaDeseos context)
        {
            _context = context;
        }

        [BindProperty]
        public ListaDeseo ListaDeseo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ListaDeseo == null)
            {
                return NotFound();
            }

            var listadeseo =  await _context.ListaDeseo.FirstOrDefaultAsync(m => m.Id == id);
            if (listadeseo == null)
            {
                return NotFound();
            }
            ListaDeseo = listadeseo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ListaDeseo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaDeseoExists(ListaDeseo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ListaDeseoExists(int id)
        {
          return (_context.ListaDeseo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
