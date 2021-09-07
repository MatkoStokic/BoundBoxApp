using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoundBoxApp.Model
{
    [Table("Image")]

    public class Image
    {
        [Key]
        public string Id { get; set; }
        public string Src { get; set; }

        [ForeignKey("Project")]
        public string ProjectId { get; set; }

        public ICollection<Annotation> Annotations { get; set; }

    }
}
