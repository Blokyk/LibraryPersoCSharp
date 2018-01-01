namespace Library.Math
{
    using System;

    public static class Math
    {
        public static int Sqrt(int radacan)
        {
            bool isFounded = false;
            Random random = new Random();
            int guess = random.Next(1, radacan);

            while (!isFounded)
            {
                try
                {
                    if (Convert.ToInt32(radacan / guess) == guess)
                    {
                        isFounded = true;
                    }
                    else if (Convert.ToInt32(radacan / guess) < guess)
                    {
                        guess--;
                    }
                    else if (Convert.ToInt32(radacan / guess) > guess)
                    {
                        guess++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(guess + " with a radacan of " + radacan);
                    return 0;
                }
            }

            return guess;
        } 
        
        public static int InvertInRange(int n, int max)
        {
            return max / 2 + (max / 2 - n);
        }       
    }
}
