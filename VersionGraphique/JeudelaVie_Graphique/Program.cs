using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Jeudelavie.Classes;

namespace JeudelaVie_Graphique
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			List<Coords> aliveCells = new List<Coords>();
			int gridSize = 50;
			int cellPixelSize = 10;
			int refreshTime = 50;
			/*
			#region Choix de l'arrangement initial => Gosper Glider Gun
			aliveCells.Add(new Coords(24,0));
			
			aliveCells.Add(new Coords(22,1));
			aliveCells.Add(new Coords(24,1));
			
			aliveCells.Add(new Coords(12,2));
			aliveCells.Add(new Coords(13,2));
			aliveCells.Add(new Coords(20,2));
			aliveCells.Add(new Coords(21,2));
			aliveCells.Add(new Coords(34,2));
			aliveCells.Add(new Coords(35,2));
			
			aliveCells.Add(new Coords(11,3));
			aliveCells.Add(new Coords(15,3));
			aliveCells.Add(new Coords(20,3));
			aliveCells.Add(new Coords(21,3));
			aliveCells.Add(new Coords(34,3));
			aliveCells.Add(new Coords(35,3));
			
			aliveCells.Add(new Coords(0,4));
			aliveCells.Add(new Coords(1,4));
			aliveCells.Add(new Coords(10,4));
			aliveCells.Add(new Coords(16,4));
			aliveCells.Add(new Coords(20,4));
			aliveCells.Add(new Coords(21,4));
			
			aliveCells.Add(new Coords(0,5));
			aliveCells.Add(new Coords(1,5));
			aliveCells.Add(new Coords(10,5));
			aliveCells.Add(new Coords(14,5));
			aliveCells.Add(new Coords(16,5));
			aliveCells.Add(new Coords(17,5));
			aliveCells.Add(new Coords(22,5));
			aliveCells.Add(new Coords(24,5));
			
			aliveCells.Add(new Coords(10,6));
			aliveCells.Add(new Coords(16,6));
			aliveCells.Add(new Coords(24,6));
			
			aliveCells.Add(new Coords(11,7));
			aliveCells.Add(new Coords(15,7));
			
			aliveCells.Add(new Coords(12,8));
			aliveCells.Add(new Coords(13,8));

			#endregion
			*/
			#region test initial

			int aliveProba = 40;// /100
			
			Random rng = new Random();
			for (int y = 0; y < gridSize; y++)
			{
				for(int x = 0; x < gridSize ; x++)
				{
					int choice = rng.Next(0, 100);
					if (choice < aliveProba)
					{
						aliveCells.Add(new Coords(x,y));
					}
				}
			}
			#endregion
			
			
			//création de la game
			Game game = new Game(gridSize,aliveCells);
			
			//affichage
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(game, cellPixelSize, refreshTime));
		}
	}
}