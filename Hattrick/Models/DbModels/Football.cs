using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hattrick.Models.DbModels
{
    [Table("Football")]
    public class Football
    {

        [Key]
        public int IdFootball { get; set; }
        public string FootballGame { get; set; }
        public DateTime Time { get; set; }
        public decimal Coefficient1 { get; set; }
        public decimal Coefficient2 { get; set; }
        public decimal CoefficientX { get; set; }
        public string Winner { get; set; }
      
    }
}