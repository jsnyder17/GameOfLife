using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GameOfLife
{
    public class CellManager
    {
        public int[,] cells;

        private Random rand;

        public CellManager()
        {
            cells = new int[Constants.CELL_ROWS, Constants.CELL_COLUMNS];

            rand = new Random();
        }

        public void GenerateRandomCells()
        {
            // Randomly assign each cell a status of alive or dead
            for (int i = 0; i < Constants.CELL_ROWS; i++)
            {
                for (int j = 0; j < Constants.CELL_COLUMNS; j++)
                {
                    cells[i, j] = rand.Next(2);
                }
            }
        }

        public void ProcessNeighbors(bool rbMoore_Checked)
        {
            int[] neighbors;
            int[,] updatedCells = cells.Clone() as int[,];

            if (rbMoore_Checked)
            {
                neighbors = new int[8];

                for (int i = 0; i < Constants.CELL_ROWS; i++)
                {
                    for (int j = 0; j < Constants.CELL_COLUMNS; j++)
                    {
                        // Get all neighbors
                        if (i < Constants.CELL_ROWS - 1)
                        {
                            neighbors[0] = cells[i + 1, j];
                        }
                        else
                        {
                            neighbors[0] = cells[0, j];
                        }

                        if (i > 0)
                        {
                            neighbors[1] = cells[i - 1, j];
                        }
                        else
                        {
                            neighbors[1] = cells[Constants.CELL_ROWS - 1, j];
                        }

                        if (j < Constants.CELL_COLUMNS - 1)
                        {
                            neighbors[2] = cells[i, j + 1];
                        }
                        else
                        {
                            neighbors[2] = cells[i, 0];
                        }

                        if (j > 0)
                        {
                            neighbors[3] = cells[i, j - 1];
                        }
                        else
                        {
                            neighbors[3] = cells[i, Constants.CELL_COLUMNS - 1];
                        }

                        if (i < Constants.CELL_ROWS - 1 && j < Constants.CELL_COLUMNS - 1)
                        {
                            neighbors[4] = cells[i + 1, j + 1];
                        }
                        else if (i > Constants.CELL_ROWS - 1 && j > Constants.CELL_COLUMNS - 1)
                        {
                            neighbors[4] = cells[0, 0];
                        }

                        if (i > 0 && j > 0)
                        {
                            neighbors[5] = cells[i - 1, j - 1];
                        }
                        else if (i < 0 && j < 0)
                        {
                            neighbors[5] = cells[Constants.CELL_ROWS - 1, Constants.CELL_COLUMNS - 1];
                        }

                        if (i < Constants.CELL_ROWS - 1 && j > 0)
                        {
                            neighbors[6] = cells[i + 1, j - 1];
                        }
                        else if (i > Constants.CELL_ROWS - 1 && j < 0)
                        {
                            neighbors[6] = cells[0, Constants.CELL_COLUMNS - 1];
                        }

                        if (i > 0 && j < Constants.CELL_COLUMNS - 1)
                        {
                            neighbors[7] = cells[i - 1, j + 1];
                        }
                        else if (i < 0 && j > Constants.CELL_COLUMNS - 1)
                        {
                            neighbors[7] = cells[Constants.CELL_ROWS - 1, 0];
                        }

                        ProcessCell(i, j, neighbors, updatedCells);
                    }
                }
            }
            else
            {
                neighbors = new int[4];

                for (int i = 0; i < Constants.CELL_ROWS; i++)
                {
                    for (int j = 0; j < Constants.CELL_COLUMNS; j++)
                    {
                        if (i > 0)
                        {
                            neighbors[0] = cells[i - 1, j];
                        }
                        else
                        {
                            neighbors[0] = cells[Constants.CELL_ROWS - 1, j];
                        }

                        if (i < Constants.CELL_ROWS - 1)
                        {
                            neighbors[1] = cells[i + 1, j];
                        }
                        else
                        {
                            neighbors[1] = cells[0, j];
                        }

                        if (j > 0)
                        {
                            neighbors[2] = cells[i, j - 1];
                        }
                        else
                        {
                            neighbors[2] = cells[i, Constants.CELL_COLUMNS - 1];
                        }

                        if (j < Constants.CELL_COLUMNS - 1)
                        {
                            neighbors[3] = cells[i, j + 1];
                        }
                        else
                        {
                            neighbors[3] = cells[i, 0];
                        }

                        ProcessCell(i, j, neighbors, updatedCells);
                    }
                }
            }

            cells = updatedCells;
        }

        public void ProcessCell(int i, int j, int[] neighbors, int[,] updatedCells)
        {
            int aliveCount = 0;

            // Get all of the live neighbors 
            for (int k = 0; k < neighbors.Length; k++)
            {
                if (neighbors[k] == 1)
                {
                    aliveCount++;
                }
            }

            if (cells[i, j] == 1)   // Live cell logic 
            {
                if (aliveCount != 2 && aliveCount != 3)
                {
                    updatedCells[i, j] = 0;
                }
            }
            else    // Dead cell logic 
            {
                if (aliveCount == 3)
                {
                    updatedCells[i, j] = 1;
                }
            }
        }
        
        public void ClearCells()
        {
            Array.Clear(cells);
        }
    }
}
