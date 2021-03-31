using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountIsland : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textGUI;
    public int result;

    private void OutputCells(int[][] cells)
    {
        textGUI.text = "Input Cells\n";
        for (int i = 0; i < cells.Length; i++)
        {
            for (int j = 0; j < cells[0].Length; j++)
            {
                textGUI.text += cells[i][j] + " ";
            }
            textGUI.text += "\n";
        }
    }
    private void Start()
    {
        //for test use class Test.cell_{i}
        var testCells = Test.cells_1; 
        OutputCells(testCells);
        
        //main function
        result = CountIslands(testCells);
        
        textGUI.text += "\nIslands: " + result.ToString();
    }
    
    /// <summary>
    /// main function
    /// </summary>
    /// <param name="cells"></param>
    /// <returns></returns>
    private static int CountIslands(int[][] cells)
    {
        var m = cells.Length;
        var n = cells[0].Length;
        int _result = 0;
        
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (CheckIsland(cells, i, j))
                {
                    _result++;
                }
            }
        }
        return _result;
    }
    
    /// <summary>
    /// find a island (1) and set 0
    /// find a island around 1
    /// check square
    /// [i][j + 1]
    /// [i][j - 1]
    /// [i + 1][j]
    /// [i - 1][j]
    /// next recursive while not false exeption or island == false
    /// </summary>
    /// <param name="cells" our matrix with ></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    private static bool CheckIsland(int[][] cells, int i, int j)
    {
        if (i < 0 || i >= cells.Length)
            return false;
        if (j < 0 || j >= cells[0].Length)
            return false;
        bool island = cells[i][j] == 1; // check island
        
        cells[i][j] = 0; // change 1 on 0 because infinity loop
        if (island) // catch island(1)
        {
            CheckIsland(cells, i, j + 1);
            CheckIsland(cells, i, j - 1);
            CheckIsland(cells, i + 1, j);
            CheckIsland(cells, i - 1, j);
        }
        return island;
    }
}



class Test
{
    public static int[][] cells_1 = new int[][]
    {
        new int[] {1, 0, 1},
        new int[] {0, 1, 0}
    };
    
    public static int[][] cells_2 = new int[][]
    {
        new int[] {1, 0},
        new int[] {1, 0},
        new int[] {1, 1}
    };
    
    public static int[][] cells_3 = new int[][]
    {
        new int[] {1, 0, 1, 1},
        new int[] {1, 0, 1, 1},
        new int[] {1, 1, 0, 0}
    };
    
    public static int[][] cells_4 = new int[][]
    {
        new int[] {1, 0, 0, 1},
        new int[] {1, 0, 1, 0},
        new int[] {0, 1, 0, 0}
    };
    
    public static int[][] cells_5 = new int[][]
    {
        new int[] {1, 0, 0, 1},
        new int[] {1, 0, 1, 0},
        new int[] {0, 1, 0, 0},
        new int[] {1, 0, 0, 1},
        new int[] {1, 0, 0, 0},
        new int[] {0, 1, 1, 1},
    };
}



