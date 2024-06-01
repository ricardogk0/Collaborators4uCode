using CollaboratorsCRUD.Data;
using CollaboratorsCRUD.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CollaboratorsCRUD.Pages
{
    public class CollaboratorModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CollaboratorModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Collaborator Collaborator { get; set; }
        public List<Collaborator> Collaborators { get; set; }
        public List<Roles> Roles { get; set; }

        public void OnGet(string name)
        {
            Roles = _context.Roles.ToList();

            if (!string.IsNullOrEmpty(name))
            {
                Collaborators = _context.Collaborator.Where(c => c.Name.Contains(name)).ToList();
            }
            else
            {
                Collaborators = _context.Collaborator.ToList();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Collaborator collaborator = new Collaborator
            {
                Name = Collaborator.Name,
                Email = Collaborator.Email,
                Phone = Collaborator.Phone,
                IdRole = Collaborator.IdRole
            };

            _context.Collaborator.Add(collaborator);
            _context.SaveChanges();

            return RedirectToPage("Collaborator");
        }

        public IActionResult OnPostDelete(int id)
        {
            var collaborator = _context.Collaborator.Find(id);

            if (collaborator == null)
            {
                return NotFound();
            }

            _context.Collaborator.Remove(collaborator);
            _context.SaveChanges();

            return RedirectToPage("Collaborator");
        }
    }
}
