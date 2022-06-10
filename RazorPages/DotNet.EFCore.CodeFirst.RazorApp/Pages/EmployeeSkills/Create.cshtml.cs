﻿using DotNet.EFCore.CodeFirst.RazorApp.Data;
using DotNet.EFCore.CodeFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet.EFCore.CodeFirst.RazorApp.Pages.EmployeeSkills
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
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
        ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public EmployeeSkill EmployeeSkill { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.EmployeeSkills == null || EmployeeSkill == null)
            {
                return Page();
            }

            _context.EmployeeSkills.Add(EmployeeSkill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
