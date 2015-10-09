# Rc.Core   

[![Build Status](https://travis-ci.org/AnotherAltr/Rc.Core.svg?branch=master)](https://travis-ci.org/AnotherAltr/Rc.Core)   
[![License](https://img.shields.io/apm/l/vim-mode.svg)](https://github.com/AnotherAltr/Rc.Core/blob/master/LICENSE)   
[![Status](https://img.shields.io/badge/status-beta-red.svg)](https://ru.wikipedia.org/wiki/Бета)   
![Platform](https://img.shields.io/badge/platform-win%20%7C%20NET.Core%204.5-lightgrey.svg)   
![version](https://img.shields.io/badge/version-7.8-green.svg)   


# Doc:

### Коллекции (Collections) - "root\\Collections"

#### Generic Box
  ```CSharp
  Box2<Int32> box = new Box2<Int32>(17, 25)
  Console.WriteLine(box.T1 * box.T2);
  ``` 
#### Generic Matrix
  ```CSharp
  ...
  Matrix<Int32> Max = new Matrix<Int32>();                                          //! Default Size
  ...
  Matrix<Int32> Max = new Matrix<Int32>(16, 16);                                    //! Custom Size
  ...
  Matrix<Int32> Max = new Matrix<Int32>(new SizeMatrix(16, 16), TypeMatrix.Square); //! Custom Size & Forms
  ...
  Int32 i = Max[12, 13];          // Get Value in row 12, collum 13
  ...
  Int32[] i = Max.GetCollum(5);   // Get Value in 5 Collum
  ...
  Int32[] i = Max.GetRow(5);      // Get Value in 5 Row
  ...
  Int32[] RowData = new Int32[16];
  for(int i = 0; i != RowData.Lenght; i++)
  {
      RowData[i] = new Random().Next(0, Int32.MaxValue - 1);
  }
  Max.SetRow(RowData, 9);         // Set Row 9 as Data
   ...
  Int32[] CollumData = new Int32[16];
  for(int i = 0; i != CollumData.Lenght; i++)
  {
      CollumData[i] = new Random().Next(0, Int32.MaxValue - 1);
  }
  Max.SetCollum(CollumData, 6);   // Set Collum 6 as Data
  ```
  
  
  This page is in a state of write...
