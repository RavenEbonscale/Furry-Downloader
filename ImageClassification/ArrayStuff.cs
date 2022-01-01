using System;


namespace ArryStuff
{
    static public class ArryStuff
    {
        /// <summary>
        /// Returns the index number with the highest value
        /// </summary>
        /// <param name="Arry">A Float Arry</param>
        /// <returns> Index</returns>
        static public int ArgsMax(this float[] Arry)
        {

                float? maxVal = null; //nullable so this works even if you have all super-low negatives
                int index = -1;
                for (int i = 0; i < Arry.Length; i++)
                {
                    float thisNum = (float)Arry[i];
                    if (!maxVal.HasValue || thisNum > maxVal.Value)
                    {
                        maxVal = thisNum;
                        index = i;
                    }

                }


                return index;
            


        }



    }
}
