// See https://aka.ms/new-console-template for more information

using SeaBattle.GameField;
using SeaBattle.Ships;

Console.WriteLine();

var field = new GameField(6);
// field.GetView();

var warShip = new WarShip(4, 10, 2);

field.AddShip(warShip, 2, 1, 1, true);

field.GetView();