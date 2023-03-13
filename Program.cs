using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationwithGaussElimination
{
    class Program
    {
        static void Main()
        {
            // Define the augmented matrix
            double[,] matrix = { { 1, 2, 1, -1, 5 }, { 2, 1, -3, 1, 4 }, { 1, 1, 1, 1, 3 }, { -1, 1, -1, 2, 1 } };

            // Perform Gaussian elimination
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                // Swap rows if necessary
                if (matrix[i, i] == 0)
                {
                    for (int j = i + 1; j < rows; j++)
                    {
                        if (matrix[j, i] != 0)
                        {
                            double temp;
                            for (int k = 0; k < cols; k++)
                            {
                                temp = matrix[i, k];
                                matrix[i, k] = matrix[j, k];
                                matrix[j, k] = temp;
                            }
                            break;
                        }
                    }
                }

                // Reduce the current row
                double pivot = matrix[i, i];
                for (int j = i; j < cols; j++)
                {
                    matrix[i, j] /= pivot;
                }

                // Eliminate the entries below the pivot
                for (int j = i + 1; j < rows; j++)
                {
                    double factor = matrix[j, i];
                    for (int k = i; k < cols; k++)
                    {
                        matrix[j, k] -= factor * matrix[i, k];
                    }
                }
            }

            // Perform back substitution
            double[] solution = new double[cols - 1];
            for (int i = rows - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < cols - 1; j++)
                {
                    sum += matrix[i, j] * solution[j];
                }
                solution[i] = matrix[i, cols - 1] - sum;
            }

            // Print the solution
            Console.WriteLine("Solution:");
            Console.WriteLine($"X1 = {solution[0]}");
            Console.WriteLine($"X2 = {solution[1]}");
            Console.WriteLine($"X3 = {solution[2]}");
            Console.WriteLine($"X4 = {solution[3]}");

            Console.ReadKey();
        }

    }
}
