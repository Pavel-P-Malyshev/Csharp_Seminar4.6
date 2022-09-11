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

string GetSpaces(int totalLength)
{
        string result = string.Empty;
        for (int i = 0; i < totalLength; i++)
        {
            result += " ";
        }

        Console.WriteLine($"result is: XX{result}XX");
        return result;
}

int MaxDigitsNum(int[,] matrix)
{
    int answer=0;
    int[] digits=new int[matrix.GetLength(0)*matrix.GetLength(1)];
    int digits_idx=-1;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
           digits_idx++;
             while(matrix[i,j]>0)
             {
                matrix[i,j]=matrix[i,j]/10;
                digits[digits_idx]++;
             }
           
        }
        
    }
    
    //ищем максимум
    answer=digits[0];
    for (int k = 0; k < digits.Length; k++)
    {
        if(digits[k]>answer) answer=digits[k];
        
    }

    Console.WriteLine($"max digits is: {answer}");

    return answer;
    
}



void PrintMatrix(int[,] matrix)
{
    //string spaces=GetSpaces(MaxDigitsNum(matrix));
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i,j]==0)
            {
                //Console.Write($"{spaces}");
                Console.Write(" ");
            }
            else
            {
                Console.Write($"{matrix[i, j]}");
            }
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









