using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoundBoxApp.Model
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Categories { get; set; }
        public bool IsForObjectDetection { get; set; }


        [ForeignKey("User")]
        public string OwnerId { get; set; }
        public IdentityUser Owner { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
