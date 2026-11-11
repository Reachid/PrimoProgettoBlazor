namespace PrimoProgettoBlazor.Components.Classi
{
    public static class Helper
    {
        public static string GetSubString(this string stringa, int limite)
        {
            if (stringa.Length > limite) return stringa.Substring(0, limite) + "...";
            return stringa;
        }
    }
}
