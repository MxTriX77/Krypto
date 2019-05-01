using RSA.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace Krypto
{
    class Program
    {
        private static readonly string INPUTPATH = @"msg\msg.txt";
        private static readonly string OUTPUTPATH = @"msg\encryptedmsg.txt";

        static void Main(string[] args)
        {
            try
            {
                string encryptedmessage = "";
                long p;
                long q;
                Console.Write("Enter p, q: ");
                string[] tokens = Console.ReadLine().Split();
                p = Int64.Parse(tokens[0]);
                q = Int64.Parse(tokens[1]);

                Console.WriteLine("\nProcessing...\n");

                StreamReader streamreader = new StreamReader(INPUTPATH);

                while (!streamreader.EndOfStream)
                {
                    encryptedmessage += streamreader.ReadLine();
                }

                streamreader.Close();

                List<string> result = RSACore.RSAEncrypt(encryptedmessage, p, q, false);

                StreamWriter streamwriter = new StreamWriter(OUTPUTPATH);
                foreach (string item in result)
                {
                    streamwriter.WriteLine(item);
                }

                streamwriter.Close();
                RSACore.GetEncryptionParameters(p, q, out long n, out long phi, out long d, out long e);
                Console.WriteLine($"PRIVATE KEY (d, n): ({d}, {n})");

                Console.ReadKey();
            }
            catch
            {
                Environment.Exit(0);
            }
        }
    }
}
