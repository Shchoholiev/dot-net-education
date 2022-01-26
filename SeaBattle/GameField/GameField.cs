using SeaBattle.Ships;

namespace SeaBattle.GameField;

public class GameField
{
    public GameField(int size)
    {
        size = size % 2 == 0 ? size : size + 1;
        this.Field = new object[size, size];
    }

    public List<ShipBase>? Ships { get; set; }

    private object[,] Field { get; set; }

    public object this[int quadrant, int moduleX, int moduleY]
    {
        get
        {
            var coordinates = this.ChangeCoordinates(quadrant, moduleY, moduleX);
            return this.Field[coordinates[0], coordinates[1]];
        }

        set
        {
            var coordinates = this.ChangeCoordinates(quadrant, moduleY, moduleX);
            this.Field[coordinates[0], coordinates[1]] = value;
        }
    }

    public void GetView()
    {
        Console.WriteLine("------------------Game Field-------------------");
        for (int i = 0; i < this.Field.GetLength(0); i++)
        {
            for (int j = 0; j < this.Field.GetLength(0); j++)
            {
                Console.Write((this.Field[i, j] == null) ? "0 " : "1 ");
            }

            Console.WriteLine();
        }

        Console.WriteLine("----------------------------------------------");
    }

    public void AddShip(ShipBase ship, int quadrant, int moduleX, int moduleY, bool isHorizontal)
    {
        var coordinates = this.ChangeCoordinates(quadrant, moduleY, moduleX);
        if (!this.CheckIfFit(ship.Size, coordinates, isHorizontal))
        {
            Console.WriteLine("moduleYour ship doesn't fit");
            return;
        }

        if (isHorizontal)
        {
            for (int i = 0; i < ship.Size; i++)
            {
                this.Field[coordinates[0], coordinates[1] + i] = ship;
            }
        }
        else
        {
            for (int i = 0; i < ship.Size; i++)
            {
                this.Field[coordinates[0] + i, coordinates[1]] = ship;
            }
        }
    }

    private bool CheckIfFit(int shipSize, int[] coordinates, bool isHorizontal)
    {
        var length = this.Field.GetLength(0);
        if (isHorizontal)
        {
            return coordinates[0] < length && coordinates[0] + shipSize < length;
        }

        return false;
    }

    private int[] ChangeCoordinates(int quadrant, int moduleX, int moduleY)
    {
        var halfLength = this.Field.GetLength(0) / 2;
        switch (quadrant)
        {
            case 1:
                return new[] { halfLength - moduleX, halfLength + moduleY - 1 };
            case 2:
                return new[] { halfLength - moduleX, halfLength - moduleY };
            case 3:
                return new[] { halfLength + moduleX - 1, halfLength - moduleY };
            case 4:
                return new[] { halfLength + moduleX - 1, halfLength + moduleY - 1 };
        }

        return new int[] { };
    }
}