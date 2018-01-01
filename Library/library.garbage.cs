namespace Library.Garbage
{
    using System;

    public static class ExtendChar
    {       

        public static string UpperFirstLetter(this string input)
        {
            string output = "";

            try
            {
                output += Char.ToUpper(input[0]);

                for (int i = 1; i < input.Length; i++)
                {
                    output += input[i];
                }
            }
            catch (Exception)
            {

            }

            return output;
        }
    }
}