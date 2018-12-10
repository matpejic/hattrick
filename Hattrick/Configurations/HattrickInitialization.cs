using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using Hattrick.DataAccess;
using Hattrick.Models.DbModels;

namespace Hattrick.Configurations
{
    public class HattrickInitialization : DropCreateDatabaseIfModelChanges<HattrickDBContext>
    {
        protected override void Seed(HattrickDBContext context)
        {
           
            var wallet1 = new Wallet { Name = "Matea Pejić", AvailableBalance = Convert.ToDecimal("50000") };

            List<Football> defaultFootballs = new List<Football>
            {
                new Football() { FootballGame = "ARSENAL - TOTTENHAM", Time = Convert.ToDateTime("11-23-2018"), Coefficient1 = 12.8m, CoefficientX = 3.40m, Coefficient2 = 2.90m, Winner = "" },
                new Football() { FootballGame = "CHELSEA - MAN.CITY", Time = Convert.ToDateTime("11-22-2018"), Coefficient1 = 4, CoefficientX = 3.70m, Coefficient2 = 2.10m, Winner = "" },
                new Football() { FootballGame = "LEICESTER - TOTTENHAM", Time = Convert.ToDateTime("11-21-2018"), Coefficient1 = 3.70m, CoefficientX = 3.30m, Coefficient2 = 2.00m, Winner = "" },
                new Football() { FootballGame = "OXFORD CITY - TRURO CITY", Time = Convert.ToDateTime("11-20-2018"), Coefficient1 = 1.70m, CoefficientX = 3.60m, Coefficient2 = 3.80m, Winner = "" },
                new Football() { FootballGame = "AVION - R.S.PARIS", Time = Convert.ToDateTime("11-21-2018"), Coefficient1 = 12, CoefficientX = 7.00m, Coefficient2 = 1.15m, Winner = "" }
            };
            

            context.Wallets.Add(wallet1);
            context.Footballs.AddRange(defaultFootballs);

            context.SaveChanges();

            base.Seed(context);

        }

    }
}

