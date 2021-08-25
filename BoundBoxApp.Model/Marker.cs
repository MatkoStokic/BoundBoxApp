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
        Double XCoords { get; set; }
        Double YCoords { get; set; }
        
    }
}
