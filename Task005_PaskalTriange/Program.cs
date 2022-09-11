/*
Задача 5: Вывести первые N строк треугольника 
Паскаля. Сделать вывод в виде равнобедренного 
треугольника
*/






int Prompt(string message)
{
    System.Console.Write(message);
    string readValue = Console.ReadLine();
    return int.Parse(readValue);
}



int[,] FillMatrix(int rows, int columns, int range)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = new Random().Next(0, range + 1);

        }

    }

    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} [{i},{j}] ");

        }
        Console.WriteLine();
    }

}


double PascalTriangleValue(int N, int K)
{
    return ((N<K)?0:((K==0)?1:((N-K+1)/(double) K*PascalTriangleValue(N,K-1))));
}

int[,] PascalTriangle(int rowNumber)
{
    int [,] answer= new int[rowNumber,rowNumber*2-1];
    int l=answer.GetLength(0)-1;
    
    
    for (int i = 0; i < answer.GetLength(0); i++)
    {
        for (int j = 0; j < answer.GetLength(1); j++)
        {
               
                if (PascalTriangleValue(i, j) != 0/*&&i==0)||(PascalTriangleValue(i,j)!=0&&i==1)*/)
                {
                    
                    if(j<2)
                    {
                        answer[i, (j%2==0) ? j + l : j+l+1] = (int)PascalTriangleValue(i, j);
                    }
                    else
                    {
                        answer[i, j*2+l] = (int)PascalTriangleValue(i, j);
                    }
                    
                    //answer[i,  j + l+1 ] = (int)PascalTriangleValue(i, j);
                }
            

        }
        l--;
    }
   return answer;
}





int r = Prompt("enter pascal rows number: ");

System.Console.WriteLine($"Pascal triangle is: ");
PrintMatrix(PascalTriangle(r));

//System.Console.WriteLine($"XXXXXXXXXXXXXXXXXXXXXX ");
//PrintEqTriangle(PascalTriangle(r));









