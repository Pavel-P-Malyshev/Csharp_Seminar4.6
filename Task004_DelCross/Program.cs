/*
Задача 4: Задайтедвумерный массив из целых чисел. 
Напишите программу, которая удалит строку и столбец, на 
пересечении которых расположен наименьший элемент 
массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Наименьший элемент - 1, на выходе получим 
следующий массив:
9 4 2
2 2 6
3 4 7
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

int[] MinElementIndices(int[,] matrix)
{
    int minElement=matrix[0,0];
    int[] indices=new int[2];


    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < minElement)
            {
                 minElement = matrix[i, j];
                 indices[0]=i;
                 indices[1]=j;

            }

        }
    }

    return indices;
}

int[,] DeleteMatrixRow(int[,] matrix, int rowToDelete)
{
    int[,] result=new int[matrix.GetLength(0)-1, matrix.GetLength(1)];
    int newIndex=0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(i!=rowToDelete)
            {
               result[newIndex,j]=matrix[i,j];

            } 

        }
          if(i!=rowToDelete) newIndex++;
        
    }

    return result;
}

int[,] DeleteMatrixColumn(int[,] matrix, int columnToDelete)
{
    int[,] result=new int[matrix.GetLength(0), matrix.GetLength(1)-1];
    int newColIndex=0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        newColIndex=0;//обнуляем счетчик неудаленных столбцов при смене строки
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(j!=columnToDelete)
            {
               
               result[i,newColIndex]=matrix[i,j];
               newColIndex++;
               
            }
             

        }
    }

    return result;
}




int[,] DelCross(int[,] matrix)
{
    int[] minElementIndices=MinElementIndices(matrix);
    Console.WriteLine($"min element found at row[{minElementIndices[0]}] min col[{minElementIndices[1]}]");
    int[,] answer=DeleteMatrixRow(matrix,minElementIndices[0]);
    answer=DeleteMatrixColumn(answer,minElementIndices[1]);
 
    return answer;

}







int r = Prompt("enter matrix rows number: ");
int c = Prompt("enter matrix columns number: ");
int range = Prompt("enter matrix value generator range: ");
int[,] matr = FillMatrix(r, c, range);
System.Console.WriteLine("Generated matrix is: ");
PrintMatrix(matr);

System.Console.WriteLine("Result matrix after raw/column of min element removal:  ");
PrintMatrix(DelCross(matr));








