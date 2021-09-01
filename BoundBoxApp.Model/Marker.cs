using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoundBoxApp.Model
{
    [Table("Marker")]
    public class Marker
    {
        [Key]
        public string Id { get; set; }
        public double XCoords { get; set; }
        public double YCoords { get; set; }
        public string BoundsId { get; set; }
        
    }
}
