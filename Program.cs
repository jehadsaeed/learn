using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the minimum number: ");
        int minNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the maximum number: ");
        int maxNumber = int.Parse(Console.ReadLine());

        if (minNumber > maxNumber)
        {
            Console.WriteLine("Invalid range. The minimum number must be less than or equal to the maximum number.");
            return;
        }

        int rangeSize = maxNumber - minNumber + 1;
        int[] aar1 = new int[rangeSize];
        int[] aar2 = new int[rangeSize];

        for (int i = 0; i < rangeSize; i++)
        {
            aar1[i] = minNumber + i;
            aar2[i] = 0; 
        }

        Random rand = new Random();

        for (int i = 0; i < 1000; i++)
        {
            int randomNumber = rand.Next(minNumber, maxNumber + 1);

            for (int j = 0; j < rangeSize; j++)
            {
                if (randomNumber == aar1[j])
                {
                    aar2[j]++; 
                    break; 
                }
            }
        }

        for (int i = 0; i < rangeSize; i++)
        {
            Console.WriteLine($"{aar1[i]} appeared {aar2[i]} times.");
        }
    }
}
