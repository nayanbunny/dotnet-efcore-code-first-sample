﻿using DotNet.EFCore.CodeFirst.Sample.RazorApp.Data;
using DotNet.EFCore.CodeFirst.Sample.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNet.EFCore.CodeFirst.Sample.RazorApp.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public CreateModel(EFCoreCodeFirstDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Departments == null || Department == null)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
