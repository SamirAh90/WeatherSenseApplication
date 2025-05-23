/* 
        *************************************** Introduction ********************************************
 
        The WeatherSenseApplication is a simple program that helps analyze and display weather data for May. 
        The main class, WeatherDataProcessor, works with temperatures and provides useful features like 
        showing daily temperatures, finding the hottest and coldest days, and calculating averages.


        Key features of the program include:

        Daily Temperature List: Shows the temperature for each day in May.
        Finding Extremes: Finds the warmest and coldest days with their temperatures.
        Average and Median: Calculates the average and middle (median) temperatures for the month.
        Sorting and Filtering: Lets you sort temperatures or see days with temperatures above a certain value.
        Specific Day Details: Shows the temperature for a chosen day and the days before and after it.
        Most Common Temperature: Finds and displays the temperature that appears most often.

        Usage: This program is easy to use and great for anyone who wants to learn about or work with weather data.

        Refernser:

        1- Complete C# Masterclass course på Udemy, (https://www.udemy.com/course/complete-csharp-masterclass/?srsltid=AfmBOoqbgM31iC73NSkYRMTya0gbuziFMaxYnT-xdGn0gEw6oyiyrezW&couponCode=KEEPLEARNING)
        2- Troelsen, A., & Japikse, P. (2022). Pro C# 10 with .NET 6 : foundational principles and practices in programming (11 uppl.). New York: APress. ISBN: 9781484278680.
        3- Land, R. (2024). Introduktion till programmering (1 uppl.). Borlänge.
        4- Stackoverflow, https://stackoverflow.com/.
        https://stackoverflow.com/questions/585859/what-is-the-difference-between-protected-and-protected-internal 
        5- Microsoft Learn Challenge C#, https://learn.microsoft.com/en-us/dotnet/csharp/
        6- What is the weather like in Stockholm in May 2024?, https://tripvenue.it/tempo-atmosferico/sweden/l2673730/stockholm/may
        7- C# Tutorial, https://www.w3schools.com/cs/cs_switch.php
        8- C# Comments, https://www.programiz.com/csharp-programming/comments
        9- Create UML class diagrams, https://www.drawio.com/blog/uml-class-diagrams 
        https://compugrammar.wordpress.com/cscb07/array-list-uml-week-4-week-5/
        https://stackoverflow.com/questions/27459257/how-to-represent-an-attributes-data-type-as-an-array-of-objects-on-class-diagra
        https://www.youtube.com/watch?v=6XrL5jXmTwM
        10- Google, YouTube and Open AI ChatGPT for open questions. 
            - Deffernce between internal and protected classes in creating UML.
            - How to create user friendly console application using C#
            - How to use Random() and Next()
            - Creating, saving and lopping through a list.
            - Creating Rainbow color in C# - we got great inputs but we chose to not use it in our application since it coult lead to kompicity
            - Using switch, data type int or string as an input? Differences and pro-cons of them. 
        
        Comments:
        1- Single Line Comments  
        2- Multi Line Comments    
        3 - XML Comments - för method

        Developers:
        Samir Ahmad, student of the Department of Computer Science at Dalarna University.
        Ludwig Lindfors, student of the Department of Computer Science at Dalarna University.
*/


// The application starts from here!
namespace WeatherSenseApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize WeatherDataProcessor object to handle temperature data for May.
            WeatherDataProcessor analyzer = new WeatherDataProcessor();
            bool MenueOn = true;

            while (MenueOn)
            {
                // Clears the console screen for better readability
                Console.Clear();

                // Set the header's text color to cyan for a pleasant visual effect
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t══════════════════════════════════════════════════════════════════════════");
                Console.WriteLine("\t\t\t\t\t      Välkommen till Väderanalysprogrammet");
                Console.WriteLine("\t\t\t══════════════════════════════════════════════════════════════════════════\n");
                Console.ResetColor();

                // Set the description text color to green for emphasis
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t\t Det här programmet hjälper dig att analysera temperaturdata");
                Console.WriteLine("\t\t\t\t     för att få olika statistiska värden och insikter.");
                Console.WriteLine("\t\t\t\t  Datan är genererad för maj 2024 och är helt slumpmässig.\n");
                Console.ResetColor();

                // Add a separator in yellow to give the menu some structure
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t══════════════════════════════════════════════════════════════════════════\n");
                Console.ResetColor();

                // Display the menu options with clear instructions
                Console.WriteLine("\t\t\tVälj ett alternativ från menyn:");
                Console.WriteLine();
                Console.WriteLine("\t\t\t1. Skriv ut temperaturer för varje dag i maj");
                Console.WriteLine("\t\t\t2. Beräkna och skriv ut medeltemperaturen");
                Console.WriteLine("\t\t\t3. Hitta och skriv ut den högsta temperaturen");
                Console.WriteLine("\t\t\t4. Hitta och skriv ut den lägsta temperaturen");
                Console.WriteLine("\t\t\t5. Beräkna och skriv ut medianvärdet för temperaturen");
                Console.WriteLine("\t\t\t6. Skriv ut temperaturer i stigande ordning");
                Console.WriteLine("\t\t\t7. Filtrera och skriv ut dagar med temperaturer över den angivna");
                Console.WriteLine("\t\t\t8. Hitta och skriv ut den vanligaste temperaturen");
                Console.WriteLine("\t\t\t9. Ange ett dagnummer och visa temperaturer för den dagen");
                Console.WriteLine("\t\t\t10. Avsluta programmet");
                Console.WriteLine();

                // Add some spacing and use ResetColor to ensure the default color is restored
                Console.ResetColor();
                Console.WriteLine("\nVänligen välj ett alternativ genom att skriva siffran och trycka på Enter.");


                // Request user input to choose an option.
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // Print temperatures for each day in May
                        analyzer.DayTempPrinter();
                        break;

                    case "2":
                        // Calculate and print the average temperature for May
                        double average = analyzer.AverageTempCalculator();
                        Console.WriteLine($"\nMedeltemperaturen i maj är: {average:0.00}°C");
                        break;

                    case "3":
                        // Find and print the highest temperature and the day it occurred
                        analyzer.MaxTempFinder();
                        break;

                    case "4":
                        // Find and print the lowest temperature and the day it occurred
                        analyzer.MinTempFinder();
                        break;

                    case "5":
                        // Calculate and print the median temperature for the month
                        double median = analyzer.TempMedianCalculator();
                        Console.WriteLine($"\nMediantemperaturen i maj var: {median:0.00}°C");
                        break;

                    case "6":
                        // Print temperatures in ascending order
                        analyzer.DisplayTemperaturesInOrder();
                        break;

                    case "7":
                        // Filter and print the days based on the user input 
                        Console.WriteLine("Ange tröskelvärde för att visa dagar med temperaturer över detta i maj:");
                        int userInput1;
                        if (int.TryParse(Console.ReadLine(), out userInput1))
                        {
                            analyzer.AboveThresholdTempFilter(userInput1);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig inmatning. Vänligen ange ett giltigt nummer.");
                        }
                        break;

                    case "8":
                        // Find and print the most frequent temperature in the month
                        analyzer.PrintTempWithHighestFrequency();
                        break;

                    case "9":
                        // Ask the user to enter a day number and show temperatures for that day
                        Console.WriteLine("\nVänligen ange ett dagnummer mellan 1 och 31:");
                        if (int.TryParse(Console.ReadLine(), out int day) && day >= 1 && day <= 31)
                        {
                            analyzer.GetDayTemperature(day); // Display temperatures for the specified day
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig inmatning. Vänligen ange ett giltigt nummer mellan 1 och 31.");
                        }
                        break;

                    case "10":
                        // Exit the program
                        Console.WriteLine("\nProgrammet avslutas om 3 sekunder...");
                        Thread.Sleep(3000); // Wait for 2 seconds before exiting
                        MenueOn = false; // Stop the main loop
                        Console.Beep();
                        break;

                    default:
                        // Invalid input, prompt user to try again
                        Console.WriteLine("Ogiltigt val. Vänligen välj ett giltigt alternativ.");
                        break;
                }

                // After each action, pause for the user to read the result and then return to the menu
                if (MenueOn)
                {
                    Console.WriteLine("\nTryck på en tangent för att fortsätta...");
                    Console.ReadKey(); // Wait for user to press any key before showing the menu again
                }
            }

        }
    }
}
