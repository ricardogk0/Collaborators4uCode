using System;

namespace CollaboratorsCRUD.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Collaborator> Collaborators { get; set; }
    }
}