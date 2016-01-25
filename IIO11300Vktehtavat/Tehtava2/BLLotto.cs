using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava2
{
    class Lotto
    {
        

        private int times;
      
        public int Times
        {
            get { return times; }
            set { times = value; }
        }

        public string DrawLottoNumbers()
        {
            return DrawLottoNumbers2();
            
        }

        public string DrawVikingNumbers()
        {
            return DrawVikingNumbers2();
        }

        public string DrawEuroNumbers()
        {
            return DrawEuroNumbers2();
        }

        private string DrawLottoNumbers2()
        {
           
                int[] arr1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                Random random = new Random();
                string lottonumbers = "";
                for (int k = 0; k < times; k++)
                {

                    for (int i = 0; i < 7; i++)
                    {
                        int randomNumber = random.Next(1, 40);

                        for (int j = 0; j < 7; j++)
                        {
                            if (randomNumber != arr1[j])
                            {

                            }
                            else
                            {
                                randomNumber = random.Next(1, 40);
                                j = -1;
                            }
                        }

                        arr1[i] = randomNumber;

                    }
                    lottonumbers = lottonumbers + string.Join(", ", arr1) + Environment.NewLine;

                }
                return lottonumbers;
        }

        private string DrawVikingNumbers2()
        {

            int[] arr2 = new int[6] { 0, 0, 0, 0, 0, 0};
            Random random = new Random();
            string lottonumbers = "";
            for (int k = 0; k < times; k++)
            {

                for (int i = 0; i < 6; i++)
                {
                    int randomNumber = random.Next(1, 49);

                    for (int j = 0; j < 6; j++)
                    {
                        if (randomNumber != arr2[j])
                        {

                        }
                        else
                        {
                            randomNumber = random.Next(1, 49);
                            j = -1;
                        }
                    }

                    arr2[i] = randomNumber;

                }
                lottonumbers = lottonumbers + string.Join(", ", arr2) + Environment.NewLine;

            }
            return lottonumbers;
        }

        private string DrawEuroNumbers2()
        {

            int[] arr3 = new int[5] { 0, 0, 0, 0, 0};
            int[] arr4 = new int[2] { 0, 0 };
            Random random = new Random();
            string lottonumbers = "";
            for (int k = 0; k < times; k++)
            {

                for (int i = 0; i < 5; i++)
                {
                    int randomNumber = random.Next(1, 51);

                    for (int j = 0; j < 5; j++)
                    {
                        if (randomNumber != arr3[j])
                        {

                        }
                        else
                        {
                            randomNumber = random.Next(1, 51);
                            j = -1;
                        }
                    }

                    arr3[i] = randomNumber;

                }

                for (int l = 0; l < 2; l++)
                {
                    int randomNumber2 = random.Next(1, 9);

                    for (int m = 0; m < 2; m++)
                    {
                        if (randomNumber2 != arr4[m])
                        {

                        }
                        else
                        {
                            randomNumber2 = random.Next(1, 9);
                            m = -1;
                        }
                    }
                    arr4[l] = randomNumber2;
                }


                lottonumbers = lottonumbers + string.Join(", ", arr3)+ " * " + string.Join(", ",arr4) + Environment.NewLine;

            }
            return lottonumbers;
        }
    }
}
