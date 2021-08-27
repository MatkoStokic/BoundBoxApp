using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoundBoxApp.Model
{
    [Table("Bounds")]
    public class Bounds
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("User")]
        public string AnnotatorId { get; set; }
        public IdentityUser Annotator { get; set; }

        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project Project { get; set; }


        public ICollection<Marker> Markers { get; set; }
    }
}
