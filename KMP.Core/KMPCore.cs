namespace KMP.Core
{

    // Knuth-Morris-Pratt substring-searching algorithm. Used here instead of the standard IndexOf inasmuch as searching one symbol in a long string (i.e. alphabet) would be asymptotically faster.

    public class KMPCore
    {

        // Prefix function.
        private static void Prefix(string needle, int M, int[] LPS)
        {
            int i = 1;

            // Length of the previous longest prefix suffix.
            int length = 0;

            LPS[0] = 0;

            // Calculating LPS[i] for i = 1 to M - 1.
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
                        length = LPS[length - 1];

                    // If no LPS ends with needle[i] then set LPS[i] = 0 and go to next iteration.
                    else
                    {
                        LPS[i] = 0;
                        i++;
                    }
                }
            }
        }

        // Searching algorithm using generated prefix.
        public static int Search(string needle, string haystack)
        {
            int M = needle.Length;
            int N = haystack.Length;
            int[] LPS = new int[M];
            int j = 0;
            int result = -1;
            int i = 0;

            Prefix(needle, M, LPS);

            // Match with prefix from i = 1 to N - 1.
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
                        i++;
                }
            }

            return result;
        }
    }
}
