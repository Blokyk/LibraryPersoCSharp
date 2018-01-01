namespace Library.Image.Filtering
{
    using System.Collections.Generic;
    using Library.Collections;
    public static class InternalExtendFilter
    {
        public static float[,,] Apply(this Filter filter, float[,,] bitmap, bool isInit = false)
        {
            float[,,] output;

            if (!isInit)
            {
                output = PreApply(bitmap);
            } else
            {
                output = bitmap;
            }
            for (int d = 0; d < 2; d++)
            {                
                for (int x = 0; x < bitmap.GetLength(0) || x < 3; x++)
                {
                    for (int y = 0; y < bitmap.GetLength(1) || y < 3; y++)
                    {
                        //Check if the "pixel" is one that has been pre-filled with a 0 by PreApply()
                        if (output[x, y, d] != float.Epsilon)
                        {
                            List<float> list = new List<float>() { 
                            //First Line
                            output[x - 2, y - 2, d] * filter.filter[0, 0],
                            output[x - 1, y - 2, d] * filter.filter[1, 0],
                            output[x, y - 2, d] * filter.filter[2, 0],
                            output[x + 1, y - 2, d] * filter.filter[3, 0],
                            output[x + 2, y - 2, d] * filter.filter[4, 0],

                            //Second Line
                            output[x - 2, y - 1, d] * filter.filter[0, 1],
                            output[x - 1, y - 1, d] * filter.filter[1, 1],
                            output[x, y - 1, d] * filter.filter[2, 1],
                            output[x + 1, y - 1, d] * filter.filter[3, 1],
                            output[x + 2, y - 1, d] * filter.filter[4, 1],

                            //Third Line
                            output[x - 2, y, d] * filter.filter[0, 2],
                            output[x - 1, y, d] * filter.filter[1, 2],
                            output[x, y, d] * filter.filter[2, 2],
                            output[x + 1, y, d] * filter.filter[3, 2],
                            output[x + 2, y, d] * filter.filter[4, 2],

                            //Fourth Line
                            output[x - 2, y + 1, d] * filter.filter[0, 3],
                            output[x - 1, y + 1, d] * filter.filter[1, 3],
                            output[x, y + 1, d] * filter.filter[2, 3],
                            output[x + 1, y + 1, d] * filter.filter[3, 3],
                            output[x + 2, y + 1, d] * filter.filter[4, 3],

                            //Fifth Line
                            output[x - 2, y + 2, d] * filter.filter[0, 4],
                            output[x - 1, y + 2, d] * filter.filter[1, 4],
                            output[x, y + 2, d] * filter.filter[2, 4],
                            output[x + 1, y + 2, d] * filter.filter[3, 4],
                            output[x + 2, y + 2, d] * filter.filter[4, 4],

                            };

                            output[x, y, d] = list.Sum();
                        } else
                        {
                            //System.Console.WriteLine(x + " " + y + " " + d);
                        }

                        output[x,y,d] = 

                        //System.Console.WriteLine(output[x, y, d]);
                    }
                }
            }

            return output;
        }

        private static float[,,] PreApply(float[,,] buffer)
        {
            float[,,] output = new float[buffer.GetLength(0) + 2, buffer.GetLength(1) + 2, 3];
            for (int d = 0; d < 2; d++)
            {
                for (int x = 0; x < buffer.GetLength(0); x++)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        output[x, y, d] = float.Epsilon;
                    }
                }

                for (int y = 0; y < buffer.GetLength(1); y++)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        output[x, y, d] = float.Epsilon;
                    }
                }

                for (int x = 2; x < buffer.GetLength(0) - 2; x++)
                {
                    for (int y = 2; y < buffer.GetLength(1) - 2; y++)
                    {
                        output[x, y, d] = buffer[x, y, d];
                    }
                }

                for (int x =buffer.GetLength(0); x > 0; x--)
                {
                    for (int y = buffer.GetLength(1);  y > buffer.GetLength(1) - 2; y--)
                    {
                        output[x, y, d] = float.Epsilon;
                    }
                }

                for (int x = buffer.GetLength(0); x > buffer.GetLength(0) - 2; x--)
                {
                    for (int y = buffer.GetLength(1); y > 0; y--)
                    {
                        output[x, y, d] = float.Epsilon;
                    }
                }
            }

            return output;
        }
    }
}
