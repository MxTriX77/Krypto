namespace KMP.Core
{
    public class KMPCore
    {
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

        public static int Search(string needle, string haystack)
        {
            int M = needle.Length;
            int N = haystack.Length;
            int[] LPS = new int[M];
            int j = 0;
            int result = -1;

            Prefix(needle, M, LPS);

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
                    j = LPS[j - 1];
                }

                else if (i < N && needle[j] != haystack[i])
                {
                    if (j != 0)
                        j = LPS[j - 1];
                    else
                        i = i + 1;
                }
            }

            return result;
        }
    }
}
