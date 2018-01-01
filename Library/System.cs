namespace System
{
    public static class ExConsole
    {
        /// <summary>
        /// Wait until a specified key (ConsoleKey.Escape is set by default) is pressed
        /// </summary>
        /// <param name="key">The key to press. Set to escape by default. See <see cref="ConsoleKey"/> for more information</param>
        /// <param name="message">Message to display. Set to "Press key to continue or quit</param>
        public static void WaitUntil(ConsoleKey key = ConsoleKey.Escape, string message = "")
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Press " + key + " to continue or quit");
            }

            while (!key.IsPressed())
            {

            }
        }



        /// <summary>
        /// Check if the key is pressed
        /// </summary>
        public static bool IsPressed(this ConsoleKey key)
        {
            if (key == Console.ReadKey().Key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
