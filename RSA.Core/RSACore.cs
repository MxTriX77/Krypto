using System;
using System.Collections.Generic;
using System.Numerics;

namespace RSA.Core
{
    public class RSACore
    {
        private static string default_charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ 01234567890123456789";
        private static char[] _alphabet = { };

        public static void SetAlphabet(string alphabet)
        {
            _alphabet = alphabet.ToCharArray();
        }

        public static void GetPrivateKey(long p, long q, out long d, out long n)
        {
            n = p * q;
            d = Calculate_d((p - 1) * (q - 1));
        }

        private static void CheckAlphabet()
        {
            if (_alphabet.Length == 0) { _alphabet = default_charset.ToCharArray(); }
        }

        private static long Calculate_e(long d, long phi)
        {
            long e = 10;
            while (true)
            {
                if ((e * d) % phi == 1) { break; } else { e++; };
            }
            return e;
        }

        private static long Calculate_d (long phi)
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

        public static List<string> RSAEncrypt(string message, long p, long q)
        {
            // If either p or q are not prime numbers, then RSA is not applicable.
            if (!IsPrime(p) && !IsPrime(q)) { return null; }

            long n;
            long phi;
            long e;
            long d;

            CheckAlphabet();

            // Calculating modulo.
            n = p * q;

            // Calculating Euler's function.
            phi = (p - 1) * (q - 1);

            // Calculating private exponent.
            d = Calculate_d(phi);

            // Calculating public exponent.
            e = Calculate_e(d, phi);

            /* Hence we have 2 pairs of keys:
                (e, n) - public key
                (d, n) - private key
            */

            List<string> result = new List<string>();
            BigInteger bignum;

            for (int i = 0; i < message.Length; i++)
            {
                int index = Array.IndexOf(_alphabet, message[i]);
                bignum = new BigInteger(index);
                bignum = BigInteger.Pow(bignum, (int)e);
                BigInteger n_big = new BigInteger((int)n);
                bignum %= n_big;
                result.Add(bignum.ToString());
            }
            return result;
        }

        public static string RSADecrypt(List<string> encryptedmessage, long d, long n)
        {
            string result = "";
            CheckAlphabet();
            BigInteger bignum;

            foreach (string item in encryptedmessage)
            {
                bignum = new BigInteger(Convert.ToDouble(item));
                bignum = BigInteger.Pow(bignum, (int)d);
                BigInteger n_big = new BigInteger((int)n);
                bignum %= n_big;
                int index = Convert.ToInt32(bignum.ToString());
                result += _alphabet[index].ToString();
            }
            return result;
        }
    }
}