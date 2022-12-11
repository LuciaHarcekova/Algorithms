"""
1.8 Zero Matrix
Link: https://www.crackingthecodinginterview.com

Write an algorithm such that if an element in an MxN
matrix is 0, its entire row and column are set to 0.

Approaches:
- iterate through the matrix and and save rows and columns where
  is 0, then set them to zeros. 

2d array:
from array import *
T = [[11, 12, 5, 2], [15, 6,10], [10, 8, 12, 5], [12,15,8,6]]

print('\n'.join([''.join(['{:4}'.format(item) for item in row]) 
      for row in T]))

Source:
https://www.tutorialspoint.com/python_data_structure/python_2darray.htm
https://www.w3schools.com/python/python_for_loops.asp
"""


def setZeros(matrix):

    # store 0 for rows and columns
    row = [False] * len(matrix)
    column = [False] * len(matrix[0])

    for i in range(len(matrix)):
        for j in range(len(matrix[0])):
            if (matrix[i][j] == 0):
                row[i] = True;
                column[j] = True;

    # Nullify rows
    for i in range(len(row)):
        if (row[i]): nullifyRow(matrix, i)

    # Nullify columns
    for j in range(len(column)):
        if (column[j]): nullifyColumn(matrix, j)

def nullifyRow(matrix, row):
    matrix[row] = [0] * len(matrix[0])

def nullifyColumn(matrix, col):
    for row in matrix:
        row[col] = 0
