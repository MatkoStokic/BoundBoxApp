using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoundBoxApp.Model
{
    [Table("Annotation")]
    public class Annotation
    {
        [Key]
        public string Id { get; set; }
        public string Category { get; set; }
        public bool IsObjectDetection { get; set; }

        [ForeignKey("User")]
        public string AnnotatorId { get; set; }
        public IdentityUser Annotator { get; set; }

        [ForeignKey("Project")]
        public string ProjectId { get; set; }


        public ICollection<Marker> Markers { get; set; }
    }
}
