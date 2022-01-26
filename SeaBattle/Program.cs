using SeaBattle.GameField;
using SeaBattle.Ships;

//Console.WriteLine("---------------- Sea Battle ---------------");
//Console.WriteLine();
//Console.WriteLine("Enter game field size: ");
//int size;
//int.TryParse(Console.ReadLine(), out size);

var field = new GameField(5);

var warShip = new WarShip(4, 10, 2);
var combinedShip = new CombinedShip(3, 10, 2);
var supportShip = new SupportShip(1, 10, 2);

field.AddShip(warShip, 1, 1, 1, false);
field.AddShip(combinedShip, 2, 3, 3, true);
field.AddShip(supportShip, 1, 2, 2, true);
field.GetView();

Console.WriteLine(field[1, 1, 1]?.ToString());

Console.WriteLine(field);
