using System.Diagnostics;

int count = 0;

// Ask max number 
Console.WriteLine($"Max prime is {int.MaxValue}");
Console.Write("Calculate primes upto ");
int max = int.Parse(Console.ReadLine()) + 1;
if (max > int.MaxValue)
    Console.WriteLine("Number is too large.");


bool[] primes = new bool[max];
// fill array with true values
Array.Fill(primes, true);

// Start stopwatch sw
var sw = Stopwatch.StartNew();

FindPrimes(max);

// Calculate ready, store runtime in millisecs.
var swRunTime = sw.ElapsedMilliseconds;

//Check how many primes are found
for (int i = 2; i < max; i++)
{
    if (primes[i])
        count++;
}

Console.WriteLine($"\nTime={swRunTime} milliseconds.\n\nThere are {count} primes found.\n");
Console.WriteLine("Press <enter> to stop, type <y enter> voor a list with all found primes.");

if (Console.ReadLine() == "y")
{
    for (int i = 2; i < max; i++)
        if (primes[i])
            Console.Write($"{i} ");
    Console.WriteLine("\n\nPress op <enter> to stop.");
    Console.ReadLine();
}

void FindPrimes(long MaxNr)
{
    // Find primes between 2 and MaxNr
    for (int i = 2; i < Math.Sqrt(MaxNr); i++)
        // if primes[i] = true then i is a prime
        if (primes[i])
            // All multiplies of are not a prime
            for (int j = i + i; j < MaxNr; j += i)
                primes[j] = false;
}
