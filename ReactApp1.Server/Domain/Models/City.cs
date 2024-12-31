using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.Domain.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        [Column("ID", TypeName = "integer")]
        public int ID { get; set; }

        [Column("Name", TypeName = "text")]
        public string Name { get; set; }

        [ForeignKey("State")]
        [Column("StateID", TypeName = "integer")]
        public int StateID { get; set; }
        public State? State { get; set; }

        [Column("CreationDate", TypeName = "text")]
        public DateTime CreationDate { get; set; }
    }
}
