using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISM_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array1 = new int[,]
            {
                {1, 6, 3, -12},
                {1, 10, -2, 1},
                {3, 8, 4, 5},
                {4, -11, 1, 4},
                {5, 9, 11, 1}
            };

            int[,] array2 = new int[,]
            {
                {6, 6, 1, 9},
                {-7, 3, -2, 1},
                {3, -6, 1, 5},
                {33, 21, 3, 9},
                {5, 11, 6, 1}
            };


            Console.WriteLine("Первая матрица");
            GetMatrix(array1);

            Console.WriteLine("Вторая матрица");
            GetMatrix(array2);

            Console.WriteLine("Вторая матрица тр.");
            int[,] array2T = GetTrans(array2);
            GetMatrix(array2T);

            bool k = true;
            while(k)
            {
                Console.WriteLine("Выберите действие:\n1) Найти максимумы матриц\n2) Найти минимумы матриц по строкам\n3) Перемножить матрицы 1 и 2 тр." +
                    "\n0) Выйти из программы");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine($"Максимальное значение в первой матрице - {GetMax(array1)}");
                        Console.WriteLine($"Максимальное значение в второй матрице - {GetMax(array2)}");
                        break;
                    case 2:
                        Console.WriteLine("Минимумы первой матрицы");
                        GetMin(array1);
                        Console.WriteLine("Минимумы второй матрицы");
                        GetMin(array2);
                        break;
                    case 3:
                        Console.WriteLine("Произведение первой и второй транспортированной матрицы");
                        int[,] array3 = GetMult(array1, array2T);
                        GetMatrix(array3);
                        break;
                    default:
                        if (n == 0)
                        {
                            k = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный вариант");
                            break;
                        }
                }
            }
        }

        static void GetMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int GetMax(int[,] m)
        {
            int max = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if(m[i, j] > max) max = m[i, j];
                }
            }
            return max;
        }

        static void GetMin(int[,] m)
        {
            int n = m.GetLength(0);
            int[] min = new int [n];
            for (int i = 0; i < n; i++)
            {
                min[i] = 100;
            }
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] < min[i]) min[i] = m[i, j];
                }
            }
            for (int i = 0; i < min.Length; i++)
            {
                Console.Write($"{min[i]} ");
            }
            Console.WriteLine();
        }

        static int[,] GetMult(int[,] a, int[,] b)
        {

            int[,] c = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
                return c;
        }
        static int[,] GetTrans(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int[,] b = new int [m, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    b[j, i] = a[i, j];
                }
            }
            return b;
        }
    }
}

