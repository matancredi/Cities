using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.Domain.Models
{
    [Table("CountryGroup")]
    public class CountryGroup
    {
        [Key]
        [Column("ID", TypeName = "integer")]
        public int ID { get; set; }

        [Column("CountryID", TypeName = "integer")]
        public int CountryID { get; set; }
        public Country? Country { get; set; }

        [Column("GroupID", TypeName = "integer")]
        public int GroupID { get; set; }
        public EconomicGroup? Group { get; set; }
    }
}
