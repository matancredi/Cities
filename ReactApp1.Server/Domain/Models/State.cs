using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Domain.Models
{
    [Table("State")]
    public class State
    {
        [Key]
        [Column("ID", TypeName = "integer")]
        public int ID { get; set; }

        [Column("Name", TypeName = "text"), Required]
        public string Name { get; set; }

        [ForeignKey("Country")]
        [Column("CountryID", TypeName = "integer"), Required]
        public int CountryID { get; set; }
        public Country? Country { get; set; }

        [Column("CreationDate", TypeName = "text"), Required]
        public DateTime CreationDate { get; set; }
    }
}
