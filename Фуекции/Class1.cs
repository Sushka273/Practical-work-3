using System;

namespace Функции
{
    public class Class1
    {
        public static string Ras(int[,] matrix, int[] mas)
        {
            int a = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   a = a + matrix[i, j];                   
                }
                mas[i] = a;
                a = 0;
            }
            string num ="";
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                if (mas[i] != 0)
                {
                    num += Convert.ToString(mas[i] + " ");
                }
            }
            return num;

        }
    }
}
