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
        string AnnotatorId { get; set; }
        IdentityUser Annotator { get; set; }

        [ForeignKey("Project")]
        string ProjectId { get; set; }
        Project Project { get; set; }


        ICollection<Marker> Markers { get; set; }
    }
}
