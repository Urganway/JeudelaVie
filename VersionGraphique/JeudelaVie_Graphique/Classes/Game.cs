using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Jeudelavie.Classes
{
	public class Game
	{
		public int _gridSize;//taille de la grille
		private int _nbIteration { get; }//nombre d'itération de la simulation
		public List<Coords> _aliveCellsCoords;

		public Grid grid;
		
		public Game(int gridSize, List<Coords> aliveCellsCoords)
		{
			_gridSize = gridSize;
			_aliveCellsCoords = aliveCellsCoords;

			grid = new Grid(gridSize, _aliveCellsCoords);
		}
		
		public Game(int gridSize, int nbIteration, List<Coords> aliveCellsCoords) : this(gridSize, aliveCellsCoords)
		{
			_nbIteration = nbIteration;
		}
		

		public void RunGameConsole()
		{
			grid.DisplayGrid();
			for (int i = 0; i < _nbIteration; i++)
			{
				grid.UpdateGrid();
				Console.Clear();
				grid.DisplayGrid();
				Thread.Sleep(500);
			}
		}
		
		public void Paint(Graphics g, int cellPixelSize)
		{
			SolidBrush whiteBrush = new SolidBrush(Color.White);
			for (int y = 0; y < _gridSize; y++)
			{
				for (int x = 0; x < _gridSize; x++)
				{
					if (grid.tabCells[x,y]._isAlive)
					{
						g.FillRectangle(whiteBrush, x * cellPixelSize, y * cellPixelSize, cellPixelSize, cellPixelSize);
					}
				}
			}
		}
	}
}