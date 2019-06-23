using KMP.Core;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace RSA.Core
{
    public class RSACore
    {
        private static string charset = @" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяЄєҐґІЇїі01234567890123456789!?()'@&%$/\|<>*#^_[]{}`~+=-:;,.";
        private static long[] fermatnumbers = { 4294967297, 65537, 257, 17, 5, 3 };

        // Euclidean algorithm.
        private static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        // Modular multiplicative inversion, so that a = a^-1 (mod n).
        // This method doesn't return a corresponding result in case there are no inverse elements of "a" in ring modulo "n".
        // The reason is because within this project there won't be such a situation, so hence such a result won't be expected.
        private static BigInteger ModularInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n;
            BigInteger v = 0;
            BigInteger d = 1;

            while (a > 0)
            {
                BigInteger t = i / a;
                BigInteger x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) { v = (v + n) % n; }

            return v;
        }

        // Chooses higher possible fermat number as "e" parameter.
        private static BigInteger Calculate_e(BigInteger phi)
        {
            int index = 0;
            while (index < fermatnumbers.Length)
            {
                if (fermatnumbers[index] < phi && GCD(fermatnumbers[index], phi) == 1) { break; } else index++;
            }

            return fermatnumbers[index];
        }

        private static BigInteger Calculate_d(BigInteger e, BigInteger phi)
        {
            return ModularInverse(e, phi);
        }

        public static BigInteger Modulus(BigInteger p, BigInteger q)
        {
            return p * q;
        }

        public static BigInteger EulersFunction(BigInteger p, BigInteger q)
        {
            return (p - 1) * (q - 1);
        }

        public static bool IsPrime(BigInteger n)
        {
            if (n < 2) { return false; }
            if (n == 2) { return true; }
            for (ulong i = 2; i < n; i++)
            {
                if (n % i == 0) { return false; }
            }

            return true;
        }

        public static void GenerateKeys(BigInteger p, BigInteger q, out BigInteger e, out BigInteger d, out BigInteger n)
        {
            BigInteger phi;

            // Calculating modulus.
            n = Modulus(p, q);

            // Calculating Euler's function.
            phi = EulersFunction(p, q);

            // Calculating public exponent.
            e = Calculate_e(phi);

            // Calculating private exponent.
            d = Calculate_d(e, phi);

            /* Hence we have 2 pairs of keys:
                (e, n) - public key
                (d, n) - private key
             */
        }

        public static void SetAlphabet(string alphabet)
        {
            if (alphabet.Length != 0) { charset = alphabet; }
        }

        public static string GetAlphabet()
        {
            return charset;
        }

        public static void GetEncryptionParameters(BigInteger p, BigInteger q, out BigInteger n, out BigInteger phi, out BigInteger d, out BigInteger e)
        {
            n = Modulus(p, q);
            phi = EulersFunction(p, q);
            e = Calculate_e(phi);
            d = Calculate_d(e, phi);
        }

        public static List<string> Encrypt(string message, BigInteger e, BigInteger n)
        {
            // If either p or q is not a prime number, then RSA is not applicable.
            if ((!IsPrime(e) && !IsPrime(e)) || message == "") { return null; }
            else
            {
                List<string> result = new List<string>();
                BigInteger M;
                BigInteger Me;
                BigInteger C;
                int index;

                for (int i = 0; i < message.Length; i++)
                {
                    index = KMPCore.Search(Char.ToString(message[i]), charset);
                    M = new BigInteger(index);

                    // Encryption: C[i] = M[i]^e (mod n).
                    Me = BigInteger.Pow(M, (int)e);
                    C = Me % n;
                    result.Add(C.ToString());
                }
                return result;
            }
        }

        public static string Decrypt(List<string> encryptedmessage, BigInteger d, BigInteger n)
        {
            string result = "";
            int index;
            BigInteger C;
            BigInteger Cd;
            BigInteger M;

            foreach (string item in encryptedmessage)
            {
                C = new BigInteger(Convert.ToDouble(item));

                // Decryption: M[i] = C[i]^d (mod n).
                Cd = BigInteger.Pow(C, (int)d);
                M = Cd % n;
                index = Convert.ToInt32(M.ToString());
                result += charset[index].ToString();
            }

            return result;
        }

    }
}