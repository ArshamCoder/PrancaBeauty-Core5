namespace Framework.Common.ExMethod
{
    public static class LongEx
    {
        public static string GetFileSizeName(this long fileSize)
        {

            string[] names = { "B", "KB", "MB", "GB", "TB", "ExB" };
            double number = fileSize;
            int index = 0;

            while (number > 1024)
            {
                number = number / 1024;
                index++;
            }

            return number.ToString("0.#") + " " + names[index];
        }
    }
}
