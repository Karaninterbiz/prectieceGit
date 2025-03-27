namespace LogicalTask_42
{

    public class Bowler
    {
        public string BowlerName { get; set; }
        public double Runs { get; set; }
        public double Overs { get; set; }

        public Bowler(string bowlerName, double runs, double overs)
        {
            BowlerName = bowlerName;
            Runs = runs;
            Overs = overs;
        }


        public double EconomyRate()
        {
            return Runs / Overs;
        }

    }

    public class Batsman
    {
        public string BatsmanName { get; set; }
        public double Runs { get; set; }
        public double Balls { get; set; }

        public Batsman(string batsmanName, double runs, double balls)
        {
            BatsmanName = batsmanName;
            Runs = runs;
            Balls = balls;
        }


        public double StrikeRate()
        {
            return (Runs / Balls) * 100;
        }
    }

    internal class Task_42
    {
        static void Main(string[] args)
        {

            List<Bowler> bowlers = new List<Bowler>
            {
                new Bowler("Bumrah", 24, 4),
                new Bowler("Chahal", 30, 3),
                new Bowler("Shami", 18, 2),
                new Bowler("Ashwin", 10, 1)
            };


            List<Batsman> batsmen = new List<Batsman>
            {
                new Batsman("Kohli", 45, 38),
                new Batsman("Rohit", 60, 35),
                new Batsman("Gill", 35, 20),
                new Batsman("Pant", 20, 15),
                new Batsman("Hardik", 50, 25)
            };


            Bowler mostEconomicalBowler = null;
            double minEconomyRate = double.MaxValue;
            Console.WriteLine(minEconomyRate);
            foreach (var bowler in bowlers)
            {
                if (bowler.Overs >= 2)
                {
                    double economyRate = bowler.EconomyRate();
                    if (economyRate < minEconomyRate)
                    {
                        minEconomyRate = economyRate;
                        mostEconomicalBowler = bowler;
                    }
                }
            }

           
            Batsman bestBatsman = null;
            double maxStrikeRate = 0;

            foreach (var batsman in batsmen)
            {
                if (batsman.Balls >= 10) 
                {
                    double strikeRate = batsman.StrikeRate();
                    if (strikeRate > maxStrikeRate)
                    {
                        maxStrikeRate = strikeRate;
                        bestBatsman = batsman;
                    }
                }
            }


            // economical bowler
            if (mostEconomicalBowler != null)
            {
                Console.WriteLine($"Most Economical Bowler: {mostEconomicalBowler.BowlerName}");
                Console.WriteLine($"Economy Rate: {minEconomyRate}");
            }
            else
            {
                Console.WriteLine("No bowler meets the criteria.");
            }

            //  best batsman
            if (bestBatsman != null)
            {
                Console.WriteLine($"Best Batsman: {bestBatsman.BatsmanName}");
                Console.WriteLine($"Strike Rate: {maxStrikeRate}");
            }
            else
            {
                Console.WriteLine("No batsman meets the criteria.");
            }

        }
    }
}
