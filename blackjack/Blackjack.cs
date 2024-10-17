namespace test;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int[] dealer = {random.Next(1, 11), random.Next(1, 11)};
        int[] myCards = {random.Next(1, 11), random.Next(1, 11)};

        Console.WriteLine($"\nDealers hand: {dealer[0]}");
        Console.WriteLine($"\nYour hand: {myCards.Sum()}");

        string hitOrStand = "";
        Console.Write($"\nHit or stand? ");
        hitOrStand = Console.ReadLine()!;

        if (hitOrStand.Contains("hit"))
        {
            bool hitYes = true;

            while (hitYes) 
            {
                int newCard = random.Next(1, 11);
                myCards = myCards.Concat(new int[] { newCard }).ToArray();     

                Console.WriteLine($"Your hand {myCards.Sum()}");

                if (myCards.Sum() > 21)
                {
                    Console.WriteLine($"\nYou busted with {myCards.Sum()}! Dealer wins.\n");
                    hitYes = false;
                    Environment.Exit(0);
                }

                if (myCards.Sum() == 21)
                {
                    Console.WriteLine("\nBlackjack!");
                }

                Console.Write($"\nHit or stand? ");
                hitOrStand = Console.ReadLine()!;

                if (hitOrStand.Contains("hit"))
                {
                    continue;
                } 
                else if (hitOrStand.Contains("stand"))
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("\nInvalid input, please try again.\n");
                    continue;
                }
            }
        }
        else if (hitOrStand.Contains("stand"))
        {
            Console.WriteLine($"Your hand {myCards.Sum()}");
        }

        while (dealer.Sum() < 17)
        {  
            int newCard = random.Next(1, 11);
            dealer = dealer.Concat(new int[] { newCard }).ToArray();

            if (dealer.Sum() > 21)
            {
                Console.WriteLine($"\nDealer busts with {dealer.Sum()}! You win.\n");
                Environment.Exit(0);
            }
            else if (dealer.Sum() == 21)
            {
                Console.WriteLine("\nDealer has Blackjack!\n");
                break;
            }
        }

        Console.WriteLine($"Dealers hand {dealer.Sum()}");

        if (myCards.Sum() > dealer.Sum())
        {
            Console.WriteLine("\nYou Win!\n");
        }
        else if (myCards.Sum() < dealer.Sum())
        {
            Console.WriteLine("\nYou lose!\n");
        }
        else if (myCards.Sum() == dealer.Sum())
        {
            Console.WriteLine("\nPush, you get your money back!\n");
        }
    }
}
