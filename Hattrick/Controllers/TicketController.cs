using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hattrick.DataAccess;
using Hattrick.Models.ViewsModels;

namespace Hattrick.Controllers
{
    public class TicketController : Controller
    {

        // GET: Ticket
        public ActionResult Index()
        {

           HattrickDBContext ctx = new HattrickDBContext();
           ViewTicket model = new ViewTicket ();

            var query = (from x in ctx.Matches.AsEnumerable()
                         join y in ctx.Footballs.AsEnumerable()
                         on x.IdFootball equals y.IdFootball
                         orderby x.IdTicket
                         select new ViewTicket
                         {
                             IdTicket = x.IdTicket,
                             IdMatch = x.IdMatch,
                             Coefficient = x.Coefficient,
                             FootballGame = y.FootballGame,
                             Time = y.Time,
                             IdFootball = y.IdFootball,

                         }).ToList();
            model.ViewTicketList = query;
            return View(model);
        }
    }
}