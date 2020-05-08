/*
** 9x9 luk bir sudokunun doğru yapılıp yapılmadığını 
** kontrol eder
** İlk önce her satırda 1 den 9 a kadar her sayıdan olmalı buna bakar
** Sonra her sütunda 1 den 9 a kadar her sayıdan olmalı buna bakar
** Sonra her 3x3 lük blokta 1 den 9 a kadar her sayıdan olmalı buna bakar
** Tüm koşullar sağlanıyorsa sudoku doğru çözülmüştür
*/

using System;
using System.Collections.Generic;

namespace Sudoku
{
    class Program_Sudoku_Validator
    {
        static readonly int[] ONE_TO_NINE = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main(string[] args)
        {
            int[,] sudoku1 = new int[,]
            {
                { 3, 5, 2, 9, 1, 8, 6, 7, 4 },
                { 8, 9, 7, 2, 4, 6, 5, 1, 3 },
                { 6, 4, 1, 7, 5, 3, 2, 8, 9 },
                { 7, 8, 3, 5, 6, 9, 4, 2, 1 },
                { 9, 2, 6, 1, 3, 4, 7, 5, 8 },
                { 4, 1, 5, 8, 2, 7, 9, 3, 6 },
                { 1, 6, 4, 3, 7, 5, 8, 9, 2 },
                { 2, 7, 8, 4, 9, 1, 3, 6, 5 },
                { 5, 3, 9, 6, 8, 2, 1, 4, 7 },
            };

            int[,] sudoku2 = new int[,]
            {
                { 3, 5, 2, 9, 1, 8, 6, 7, 4 },
                { 8, 9, 7, 2, 4, 6, 5, 1, 3 },
                { 6, 4, 1, 7, 5, 3, 2, 8, 9 },
                { 7, 8, 3, 5, 6, 9, 4, 2, 1 },
                { 9, 2, 6, 1, 3, 4, 7, 5, 8 },
                { 4, 1, 5, 8, 2, 7, 9, 3, 6 },
                { 8, 6, 4, 3, 7, 5, 8, 9, 2 },
                { 2, 7, 8, 4, 9, 1, 3, 6, 5 },
                { 5, 3, 9, 6, 8, 2, 1, 4, 7 },
            };

            if (SudokuControl(sudoku1))
                Console.WriteLine("Sudoku 1 is correct. Bravo!");
            else
                Console.WriteLine("Sudoku 1 is false!");

            if (SudokuControl(sudoku2))
                Console.WriteLine("Sudoku 2 is correct. Bravo!");
            else
                Console.WriteLine("Sudoku 2 is false!");
        }

        static bool SudokuControl(int[,] sudoku)
        {
            int[] colArr = new int[9];
            int[] rowArr = new int[9];
            int[] blockArr = new int[9];

            int row = 0, col = 0;
            bool blockControl = true;

            for (var r=0; r<sudoku.GetLength(0); r++)
            {
                for (var c=0; c<sudoku.GetLength(1); c++)
                    rowArr[c] = sudoku[r, c];
                
                if (!isContainsOneToNine(rowArr))
                    return false;
            }

            for (var c=0; c<sudoku.GetLength(1); c++)
            {
                for (var r=0; r<sudoku.GetLength(0); r++)
                    colArr[r] = sudoku[r, c];
                
                if (!isContainsOneToNine(colArr))
                    return false;
            }

            while (blockControl)
            {
                for (var i=0; i<9; i++)
                {
                    blockArr[i] = sudoku[row, col];
                    col++;

                    if (col == 3 || col % 3 == 0)
                    {
                        col -= 3;
                        row++;
                    }

                    if (i == 8)
                        if (!isContainsOneToNine(blockArr))
                            return false;
                    
                    if (row == 9 && col < 7)
                    {
                        row = 0;
                        col += 3;
                    }

                    if (row == 0 && col == 9)
                        blockControl = false;
                }
            }

            return true;
        }

        static bool isContainsOneToNine(int[] arr)
        {
            Array.Sort(arr);

            for (var i=0; i<arr.Length; i++)
                if (arr[i] != ONE_TO_NINE[i])
                    return false;
            
            return true;
        }
    }
}
