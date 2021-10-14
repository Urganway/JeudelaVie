using System;
using System.Collections.Generic;
using System.Reflection;
using Jeudelavie.Classes;

namespace Jeudelavie
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			List<Coords> aliveCells = new List<Coords>();
			aliveCells.Add(new Coords(1,2));
			aliveCells.Add(new Coords(2,2));
			aliveCells.Add(new Coords(3,2));

			Game game = new Game(6, 10, aliveCells);
			game.RunGameConsole();

			Console.ReadLine();
		}
	}
}