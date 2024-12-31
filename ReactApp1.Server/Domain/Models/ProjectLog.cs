using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.Domain.Models
{
    [Table("ProjectLog")]
    public class ProjectLog
    {
        [Key]
        [Column("ID", TypeName = "integer")]
        public int ID { get; set; }

        [Column("DateTime", TypeName = "text")]
        public DateTime Date { get; set; }

        [Column("Thread", TypeName = "text")]
        public string? Thread { get; set; }

        [Column("Level", TypeName = "text")]
        public string? Level { get; set; }

        [Column("Logger", TypeName = "text")]
        public string? Logger { get; set; }

        [Column("Message", TypeName = "text")]
        public string? Message { get; set; }

        [Column("Exception", TypeName = "text")]
        public string? Exception { get; set; }

        [Column("Hostname", TypeName = "text")]
        public string? Hostname { get; set; }
    }
}
