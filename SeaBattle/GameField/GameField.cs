using SeaBattle.Ships;

namespace SeaBattle.GameField;

public class GameField
{
    public GameField(int size)
    {
        Field = new object[size, size];
    }

    private object[,] Field { get; set; }

    public object this[int quadrant, int x, int y]
    {
        get
        {
            var coords = ChangeCoord(quadrant, x, y);
            return Field[coords[0], coords[1]];
        }
        set
        {
            var coords = ChangeCoord(quadrant, x, y);
            Field[coords[0], coords[1]] = value;
        }
    }

    private int[] ChangeCoord(int quadrant, int x, int y)
    {
        var halfLength = (int) (Math.Sqrt(Field.Length) / 2);
        switch (quadrant)
        {
            case 1:
                return new[] { halfLength - x, halfLength + y - 1};
            case 2:
                return new[] { halfLength - x, halfLength - y};
            case 3:
                return new[] {halfLength + x - 1, halfLength - y};
            case 4:
                return new[] {halfLength + x - 1, halfLength + y - 1};
        }
        return new int[]{};
    }

    public void AddShip(ShipBase ship, int quadrant, int x, int y, bool isHorizontal)
    {
        var coords = ChangeCoord(quadrant, y, x);
        if (!CheckIfFit(ship.Size, coords, isHorizontal))
        {
            Console.WriteLine("Your ship doesn't fit");
            return;
        }
        if (isHorizontal)
        {
            for (int i = 0; i < ship.Size; i++)
            {
                Field[coords[0], coords[1] + i] = ship;
            }
        }
        else
        {
            for (int i = 0; i < ship.Size; i++)
            {
                Field[coords[0] + i, coords[1]] = ship;
            }
        }
    }

    private bool CheckIfFit(int shipSize, int[] coords, bool isHorizontal)
    {
        var length = (int) Math.Sqrt(Field.Length);
        if (isHorizontal)
        {
            return coords[0] < length && coords[0] + shipSize < length;
        }

        return false;
    }

    public void GetView()
    {
        Console.WriteLine("------------------Game Field-------------------");
        for (int i = 0; i < Math.Sqrt(Field.Length); i++)
        {
            for (int j = 0; j < Math.Sqrt(Field.Length); j++)
            {
                Console.Write((Field[i, j] == null) ? "0 " : "1 ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("----------------------------------------------");
    }
}