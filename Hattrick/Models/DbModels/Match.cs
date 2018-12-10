
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hattrick.Models.DbModels
{
    [Table("Match")]
    public class Match
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMatch { get; set; }
        [ForeignKey("Ticket")]
        public int IdTicket { get; set; }
        [ForeignKey("Football")]
        public int IdFootball { get; set; }
        public decimal Coefficient { get; set; }

        public virtual Football Football { get; set; }
        public virtual Ticket Ticket { get; set; }

    }
}