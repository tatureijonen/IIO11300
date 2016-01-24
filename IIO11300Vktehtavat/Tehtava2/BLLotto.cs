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

        private string DrawLottoNumbers2()
        {
            
            int[] arr1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            Random random = new Random();
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

            string lottonumbers = string.Join(", ", arr1);
            return lottonumbers;
        }
    }
}
