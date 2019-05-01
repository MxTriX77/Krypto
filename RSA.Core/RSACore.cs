using System;
using System.Collections.Generic;
using System.Numerics;

namespace RSA.Core
{
    public class RSACore
    {
        private static string charset = @" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890123456789!?()'@&%$/\|<>*#^_[]{}`~+=-:;,.";

        public static void SetAlphabet(string alphabet)
        {
            if (alphabet.Length != 0) { charset = alphabet; }
        }

        public static void GetPrivateKey(long p, long q, out long d, out long n)
        {
            n = p * q;
            d = Calculate_d((p - 1) * (q - 1));
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

        private static void Prefix(string needle, int M, int[] LPS)
        {
            int i = 1;
            int length = 0;
            LPS[0] = 0;

            while (i < M)
            {
                if (needle[i] == needle[length])
                {
                    length++;
                    LPS[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = LPS[length - 1];
                    }
                    else
                    {
                        LPS[i] = length;
                        i++;
                    }
                }
            }
        }

        private static int KMPSearch(string needle, string haystack)
        {
            int M = needle.Length;
            int N = haystack.Length;
            int[] lps = new int[M];
            int j = 0;
            int result = -1;

            Prefix(needle, M, lps);

            int i = 0;
            while (i < N)
            {
                if (needle[j] == haystack[i])
                {
                    j++;
                    i++;
                }
                if (j == M)
                {
                    result = i - j;
                    j = lps[j - 1];
                }

                else if (i < N && needle[j] != haystack[i])
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }

            return result;
        }

        public static List<string> RSAEncrypt(string message, long p, long q)
        {
            // If either p or q are not prime numbers, then RSA is not applicable.
            if (!IsPrime(p) && !IsPrime(q)) { return null; }
            else
            {
                long n;
                long phi;
                long e;
                long d;

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
                    int index = KMPSearch(Char.ToString(message[i]), charset);
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