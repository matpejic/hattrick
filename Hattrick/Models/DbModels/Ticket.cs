using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hattrick.Models.DbModels
{
    [Table("Ticket")]
    public class Ticket
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTicket { get; set; }

        [ForeignKey("Wallet")]
        public int IdWallet { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Paid { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public virtual Wallet Wallet { get; set; }

    }
}