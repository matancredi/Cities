using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.Domain.Models
{
    [Table("EconomicGroup")]
    public class EconomicGroup
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
