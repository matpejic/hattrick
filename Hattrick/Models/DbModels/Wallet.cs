using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Hattrick.Models.DbModels
{
    [Table("Wallet")]
    public class Wallet
    {

        [Key]
        public int IdWallet { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal AvailableBalance { get; set; }
      
    }

   
}