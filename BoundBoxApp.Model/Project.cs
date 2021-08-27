using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoundBoxApp.Model
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public string Id { get; set; }
        public string Src { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public bool IsForAnnotating { get; set; }


        [ForeignKey("User")]
        public string OwnerId { get; set; }
        public IdentityUser Owner { get; set; }
    }
}
