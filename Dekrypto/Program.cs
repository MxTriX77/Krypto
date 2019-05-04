using RSA.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Dekrypto
{
    class Program
    {
        private static readonly string INPUTPATH = @"msg\encryptedmsg.txt";
        private static readonly string OUTPUTPATH = @"msg\decryptedmsg.txt";

        static void Main(string[] args)
        {
            try
            {
                BigInteger d;
                BigInteger n;
                string result;
                Console.Write("Enter private key (d, n): ");
                string[] tokens = Console.ReadLine().Split();
                d = BigInteger.Parse(tokens[0]);
                n = BigInteger.Parse(tokens[1]);

                Console.WriteLine($"\n-----\nPRIVATE KEY: ({d}, {n})");
                Console.WriteLine("\nProcessing...\n");

                List<string> encryptedmessage = new List<string>();

                StreamReader streamreader = new StreamReader(INPUTPATH);

                while (!streamreader.EndOfStream)
                {
                    encryptedmessage.Add(streamreader.ReadLine());
                }
                streamreader.Close();

                result = RSACore.RSADecrypt(encryptedmessage, d, n);

                StreamWriter streamwriter = new StreamWriter(OUTPUTPATH);
                streamwriter.WriteLine(result);
                streamwriter.Close();
            }
            catch
            {
                Environment.Exit(0);
            }
        }
    }
}
