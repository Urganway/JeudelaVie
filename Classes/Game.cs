using System;
using System.Collections.Generic;
using System.Threading;

namespace Jeudelavie.Classes
{
	public class Game
	{
		public int GridSize;//taille de la grille
		public int _nbIteration;//nombre d'itération de la simulation
		public List<Coords> _aliveCellsCoords;

		public Grid grid;
		
		public Game(int gridSize, int nbIteration, List<Coords> aliveCellsCoords)
		{
			GridSize = gridSize;
			_nbIteration = nbIteration;
			_aliveCellsCoords = aliveCellsCoords;

			grid = new Grid(gridSize, aliveCellsCoords);
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
	}
}