﻿using DotNet.EFCore.CodeFirst.Sample.RazorApp.Data;
using DotNet.EFCore.CodeFirst.Sample.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.CodeFirst.Sample.RazorApp.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public EditModel(EFCoreCodeFirstDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department =  await _context.Departments.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            Department = department;
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

            _context.Attach(Department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(Department.Id))
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

        private bool DepartmentExists(Guid id)
        {
          return (_context.Departments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
