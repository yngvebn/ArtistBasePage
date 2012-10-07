namespace Domain
{
    public static class StringExtensions
    {
        public static string Encrypt(this string text)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
            data = x.ComputeHash(data);
            string md5Hash = System.Text.Encoding.ASCII.GetString(data);
            return md5Hash;
        }
    }
}