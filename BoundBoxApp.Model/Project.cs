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
        string Src { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string IsForAnnotating { get; set; }


        [ForeignKey("User")]
        string OenrId { get; set; }
        IdentityUser Owner { get; set; }
    }
}
