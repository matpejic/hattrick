
using System.Collections.Generic;
using System.Web.Mvc;
using Hattrick.DataAccess;
using Hattrick.Models.ViewsModels;
using Hattrick.Models.DbModels;
using System.Linq;


namespace Hattrick.Controllers
{
    public class HomeController : Controller
    {
        decimal coefficient;
        decimal SumCoefficient;
        decimal total;

        public ActionResult About()
        {

            HattrickDBContext ctx = new HattrickDBContext();
            ViewFootballWallet model = new ViewFootballWallet();


            model.ViewFootballList = ctx.Footballs.ToList();
            model.ViewWallet = ctx.Wallets.FirstOrDefault();
            return View(model);

        }
        [HttpPost]
        public ActionResult About(ViewFootballWallet footballmodel)
        {
            
            Update(footballmodel);
            return RedirectToAction("About");
        }

        private void Update(ViewFootballWallet model1)
        {
      
                 Ticket ticket = new Ticket();
                 List<Match> MatchList = new List<Match>();
                 var match = new Match();
                 coefficient = 0;
                 total = 0;

                for (int i= 0; i < model1.ViewFootballList.Count(); i++)
                         {
                string winner = model1.ViewFootballList[i].Winner;
                         if (winner != null)
                             {
                             coefficient = 0;
                           
                                 if (winner=="1")
                                 {
                            coefficient = model1.ViewFootballList[i].Coefficient1;
                                 }
                                else if (winner == "2")
                                 {
                            coefficient = model1.ViewFootballList[i].Coefficient2;
                                 }
                                 else if (winner == "X")
                                 {
                            coefficient = model1.ViewFootballList[i].CoefficientX;
                                 }

                                 match = new Match {
                                     IdFootball = model1.ViewFootballList[i].IdFootball,
                                     Coefficient = coefficient
                                 };

                                 if (i == 0) {
                                       SumCoefficient = coefficient;
                                 }
                                 else { 
                                      SumCoefficient = SumCoefficient * coefficient;
                                 }

                                 MatchList.Add(match);
                             }

                         }
                         if (model1.ViewFootballList.Count() > 3)  {
                                 SumCoefficient = SumCoefficient + 10;
                         }
                         else {
                                 SumCoefficient = SumCoefficient + 5;
                         }

                            total = model1.ViewWallet.AvailableBalance * SumCoefficient;

                         ticket = new Ticket
                         {
                             IdWallet = model1.ViewWallet.IdWallet,
                             Paid = model1.ViewWallet.AvailableBalance,
                             Total = total

                         };


                using (var ctx = new HattrickDBContext())
                {
                    Wallet wallet = null;
                    wallet = ctx.Wallets.Find(model1.ViewWallet.IdWallet);
                    wallet.AvailableBalance = wallet.AvailableBalance - model1.ViewWallet.AvailableBalance;
                    ctx.Entry(wallet).State = System.Data.Entity.EntityState.Modified;
     
                   var ticket1 = new Ticket
                    {
                        IdWallet = model1.ViewWallet.IdWallet,
                        Paid = model1.ViewWallet.AvailableBalance,
                        Total = total

                   };
                    ctx.Tickets.Add(ticket1);

                    foreach (var match1 in MatchList)
                    {
                        var match2 = new Match
                        {
                            IdTicket = ticket1.IdTicket,
                            IdFootball = match1.IdFootball,
                            Coefficient = match1.Coefficient

                        };
                        ctx.Matches.Add(match2);

                    }

                    ctx.SaveChanges();
                }
            }
            
        }
          
 }