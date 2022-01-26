using SeaBattle.GameField;
using SeaBattle.Ships;

Console.WriteLine();

var field = new GameField(5);

// field.GetView();
var warShip = new WarShip(2, 10, 2);

field.AddShip(warShip, 1, 1, 1, true);
field.GetView();

Console.WriteLine(field[1, 2, 1].ToString());
