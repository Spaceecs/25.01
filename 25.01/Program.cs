//Task 1

int[] GetEven(int[] ints)
{
    List<int> ints1 = new List<int>();
    foreach (int i in ints)
    {
        if (i % 2 == 0)
        {
            ints1.Add(i);
        }
    }
    return ints1.ToArray<int>();
}
int[] GetOdd(int[] ints)
{
    List<int> ints1 = new List<int>();
    foreach (int i in ints)
    {
        if (i % 2 == 1)
        {
            ints1.Add(i);
        }
    }
    return ints1.ToArray<int>();
}
int[] GetSimple(int[] ints)
{
    List<int> ints1 = new List<int>();
    int k = 0;
    foreach (int i in ints)
    {
        for (int j = 1; j <= i; ++j)
        {
            if (i % j == 0)
            {
                k++;
            }
        }
        if(k<=2)
        {
            ints1.Add(i);
        }
        k = 0;
    }
    return ints1.ToArray<int>();
}
int[] GetFib(int[] ints)
{
    List<int> ints1 = new List<int>();
    int f1 = 0, f2 = 1, f3 = 0;
    foreach(int i in ints)
    {
        while (f2<=i)
        {
            f3 = f1 + f2;
            f1 = f2;
            f2 = f3;
            if (i == f2)
            {
                ints1.Add(i);
            }
        }
        f1 = 0;
        f2 = 1;
    }
    return ints1.ToArray<int>();
}
int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Func<int[], int[]> Even = new Func<int[], int[]>(GetEven);
int[] res = Even(ints);
foreach(int i in res)
{
    Console.Write($"{i} ");
}
Console.WriteLine();
Func<int[], int[]> Odd = new Func<int[], int[]>(GetOdd);
int[] res1 = Odd(ints);
foreach (int i in res1)
{
    Console.Write($"{i} ");
}
Console.WriteLine();
Func<int[], int[]> Simple = new Func<int[], int[]>(GetSimple);
int[] res2 = Simple(ints);
foreach (int i in res2)
{
    Console.Write($"{i} ");
}
Console.WriteLine();
Func<int[], int[]> Fib = new Func<int[], int[]>(GetFib);
int[] res3 = Fib(ints);
foreach (int i in res3)
{
    Console.Write($"{i} ");
}
Console.WriteLine();