using RSA.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace Krypto
{
    class Program
    {
        private static readonly string INPUTPATH = "msg.txt";
        private static readonly string OUTPUTPATH = "encryptedmsg.txt";

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

                StreamReader streamreader = new StreamReader(INPUTPATH);

                while (!streamreader.EndOfStream)
                {
                    encryptedmessage += streamreader.ReadLine();
                }

                streamreader.Close();

                encryptedmessage = encryptedmessage.ToUpper();

                List<string> result = RSACore.RSAEncrypt(encryptedmessage, p, q);

                StreamWriter streamwriter = new StreamWriter(OUTPUTPATH);
                foreach (string item in result)
                {
                    streamwriter.WriteLine(item);
                }
                streamwriter.Close();
                RSACore.GetPrivateKey(p, q, out long d, out long n);
                Console.Write($"PRIVATE KEY (d, n): ({d}, {n})");
                Console.ReadKey();
            }
            catch
            {
                Environment.Exit(0);
            }
        }
    }
}
