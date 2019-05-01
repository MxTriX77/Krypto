using System;
using System.Collections.Generic;
using System.Numerics;
using KMP.Core;

namespace RSA.Core
{
    public class RSACore
    {
        private static string charset = @" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяЄєҐґІЇїі01234567890123456789!?()'@&%$/\|<>*#^_[]{}`~+=-:;,.";

        public static void SetAlphabet(string alphabet)
        {
            if (alphabet.Length != 0) { charset = alphabet; }
        }

        public static string GetAlphabet()
        {
            return charset;
        }

        public static void GetEncryptionParameters(long p, long q, out long n, out long phi, out long d, out long e)
        {
            n = p * q;
            phi = (p - 1) * (q - 1);
            d = Calculate_d(phi);
            e = Calculate_e(d, phi);
        }

        private static long Calculate_e(long d, long phi)
        {
            long e = 7;
            while (true)
            {
                if ((e * d) % phi == 1) { break; } else { e++; };
            }

            return e;
        }

        private static long Calculate_d(long phi)
        {
            long d = phi - 1;
            for (long i = 2; i <= phi; i++)
            {
                if ((d % i == 0) && (phi % i == 0))
                {
                    d--;
                    i = 1;
                }
            }

            return d;
        }

        private static bool IsPrime(long n)
        {
            if (n < 2) { return false; }
            if (n == 2) { return true; }
            for (long i = 2; i < n; i++)
            {
                if (n % i == 0) { return false; }
            }

            return true;
        }

        public static List<string> RSAEncrypt(string message, long p, long q, bool logging)
        {
            // If either p or q is not a prime number, then RSA is not applicable.
            if ((!IsPrime(p) && !IsPrime(q)) || message == "") { return null; }
            else
            {
                long n;
                long phi;
                long e;
                long d;

                // Calculating modulo.
                n = p * q;
                if (logging == true) { Console.WriteLine($"Modulo:\nN={n}"); }

                // Calculating Euler's function.
                phi = (p - 1) * (q - 1);
                if (logging == true) { Console.WriteLine($"Euler's function:\nφ(N)={phi}"); }

                // Calculating private exponent.
                d = Calculate_d(phi);
                if (logging == true) { Console.WriteLine($"Private exponent:\nd={d}"); }

                // Calculating public exponent.
                e = Calculate_e(d, phi);
                if (logging == true) { Console.WriteLine($"Public exponent:\ne={e}\n-------\nPUBLIC KEY: ({e}, {n})\nPRIVATE KEY: ({d}, {n})"); }

                /* Hence we have 2 pairs of keys:
                    (e, n) - public key
                    (d, n) - private key
                */

                List<string> result = new List<string>();
                BigInteger bignum;

                for (int i = 0; i < message.Length; i++)
                {
                    int index = KMPCore.Search(Char.ToString(message[i]), charset);
                    bignum = new BigInteger(index);

                    // Encryption: C = M^e ( mod n).
                    bignum = BigInteger.Pow(bignum, (int)e);
                    BigInteger n_big = new BigInteger((int)n);
                    bignum %= n_big;
                    result.Add(bignum.ToString());
                }
                return result;
            }
        }

        public static string RSADecrypt(List<string> encryptedmessage, long d, long n)
        {
            string result = "";
            BigInteger bignum;

            foreach (string item in encryptedmessage)
            {
                bignum = new BigInteger(Convert.ToDouble(item));

                // Decryption: M = C^d ( mod n).
                bignum = BigInteger.Pow(bignum, (int)d);
                BigInteger n_big = new BigInteger((int)n);
                bignum %= n_big;
                int index = Convert.ToInt32(bignum.ToString());
                result += charset[index];
            }
            return result;
        }

    }
}