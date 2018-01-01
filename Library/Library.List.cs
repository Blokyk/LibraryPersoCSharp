namespace Library.Collections
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class ExtendList
    {
        /// <summary>
        /// Return the sum of every numbers in the given list
        /// </summary>
        public static int Sum(this List<int> list)
        {
            int output = 0;
            for (int i = 0; i < list.Count; i++)
            {
                output += list[i];
            }

            return output;
        }

        /// <summary>
        /// Return the sum of every numbers in the given list
        /// </summary>
        public static float Sum(this List<float> list)
        {
            float output = 0;
            for (int i = 0; i < list.Count; i++)
            {
                output += list[i];
            }

            return output;
        }

        /// <summary>
        /// Return the sum of every numbers in the given list
        /// </summary>
        public static double Sum(this List<double> list)
        {
            double output = 0;
            for (int i = 0; i < list.Count; i++)
            {
                output += list[i];
            }

            return output;
        }

        public static T[] ToArrayOf<T>(this List<T> list)
        {
            T[] output = new T[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                output[i] = list[i];
            }

            return output;
        }

        public static string Sum(this List<string> list)
        {
            string output = "";
            for (int i = 0; i < list.Count; i++)
            {
                output += list[i];
            }

            return output;
        }
    }

    public static class ExtendArray
    {
        public static List<T> ToListOf<T>(this T[] list)
        {
            List<T> output = new List<T>(list.Length);

            for (int i = 0; i < list.Length; i++)
            {
                output.Add(list[i]);
            }

            return output;
        }

        public static bool Contain(this int[,] buffer, int obj)
        {
            for (int x = 0; x < buffer.GetLength(0); x++)
            {
                for (int y = 0; x < buffer.GetLength(1); y++)
                {
                    if (buffer[x,y] == obj)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static byte[] ToBytes(this object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            byte[] bytes = ms.ToArray();
            return bytes;
        }
    }
}