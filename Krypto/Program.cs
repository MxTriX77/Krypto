using RSA.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

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
                BigInteger p;
                BigInteger q;
                Console.Write("Enter public key (e, n): ");
                string[] tokens = Console.ReadLine().Split();
                p = UInt64.Parse(tokens[0]);
                q = UInt64.Parse(tokens[1]);

                Console.WriteLine("\nProcessing...\n");

                StreamReader streamreader = new StreamReader(INPUTPATH);

                while (!streamreader.EndOfStream)
                {
                    encryptedmessage += streamreader.ReadLine();
                }

                streamreader.Close();

                List<string> result = RSACore.RSAEncrypt(encryptedmessage, p, q);

                StreamWriter streamwriter = new StreamWriter(OUTPUTPATH);
                foreach (string item in result)
                {
                    streamwriter.WriteLine(item);
                }

                streamwriter.Close();
            }
            catch
            {
                Environment.Exit(0);
            }
        }
    }
}

