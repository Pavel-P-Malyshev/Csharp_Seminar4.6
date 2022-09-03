/*
Задача 3: Составить частотный словарь элементов 
двумерного массива. Частотный словарь содержит 
информацию о том, сколько раз встречается элемент 
входных данных. Значения элементов массива 0..9
25 мин
Набор данных Частотный массив
{ 1, 9, 9, 0, 2, 8, 0, 9 } 0 встречается 2 раза 
1 встречается 1 раз 
2 встречается 1 раз 
8 встречается 1 раз 
9 встречается 3 раза
1, 2, 3 
4, 6, 1 
2, 1, 6
1 встречается 3 раза 
2 встречается 2 раз 
3 встречается 1 раз 
4 встречается 1 раз 
6 встречается 2 раза

*/


/*
Задача 2: Задайте двумерный массив. Напишите программу, 
которая заменяет строки на столбцы. В случае, если это 
невозможно, программа должна вывести сообщение для 
пользователя.
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

int[] FreqBook(int[,] matrix)
{
    int[] Book=new int[10];
    
    
    for (int i = 0; i < matrix.GetLength(0); i++)
    {

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Book[matrix[i,j]]++;

        }
        
    }

    return Book;
}







int r = Prompt("enter matrix rows number: ");
int c = Prompt("enter matrix columns number: ");
int range = Prompt("enter matrix value generator range (9 is recommended): ");
int[,] matr = FillMatrix(r, c, range);
System.Console.WriteLine("Generated matrix is: ");
PrintMatrix(matr);


System.Console.WriteLine("TFrequency Book for this matrix is:  ");
int[] Book=FreqBook(matr);

for (int i = 0; i < 10; i++)
{
    System.Console.WriteLine($" '{i}' value met {Book[i]} times  ");
}





