using CollaboratorsCRUD.Data;
using CollaboratorsCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IActionResult OnPostCreate([FromBody] Collaborator collaborator)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Collaborator.Add(collaborator);
            _context.SaveChanges();

            return RedirectToPage("Collaborator");
        }
    }
}
