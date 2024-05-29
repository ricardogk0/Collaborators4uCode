using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorsCRUD.Models
{
    public class Collaborator
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IdRole { get; set; }
        
        [ForeignKey("IdRole")]
        public Roles Role { get; set; }
    }
}