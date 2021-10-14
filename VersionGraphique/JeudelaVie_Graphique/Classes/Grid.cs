using System;
using System.Collections.Generic;

namespace Jeudelavie.Classes
{
	public class Grid
	{
		public int _n { get; set; } //taille de la grille
		public Cell[,] tabCells;

		private Cell[,] previousCellTab;

		public Grid(int gridSize, List<Coords> aliveCellsCoords)
		{
			_n = gridSize;
			tabCells = new Cell[_n,_n];
			
			for (int y = 0; y < _n; y++)
			{
				for (int x = 0; x < _n; x++)
				{
					bool cellState = false;
					foreach (Coords coords in aliveCellsCoords)
					{
						if (coords._x == x && coords._y == y)
						{
							cellState = true;
							break;
						}
					}
					tabCells[x, y] = new Cell(cellState);
				}
			}

		}

		private int GetNbAliveNeighboor(int i, int j)
		{
			List<Coords> neighboors = GetCoordsNeighboor(i, j);
			List<Coords> aliveCells = GetCoordsAliveCells();
			int nbAlive = 0;
			
			foreach (Coords neighboor in neighboors)
			{
				foreach (Coords aliveCell in aliveCells)
				{
					if (neighboor._x == aliveCell._x && neighboor._y == aliveCell._y)
						++nbAlive;
				}
			}
			return nbAlive;
		}

		private List<Coords> GetCoordsNeighboor(int i, int j)
		{
			List<Coords> coords = new List<Coords>();
			/*for (int y = -1; y < 1; y++)
			{
				for (int x = -1; x < 1; x++)
				{
					coords.Add(new Coords(i+x,j+y));
				}
			}*/
			coords.Add(new Coords(i-1,j-1));
			coords.Add(new Coords(i-1,j));
			coords.Add(new Coords(i-1,j+1));
			coords.Add(new Coords(i,j-1));
			coords.Add(new Coords(i,j+1));
			coords.Add(new Coords(i+1,j-1));
			coords.Add(new Coords(i+1,j));
			coords.Add(new Coords(i+1,j+1));
			return coords;
		}

		private List<Coords> GetCoordsAliveCells()
		{
			List<Coords> aliveCells = new List<Coords>();
			for (int y = 0; y < _n; y++)
			{
				for (int x = 0; x < _n; x++)
				{
					if(tabCells[x,y]._isAlive)
						aliveCells.Add(new Coords(x,y));
				}
			}
			return aliveCells;	
		}

		public void DisplayGrid()
		{
			List<Coords> aliveCells = GetCoordsAliveCells();
			for (int y = 0; y < _n; y++)
			{
				for (int i = 0; i < _n; i++)
				{
					Console.Write("+---");
				}
				Console.Write("+\n");
				
				for (int x = 0; x < _n; x++)
				{
					string cellSate = " ";
					foreach (Coords coords in aliveCells)
					{
						if (x == coords._x && y == coords._y)
						{
							cellSate = "X";
							break;
						}
					}
					Console.Write($"| {cellSate} ");
				}
				Console.Write("|\n");
			}
			for (int i = 0; i < _n; i++)
			{
				Console.Write("+---");
			}
			Console.Write("+\n");
		}

		public void UpdateGrid()
		{
			List<Coords> aliveCells = GetCoordsAliveCells();
			for (int y = 0; y < _n; y++)
			{
				for (int x = 0; x < _n; x++)
				{
					bool isCurrentCellALive = tabCells[x, y]._isAlive;
					
					if (!isCurrentCellALive && GetNbAliveNeighboor(x, y) == 3)
						tabCells[x, y].ComeAlive();
					else 
					if (isCurrentCellALive && (GetNbAliveNeighboor(x, y) == 2 || GetNbAliveNeighboor(x, y) == 3))
						tabCells[x, y].ComeAlive();
					else 
						tabCells[x, y].PassAway();
				}
			}

			foreach (Cell cell in tabCells)
			{
				cell.Update();
			}
		}

		public bool isSimStable()
		{
			bool state = true;

			foreach (Cell currentCell in tabCells)
			{
				foreach (Cell previousCell in previousCellTab)
				{
					if (currentCell._isAlive != previousCell._isAlive)
					{
						return false;
					}
				}
			}
			return state;
		}
		
	}
}