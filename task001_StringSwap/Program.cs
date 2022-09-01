/*
Задача 1: Задайте двумерный массив. Напишите программу, 
которая поменяет местами первую и последнюю строку 
массива
*/



int Prompt(string message)
{
    System.Console.Write(message);
    string readValue=Console.ReadLine();
    return int.Parse(readValue);
}



int[,] FillMatrix(int rows, int columns, int range)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i,j]=new Random().Next(1,range+1);

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

int[,] SwapFirstAndLastRow(int[,] matrix)//поменяет местами первую и последнюю строку массива
{
    int temp=0;
           

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            temp=matrix[0,j];
            matrix[0,j]=matrix[matrix.GetLength(0)-1,j];
            matrix[matrix.GetLength(0)-1,j]=temp;

        }

    
    return matrix;
}







int r=Prompt("enter matrix rows number: ");
int c=Prompt("enter matrix columns number: ");
int range=Prompt("enter matrix value generator range: ");
int[,] matr=FillMatrix(r,c,range);
System.Console.WriteLine("Generated matrix is: ");
PrintMatrix(matr);


System.Console.WriteLine($"Matrix with first and last rows swapped:  ");
PrintMatrix(SwapFirstAndLastRow(matr));



