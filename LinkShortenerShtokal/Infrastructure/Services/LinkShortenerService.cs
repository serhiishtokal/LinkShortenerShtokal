using System.Text;

namespace LinkShortenerShtokal.Infrastructure.Services
{
    public interface ILinkShortenerService
    {
        //int Decode(string s);
        string Encode(int i);
    }

    public class LinkShortenerService : ILinkShortenerService
    {
        public static readonly string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static readonly int BASE = ALPHABET.Length;

        public string Encode(int i)
        {
            var k = i << 1;
            if (i == 0) return ALPHABET[0].ToString();

            var stringBuilder = new StringBuilder();
            while (i > 0)
            {
                stringBuilder.Append(ALPHABET[i % BASE]);
                i = i / BASE;
            }
            var charArray = stringBuilder.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
