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
// не доделано! Не получилось реализовать разряжение треугольника для вывода значений 
// в виде пирамиды в шахматном порядке
void PrintEqTriangle(int[,] matrix)
{
    int[,] Output=new int[matrix.GetLength(0), matrix.GetLength(1)*2-1];
    int k=0;
    int l=matrix.GetLength(0)-1;//сдвиг слева - уменьшаем на каждой строке
    int m=0;
    int count=0;
    
    for (int i = 0; i < Output.GetLength(0); i++)
    {
        
           for (k = 0; k < matrix.GetLength(1); k++)
           {
             if(matrix[i,k]!=0&&i==0)
             {
                  //count++;
                    Output[i,k+l]=matrix[i,k];
                 
                 
                 //Console.WriteLine($"matrix non zero: {matrix[i,k]} k={k} i={i} j={j}");
             }

             if(matrix[i,k]!=0&&i==1)
             {
                  //count++;
                    Output[i,k+l]=matrix[i,k];
                 
                 
                 //Console.WriteLine($"matrix non zero: {matrix[i,k]} k={k} i={i} j={j}");
             }
           }

           for (k = 0; k < matrix.GetLength(1); k++)
           {
             if(matrix[i,k]!=0)
             {
                  count++;
                   // Output[i,k+l]=matrix[i,k];
                 
                 
                 //Console.WriteLine($"matrix non zero: {matrix[i,k]} k={k} i={i} j={j}");
             }
           }
         
         

        
        l--;
    }

int[,] Output2=new int[matrix.GetLength(0), matrix.GetLength(1)*2-1];

for (int x = 0; x < Output.GetLength(0); x++)
    {
        for (int y= 0; y < Output.GetLength(1) ; y++)
        {
            if(Output[x,y]!=0)
            {
               Output2[x,y+m]=Output[x,y];
            }

        }
       m++;
    }


   for (int x = 0; x < Output.GetLength(0); x++)
    {
        for (int y= 0; y < Output.GetLength(1); y++)
        {
            Console.Write($"{Output2[x, y]} [{x},{y}] ");

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
    int [,] answer= new int[rowNumber,rowNumber];
    
    
    for (int i = 0; i < answer.GetLength(0); i++)
    {
        for (int j = 0; j < answer.GetLength(1); j++)
        {
            
            answer[i,j]=(int) PascalTriangleValue(i,j);

        }
        
    }
   return answer;
}





int r = Prompt("enter pascal rows number: ");

System.Console.WriteLine($"Pascal triangle is: ");
PrintMatrix(PascalTriangle(r));

System.Console.WriteLine($"XXXXXXXXXXXXXXXXXXXXXX ");
PrintEqTriangle(PascalTriangle(r));









