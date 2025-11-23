using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number Guessing Game!\n");
        Console.WriteLine("Type 'exit' to quit the game\n");
        Console.WriteLine("I'm thinking of a number between 1 and 100.\n");

        int attempts = 0;

        while (true)
        {
            Console.WriteLine("Please select the difficulty level:");
            Console.WriteLine("1. Easy   (10 chances)");
            Console.WriteLine("2. Medium (5 chances)");
            Console.WriteLine("3. Hard   (3 chances)");
            Console.Write("\nEnter your choice: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                return;

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input! Please enter 1, 2, or 3.\n");
                continue;
            }

            if (choice == 1)
            {
                attempts = 10;
                Console.WriteLine("\nGreat! You selected Easy difficulty.\n");
                break;
            }
            else if (choice == 2)
            {
                attempts = 5;
                Console.WriteLine("\nGreat! You selected Medium difficulty.\n");
                break;
            }
            else if (choice == 3)
            {
                attempts = 3;
                Console.WriteLine("\nGreat! You selected Hard difficulty.\n");
                break;
            }
            else
            {
                Console.WriteLine("Please choose 1, 2, or 3.\n");
            }
        }
        StartGame(attempts);

        while (true)
        {
            Console.WriteLine("\nDo you want to play again? type 'yes' or 'no'");
            string replay = Console.ReadLine().ToLower();

            if (replay == "no" || replay == "exit")
            {
                Console.WriteLine("Goodbye");
                return;
            }
            else if (replay == "yes")
            {
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("\nPlease type 'yes' or 'no'.\n");
            }
        }
    }
    static void StartGame(int attempts)
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);

        //Console.WriteLine(secretNumber);

        int currentAttempt = 0;

        while (currentAttempt < attempts)
        {
            Console.Write("Attempt " + (currentAttempt + 1) + "/" + attempts + " - Enter your guess: ");
            string guessInput = Console.ReadLine();

            if (!int.TryParse(guessInput, out int guess))
            {
                Console.WriteLine("Please enter a valid number between 1 and 100.\n");
                continue;
            }

            if (guess < 1 || guess > 100)
            {
                Console.WriteLine("Please enter a number between 1 and 100\n");
                continue;
            }

            currentAttempt++;

            if (guess > secretNumber)
            {
                Console.WriteLine("Incorrect! The number is less than " + guess + "\n");
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Incorrect! The number is greater than " + guess + "\n");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the correct number in " + currentAttempt + " attempts.\n");
                return;
            }
        }

        Console.WriteLine("Game over! Thanks for playing.");
        Console.WriteLine("The correct number was: " + secretNumber);
    }

}
