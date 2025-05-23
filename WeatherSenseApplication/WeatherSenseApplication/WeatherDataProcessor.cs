namespace WeatherSenseApplication
{
    internal class WeatherDataProcessor
    {

        // Declaring a readonly (to protect it from  accidental modifications) array to store temperatures for all 31 days in May.         
        private readonly double[] tempMay;


        // This list holds the day number and corresponding temperature for easy access. 
        private List<(double Day, double Temperature)> dayTemp;

        /// <summary>
        /// Initializing a temperature analyzer for the month of May with random temperatures for each of the 31 days (-4-14°C).
        /// This constructor simulates temperatures for Stockholm, Sweden, based on the historical weather data for May 2024.
        /// https://tripvenue.it/tempo-atmosferico/sweden/l2673730/stockholm/may
        /// The temperature data is stored in an array and a list that maps each day to its corresponding temperature.
        /// </summary>
        public WeatherDataProcessor()
        {
            // Initializing an array to store temperatures for 31 days of May.
            tempMay = new double[31];

            // Initializing a list to store day number and corresponding temperature pairs.
            dayTemp = new List<(double Day, double Temperature)>();

            // Creating a random number generator.
            // Using seed (42) Demonstrates that I will get the same random numbers after each running 
            // if i dont use it will give new random numbers which will not match with other funtionss of the program
            // if i leave it empty the Random will use the system clock and with each test time it will generate
            // new random numebrs will will not give desired value in this program.
            // We can even change the 42 to any other desired number.

            Random random = new Random(42);

            // Generates random temperatures for all 31 days.
            for (int i = 0; i < tempMay.Length; i++)
            {
                int temp = random.Next(-4, 14); // Generates temperatures between 7°C and 14°C.
                                                // !!! when the user enter a number above 14 the method
                                                // AboveThresholdTempFilter(int threshold) will not generate any data. 


                tempMay[i] = temp; // Stores the generated temperature in the array.

                // Adding the day number and corresponding temperature to the list.
                dayTemp.Add((Day: i + 1, Temperature: temp));
            }
        }


        /// <summary>
        /// Prints the temperature for each day in May in the original order.
        /// 1 - As a meteorologist, I want a list of temperature data for each day in May. Done
        /// </summary>
        public void DayTempPrinter()
        {
            Console.WriteLine("\n\nDaglig temperaturöversikt för maj:");
            foreach (var entry in dayTemp)
            {
                // Prints the day number and the corresponding temperature.
                Console.WriteLine($"Dag {entry.Day}: {entry.Temperature}°C");
            }
        }

        /// <summary>
        /// Calculates the average temperature for the entire month of May.
        /// 2 - I want to calculate the average temperature for May. Done
        /// </summary>
        /// <returns> The average temperature as a decimal value.</returns>
        public double AverageTempCalculator()
        {
            // Sums all the temperatures in the array.
            double sum = tempMay.Sum();

            // Divides the sum by the number of days to get the average.
            return (double)sum / tempMay.Length;
        }

        /// <summary>
        /// Finds the highest temperature of the month and the day it occurred.
        /// Then, it prints this result.
        /// 3-  I want to find the day with the highest temperature and its value. Done
        /// </summary>
        /// <remarks>
        /// This method iterates through the temperatures array to find the maximum temperature and the corresponding day.
        /// The result is displayed in the format: "Den varmaste dagen var dag X with Y°C."
        /// </remarks>
        public void MaxTempFinder()
        {
            double maxTemp = tempMay[0];  // Initialize maxTemp with the first element.
            int day = 1;  // Start from day 1 (index 0 in the array).

            // Iterate through the array to find the max temperature and the day it occurred.
            for (int i = 1; i < tempMay.Length; i++)
            {
                if (tempMay[i] > maxTemp)
                {
                    maxTemp = tempMay[i];  // Update maxTemp if a higher value is found.
                    day = i + 1;           // Update the day (index + 1 to get the correct day number).
                }
            }

            // Prints the result.
            Console.WriteLine($"\n\nDag {day} var den varmaste dagen med en temperatur på {maxTemp}°C.");
        }

        /// <summary>
        /// Finds the lowest temperature of the month and the day it occurred.
        /// Then, it prints this result.
        /// 4 - I want to find the day with the lowest temperature and its value. Done
        /// </summary>
        /// <remarks>
        /// This method iterates through the temperatures array to find the minimum temperature and the corresponding day.
        /// The result is displayed in the format: "Den kallaste dagen var dag X with Y°C."
        /// </remarks>
        public void MinTempFinder()
        {
            double minTemp = tempMay[0];  // Initialize minTemp with the first element.
            int day = 1;  // Start from day 1 (index 0 in the array).

            // Iterate through the array to find the min temperature and the day it occurred.
            for (int i = 1; i < tempMay.Length; i++)
            {
                if (tempMay[i] < minTemp)
                {
                    minTemp = tempMay[i];  // Update minTemp if a lower value is found.
                    day = i + 1;           // Update the day (index + 1 to get the correct day number).
                }
            }

            // Prints the result.
            Console.WriteLine($"\n\nDag {day} var den kallaste dagen, med en temperatur på {minTemp}°C.");

        }

        /// <summary>
        /// Calculates the median of the temperatures in the array.
        /// The median is the middle value in a sorted list.
        /// For an odd number of temperatures, the median is the value in the middle.
        /// For an even number of temperatures, the median is the average of the two middle values.
        /// 5 - I want to calculate the median temperature for May. Done
        /// </summary>
        /// <returns>The median as a double value.</returns>
        public double TempMedianCalculator()
        {
            // Creates a copy of the temperatures and sort it.
            double[] sortedTemp = tempMay.OrderBy(temp => temp).ToArray();

            // Finds the middle index.
            int midIndex = sortedTemp.Length / 2;

            // Checks if the number of temperatures is odd or even.
            if (sortedTemp.Length % 2 == 0)
            {
                // If the number is even, take the average of the two middle values.
                return (sortedTemp[midIndex - 1] + sortedTemp[midIndex]) / 2.0;
            }
            else
            {
                // If the number is odd, return the middle value.
                return sortedTemp[midIndex];
            }
        }


        /// <summary>
        /// Prints the temperatures in ascending order based on temperature,
        /// while preserving the day number from the original data.
        /// 6- I want to sort the temperatures in ascending (not) "or descending" order. Done
        /// </summary>
        public void DisplayTemperaturesInOrder()
        {
            // Sorts the list by temperature.
            var sorted = dayTemp.OrderBy(t => t.Temperature).ToList();

            Console.WriteLine("\nTemperaturer ordnade från lägst till högst:");
            foreach (var entry in sorted)
            {
                // Prints the original day number and the sorted temperature.
                Console.WriteLine($"Day {entry.Day}: {entry.Temperature}°C");
            }
        }


        /// <summary>
        /// Filters and prints the days where the temperature is higher than a specified threshold.
        /// Example: If the threshold is 20, only days with temperatures greater than 20°C are displayed.
        /// 7 - I want to filter and display only the days with temperatures above a certain threshold. Done
        /// </summary>
        /// <param name="threshold">The temperature threshold to filter the days by.</param>
        public void AboveThresholdTempFilter(int threshold)
        {
            Console.WriteLine($"Dagar med temperaturer över {threshold}°C:");

            foreach (var (day, temp) in dayTemp)
            {
                // Check if the temperature is greater than the threshold.
                if (temp > threshold)
                {
                    Console.WriteLine($"Day {day}: {temp}°C");
                }
            }
        }

        /// <summary>
        /// Prints the temperature for a specific day, as well as the temperatures for the previous and next days if available.
        /// 8- I want to enter a specific day in May and see its temperature, along with the temperatures from the previous and following days.
        /// </summary>
        /// <param name="day">The day number in May (1–31).</param>
        public void GetDayTemperature(int day)
        {
            // Check if the provided day is valid (between 1 and 31 days in May).
            if (day < 1 || day > dayTemp.Count)
            {
                Console.WriteLine("Ogiltig dag. Vänligen ange ett nummer mellan 1 och 31.");
                return;
            }

            // Retrieve the temperature for the specified day using its day number.
            (double Day, double Temperature) currentDay = dayTemp.First(d => d.Day == day);
            Console.WriteLine($"Dag {currentDay.Day}: {currentDay.Temperature}°C");

            // If the specified day is not the first day, retrieve the temperature for the previous day.
            if (day > 1)
            {

                (double Day, double Temperature) previousDay = dayTemp.First(d => d.Day == day - 1);
                Console.WriteLine($"Temperaturen för föregående dag (Dag {previousDay.Day}): {previousDay.Temperature}°C");
            }
            else
            {
                Console.WriteLine("Ingen föregående dag att visa.");
            }

            // If the specified day is not the last day, retrieve the temperature for the next day.
            if (day < dayTemp.Count)
            {

                (double Day, double Temperature) nextDay = dayTemp.First(d => d.Day == day + 1);
                Console.WriteLine($"Temperaturen för dagen efter (Dag {nextDay.Day}): {nextDay.Temperature}°C");
            }
            else
            {
                Console.WriteLine("Det finns ingen dag efter den valda.");
            }
        }


        /// <summary>
        /// Finds and prints the temperature that occurs most frequently in the array.
        /// If there are multiple temperatures with the same frequency, it displays the first one found.
        /// 9- I want to identify the most common temperature in May. Done
        /// </summary>
        /// <remarks>
        /// This method groups the temperatures in the array, counts the frequency of each temperature,
        /// sorts them by frequency in descending order, and selects the most frequent temperature.
        /// It then prints the most frequent temperature along with its occurrence count.
        /// </remarks>
        public void PrintTempWithHighestFrequency()
        {
            // Create a grouping of temperatures and count how many times each temperature occurs.
            var frequency = tempMay
                .GroupBy(temp => temp) // Group the temperatures.
                .Select(group => new { Temperature = group.Key, Count = group.Count() }) // Create an object for each temperature and its count.
                .OrderByDescending(x => x.Count) // Sort by frequency in descending order.
                .First(); // Take the temperature that occurs most frequently.

            // Print the result.
            Console.WriteLine($"\n\nDen mest förekommande temperaturen är {frequency.Temperature}°C, som inträffade {frequency.Count} gånger.");

        }




    }
}
