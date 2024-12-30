using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Domain.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        [Column("ID", TypeName = "integer")]
        public int ID { get; set; }

        [Column("Name", TypeName = "text")]
        public string Name { get; set; }

        [Column("CreationDate", TypeName = "text")]
        public DateTime CreationDate { get; set; }
    }
}
