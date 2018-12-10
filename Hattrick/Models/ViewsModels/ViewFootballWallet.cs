
using System.Collections.Generic;
using Hattrick.Models.DbModels;

namespace Hattrick.Models.ViewsModels
{
    public class ViewFootballWallet
    {
        public Wallet ViewWallet { get; set; }
        public List<Football> ViewFootballList { get; set; }

    }
}