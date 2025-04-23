using System;
using System.Media;
using System.Threading;

namespace ProgPoePart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Assistant";

            // Play welcome audio
            PlayWelcomeAudio();

            // Display ASCII Art logo
            DisplayAsciiArt();

            // Ask for user's name
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[+] Please enter your name:");
            Console.ResetColor();
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Name cannot be empty. Please enter your name:");
                Console.ResetColor();
                name = Console.ReadLine();
            }

            Console.Clear();
            DisplayAsciiArt();

            // Personalized greeting
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello, {name}! Welcome to the Cybersecurity Awareness Assistant.");
            Console.WriteLine("You can ask about the following topics:");
            Console.WriteLine("  [1] How are you?");
            Console.WriteLine("  [2] What's your purpose?");
            Console.WriteLine("  [3] What can I ask you about?");
            Console.WriteLine("  [4] Tell me about phishing.");
            Console.WriteLine("  [5] Give me password tips.");
            Console.WriteLine("  [6] How to browse safely?");
            Console.WriteLine("  [7] Ask your own question.");
            Console.WriteLine("Type the number of your choice, or type 'exit' to end the conversation.");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();
                string input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    continue;
                }

                if (input == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Bot: Stay safe online, goodbye!");
                    Console.ResetColor();
                    break;
                }

                if (input == "7")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Bot: Sure! What's your question?");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("You: ");
                    Console.ResetColor();
                    input = Console.ReadLine()?.ToLower().Trim();
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                SimulateTyping("Bot: " + GetBotResponse(input));
                Console.ResetColor();

                // Ask if the user wants to continue or exit
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\nWould you like to ask another question? (yes/exit): ");
                    Console.ResetColor();
                    string next = Console.ReadLine()?.ToLower().Trim();

                    if (next == "yes")
                    {
                        break; // continue outer loop
                    }
                    else if (next == "exit")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Bot: Stay safe online, goodbye!");
                        Console.ResetColor();
                        return; // exit the Main method
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bot: Please type 'yes' to continue or 'exit' to quit.");
                        Console.ResetColor();
                    }
                }
            }
        }

        static void PlayWelcomeAudio()
        {
            string filePath = @"C:\Users\lab_services_student\Desktop\mulu.wav"; // Updated file path

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using (SoundPlayer player = new SoundPlayer(filePath))
                    {
                        player.Load();  // Load the audio file into memory
                        player.PlaySync(); // Play it synchronously (wait for it to finish before continuing)
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Audio file not found at the specified path.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[!] Error playing audio: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==============================================");
            Console.WriteLine("   ____       _               _   _           ");
            Console.WriteLine("  / ___| ___ | |__   ___ _ __| |_(_) ___  ___ ");
            Console.WriteLine(" | |  _ / _ \\| '_ \\ / _ \\ '__| __| |/ _ \\/ __|");
            Console.WriteLine(" | |_| | (_) | |_) |  __/ |  | |_| |  __/\\__ \\");
            Console.WriteLine("  \\____|\\___/|_.__/ \\___|_|   \\__|_|\\___||___/");
            Console.WriteLine("   CYBERSECURITY AWARENESS ASSISTANT         ");
            Console.WriteLine("==============================================");
            Console.ResetColor();
        }

        static string GetBotResponse(string input)
        {
            switch (input)
            {
                case "1":
                case "how are you?":
                case "how are you":
                    return "I'm functioning securely! Thanks for asking.";

                case "2":
                case "what's your purpose?":
                case "what's your purpose":
                    return "My purpose is to help you understand and avoid cybersecurity threats.";

                case "3":
                case "what can i ask you about?":
                    return "You can ask about phishing, password safety, and safe browsing practices.";

                case "4":
                case "tell me about phishing":
                    return "Phishing is a scam where attackers trick you into giving up personal info via fake emails or websites.";

                case "5":
                case "give me password tips":
                    return "Use long, unique passwords with a mix of characters. Avoid using the same password for multiple sites.";

                case "6":
                case "how to browse safely?":
                    return "Always check for HTTPS, avoid clicking suspicious links, and keep your browser updated.";

                default:
                    return "That's an interesting question. I'm still learning to answer more topics. For now, please try one of the options 1 to 6.";
            }
        }

        static void SimulateTyping(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20); // Simulate typing
            }
            Console.WriteLine();
        }
    }
}
