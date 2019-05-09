namespace Base64.Core
{
    public class Base64Encoder : BaseEncoder
    {
        const string CharacterSetBase = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public readonly char PlusChar;
        public readonly char SlashChar;

        public static readonly Base64Encoder Default = new Base64Encoder('+', '/', true);

        public Base64Encoder(char plusChar, char slashChar, bool paddingEnabled)
            : base((CharacterSetBase + plusChar + slashChar).ToCharArray(), paddingEnabled)
        {
            PlusChar = plusChar;
            SlashChar = slashChar;
        }

        public static byte[] Base64Decode(string data)
        {
            return Default.FromBase(data);
        }

        public static string Base64Encode(byte[] data)
        {
            return Default.ToBase(data);
        }
    }
}