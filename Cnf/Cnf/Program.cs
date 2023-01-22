using static Cnf.Cnf;

namespace Cnf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"X{i}\t");
            }
            Console.WriteLine($"F\t");

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"{X1[i].AsString()}\t{X2[i].AsString()}\t{X3[i].AsString()}\t{X4[i].AsString()}\t{X5[i].AsString()}\t{X6[i].AsString()}\t{X7[i].AsString()}\t{X8[i].AsString()}\t{X9[i].AsString()}\t{X10[i].AsString()}\t{F[i].AsString()}\t");
            }
        }
    }
}