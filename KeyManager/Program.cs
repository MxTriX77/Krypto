using System;
using RSA.Core;
using System.Numerics;

namespace KeyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger p;
            BigInteger q;

            Console.Write("Enter p, q: ");
            string[] tokens = Console.ReadLine().Split();
            p = BigInteger.Parse(tokens[0]);
            q = BigInteger.Parse(tokens[1]);

            RSACore.GenerateKeys(p, q, out BigInteger e, out BigInteger d, out BigInteger n);

            Console.WriteLine($"\n---------\nPUBLIC KEY: {e} {n}\nPRIVATE KEY: {d} {n}");
            Console.ReadKey();
        }
    }
}
