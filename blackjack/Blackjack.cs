using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] dealer = {random.Next(1, 11), random.Next(1, 11)};
            int[] myCards = {random.Next(1, 11), random.Next(1, 11)};

            Console.WriteLine($"\nDealer's hand: {dealer[0]}");
            Console.WriteLine($"Your hand: {myCards.Sum()}");

            string hitOrStand = "";
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Write($"\nHit or stand? ");
                hitOrStand = Console.ReadLine()!.ToLower();

                if (hitOrStand.Contains("hit"))
                {
                    int newCard = random.Next(1, 11);
                    myCards = myCards.Concat(new int[] { newCard }).ToArray();
                    Console.WriteLine($"Your hand: {myCards.Sum()}");

                    if (myCards.Sum() > 21)
                    {
                        Console.WriteLine($"\nYou busted with {myCards.Sum()}! Dealer wins.\n");
                        gameOver = true;
                    }
                    else if (myCards.Sum() == 21)
                    {
                        Console.WriteLine("\nBlackjack!");
                        gameOver = true;
                    }
                }
                else if (hitOrStand.Contains("stand"))
                {
                    Console.WriteLine($"Your hand: {myCards.Sum()}");
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid input, please try again.\n");
                    continue;
                }
            }

            if (!gameOver)
            {
                while (dealer.Sum() < 17)
                {
                    int newCard = random.Next(1, 11);
                    dealer = dealer.Concat(new int[] { newCard }).ToArray();
                }

                Console.WriteLine($"Dealer's hand: {dealer.Sum()}");

                if (dealer.Sum() > 21)
                {
                    Console.WriteLine($"\nDealer busts with {dealer.Sum()}! You win.\n");
                }
                else if (dealer.Sum() == 21)
                {
                    Console.WriteLine("\nDealer has Blackjack!\n");
                }
                else if (myCards.Sum() > dealer.Sum())
                {
                    Console.WriteLine("\nYou Win!\n");
                }
                else if (myCards.Sum() < dealer.Sum())
                {
                    Console.WriteLine("\nYou lose!\n");
                }
                else
                {
                    Console.WriteLine("\nPush, you get your money back!\n");
                }
            }
        }
    }
}
