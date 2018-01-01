namespace Library.Image.Filtering
{
    using System;
    using System.Collections.Generic;

    public class Filter
    {
        public float[,] filter = new float[0, 0];

        public static Dictionary<FilterShape, float> shapeDic = InitDictionary();

        public Filter(FilterShape shape)
        {
            filter = new float[5, 5];

            if (shape == FilterShape.Donut)
            {
                int y = 0;
                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = -0.25f;
                }

                y++;

                filter[0, y] = filter[4, y] = -0.25f;
                filter[1, y] = filter[3, y] = 1.5f;
                filter[2, y] = 2;

                y++;

                filter[0, y] = filter[4, y] = -0.25f;

                filter[1, y] = filter[3, y] = 2f;
                filter[2, y] = -2f;

                y++;

                filter[0, y] = filter[4, y] = -0.25f;

                y++;

                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = -0.25f;
                }

            }
            else if (shape == FilterShape.Horizontal)
            {
                int y = 0;

                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = -0.25f;
                }

                y++;

                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = -2;
                }

                y++;

                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = 2;
                }

                y++;

                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = -2;
                }

                y++;

                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = -0.25f;
                }
            }
            else if (shape == FilterShape.Sphere)
            {
                int y = 0;

                filter[0, y] = filter[4, y] = -0.25f;
                filter[1, y] = filter[3, y] = -2;
                filter[2, y] = 2;

                y++;

                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = -2;
                    filter[i++, y] = 2;
                }

                y++;

                filter[0, y] = filter[4, y] = 2;
                filter[1, y] = filter[3, y] = -2;
                filter[2, y] = -0.25f;

                for (int i = 0; i < 5; i++)
                {
                    filter[i, y] = -2;

                    i++;

                    filter[i, y] = 2;
                }

                y++;

                filter[0, y] = filter[4, y] = -0.25f;
                filter[1, y] = filter[3, y] = -2;
                filter[2, y] = 2;
            }
            else if (shape == FilterShape.Vertical)
            {
                int x = 0;

                for (int i = 0; i < 5; i++)
                {
                    filter[x, i] = -0.25f;
                }

                x++;

                for (int i = 0; i < 5; i++)
                {
                    filter[x, i] = -2;
                }

                x++;

                for (int i = 0; i < 5; i++)
                {
                    filter[x, i] = 2;
                }

                x++;

                for (int i = 0; i < 5; i++)
                {
                    filter[x, i] = -2;
                }

                x++;

                for (int i = 0; i < 5; i++)
                {
                    filter[x, i] = -0.25f;
                }
            }
            else if (shape == FilterShape.Cube)
            {
                for (int i = 0; i < 5; i++)
                {
                    filter[i, 0] = -0.25f;
                }

                for (int y = 0; y < 3; y++)
                {
                    filter[0, y] = -0.25f;

                    for (int i = 0; i < 3; i++)
                    {
                        filter[i, y] = 2;
                    }

                    filter[4, y] = -0.25f;
                }
            }
            else if (shape == FilterShape.Diagonal)
            {
                for (int i = 0; i < 3; i++)
                {
                    filter[i, 0] = -0.25f;
                }

                for (int i = 0; i < 3; i++)
                {
                    filter[0, i] = -0.25f;
                }

                filter[1, 1] = -0.25f;

                filter[3, 0] = filter[2, 1] = filter[1, 2] = filter[0, 3] = filter[4, 1] = filter[3, 2] = filter[2, 1] = filter[1, 0] = -2;

                filter[4, 0] = filter[3, 1] = filter[2, 2] = filter[1, 3] = filter[0, 4] = 2;

                filter[4, 4] = filter[3, 4] = filter[2, 4] = filter[3, 3] = filter[4, 3] = filter[4, 2] = -0.25f;
            }
            else if (shape == FilterShape.Void)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        filter[x, y] = -2;
                    }
                }
            }
            else if (shape == FilterShape.Full)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        filter[x, y] = 2;
                    }
                }
            } else
            {
                throw new Exception();
            }

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    //Console.WriteLine(filter[x, y]);
                }
            }

            
        }

        public Filter(float[,,] newFilter)
        {
            filter = new float[newFilter.GetLength(0), newFilter.GetLength(1)];
            for (int x = 0; x < filter.GetLength(0); x++)
            {
                for (int y = 0; y < filter.GetLength(1); y++)
                {
                    filter[x, y] = (newFilter[x, y, 0] + newFilter[x, y, 1] + newFilter[x, y, 2]) / 3;
                }
            }
        }

        public static Dictionary<FilterShape, float> InitDictionary()
        {
            Dictionary<FilterShape, float> output = new Dictionary<FilterShape, float>();

            output.Add(FilterShape.Full, 12750);

            output.Add(FilterShape.Void, -12750);

            output.Add(FilterShape.Donut, 255 * -0.25f * 16 + 255 * 1.5f * 4 + 255 * 2 * 4 + 255 * -2);

            output.Add(FilterShape.Cube, 255 * -0.25f * 16 + 255 * 1.5f * 4 + 255 * 2 * 5);

            output.Add(FilterShape.Horizontal, 255 * -0.25f * 10 + 255 * -2 * 10 + 255 * 2 * 5);

            output.Add(FilterShape.Vertical, 255 * -0.25f * 10 + 255 * -2 * 10 + 255 * 2 * 5);

            output.Add(FilterShape.Diagonal, 255 * -0.25f * 12 * 255 * -2 * 8 + 255 * 2 * 5);

            return output;
        }
    }


    /// <summary>
    /// Enumerate what shape would the filter take. Check definition to have the entire list
    /// </summary>
    public enum FilterShape
    {
        Donut, Cube, Sphere, Vertical, Horizontal, Diagonal, Void, Full
    }
}