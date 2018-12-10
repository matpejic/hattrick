using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hattrick.Models.ViewsModels
{
    public class ViewTicket
    {
        public int IdFootball { get; set; }
        public string FootballGame { get; set; }
        public DateTime Time { get; set; }
        public decimal Coefficient { get; set; }
        public int IdMatch { get; set; }
        public int IdTicket { get; set; }

        public List<ViewTicket> ViewTicketList = new List<ViewTicket>();
    }
}