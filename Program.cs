using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nationality_Based_Eye_Color_Analyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Enter the number of users (must be greater than 10): ");
                N = Convert.ToInt32(Console.ReadLine());
            } while (N <= 10);

            string[] names = new string[N];
            string[] nationalities = new string[N];
            string[] eyeColors = new string[N];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"\nEnter details for User {i + 1}:");
                Console.Write("Name: ");
                names[i] = Console.ReadLine();

                Console.Write("Nationality: ");
                nationalities[i] = Console.ReadLine();

                Console.Write("Eye Color: ");
                eyeColors[i] = Console.ReadLine();
            }

            string[] uniqueNationalities = new string[N];
            int uniqueCount = 0;

            for (int i = 0; i < N; i++)
            {
                bool isUnique = true;
                for (int j = 0; j < uniqueCount; j++)
                {
                    if (nationalities[i] == uniqueNationalities[j])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    uniqueNationalities[uniqueCount] = nationalities[i];
                    uniqueCount++;
                }
            }

            Console.WriteLine("\nMost common eye color for each nationality:");
            for (int k = 0; k < uniqueCount; k++)
            {
                string currentNationality = uniqueNationalities[k];

                string[] eyeColorsForNationality = new string[N];
                int colorCount = 0;

                for (int i = 0; i < N; i++)
                {
                    if (nationalities[i] == currentNationality)
                    {
                        eyeColorsForNationality[colorCount] = eyeColors[i];
                        colorCount++;
                    }
                }

                string mostCommonEyeColor = null;
                int highestFrequency = 0;

                for (int i = 0; i < colorCount; i++)
                {
                    int frequency = 0;
                    for (int j = 0; j < colorCount; j++)
                    {
                        if (eyeColorsForNationality[i] == eyeColorsForNationality[j])
                        {
                            frequency++;
                        }
                    }
                    if (frequency > highestFrequency)
                    {
                        highestFrequency = frequency;
                        mostCommonEyeColor = eyeColorsForNationality[i];
                    }
                }

                Console.WriteLine($"Nationality: {currentNationality}, Most Common Eye Color: {mostCommonEyeColor} (Count: {highestFrequency})");
            }
        }
    }
}
