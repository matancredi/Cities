using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ReactApp1.Server.Domain.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        [Column("ID", TypeName = "integer")]
        public int ID { get; set; }

        [Column("Name", TypeName = "text")]
        public string? Name { get; set; }

        [Column("CreationDate", TypeName = "text")]
        public DateTime CreationDate { get; set; }
    }
}

//Annotations:
//Column and Table mappings can be safely removed if the names are the same, but provide documentation and enable developers to change the class and property names without breaking the application.