using SeaBattle.Ships;

namespace SeaBattle.GameField;

public class GameField
{
    public GameField(int size)
    {
        size = size % 2 == 0 ? size : size + 1;
        this.Field = new object[size, size];
        Ships = new List<ShipBase>();
    }

    private List<ShipBase> Ships { get; set; }

    private object[,] Field { get; set; }

    public object this[int quadrant, int moduleX, int moduleY]
    {
        get
        {
            var coordinates = this.ChangeCoordinatesToArrayIndexes(quadrant, moduleY, moduleX);
            return this.Field[coordinates[0], coordinates[1]];
        }

        set
        {
            var coordinates = this.ChangeCoordinatesToArrayIndexes(quadrant, moduleY, moduleX);
            this.Field[coordinates[0], coordinates[1]] = value;
        }
    }

    public override string ToString()
    {
        this.Sort();
        var text = $"Field with size {this.Field.GetLength(0)} has {this.Ships?.Count} Ships\n";
        if (this.Ships == null)
        {
            return text;
        }

        foreach (var ship in this.Ships)
        {
            text += $"{ship.ToString()}\n";
        }

        return text;
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
        var coordinates = this.ChangeCoordinatesToArrayIndexes(quadrant, moduleY, moduleX);
        if (!(this.CheckIfFit(ship.Size, coordinates, isHorizontal)
            && this.CheckIfEmpty(ship.Size, coordinates, isHorizontal)))
        {
            Console.WriteLine("Your ship doesn't fit");
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

        this.Ships?.Add(ship);
        this.SetCoordinates(ship, quadrant, moduleX, moduleY, isHorizontal);
    }

    private bool CheckIfFit(int shipSize, int[] coordinates, bool isHorizontal)
    {
        var length = this.Field.GetLength(0);
        if (isHorizontal)
        {
            return coordinates[1] <= length && coordinates[1] + shipSize <= length;
        }
        else
        {
            return coordinates[0] <= length && coordinates[0] + shipSize <= length;
        }
    }

    private bool CheckIfEmpty(int shipSize, int[] coordinates, bool isHorizontal)
    {
        if (isHorizontal)
        {
            for (int i = 0; i < shipSize; i++)
            {
                if (this.Field[coordinates[0], coordinates[1] + i] != null)
                {
                    return false;
                }
            }
        }
        else
        {
            for (int i = 0; i < shipSize; i++)
            {
                if (this.Field[coordinates[0] + i, coordinates[1]] != null)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private int[] ChangeCoordinatesToArrayIndexes(int quadrant, int moduleX, int moduleY)
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

    private int[] ChangeCoordinatesToCartesian(int quadrant, int moduleX, int moduleY)
    {
        var halfLength = this.Field.GetLength(0) / 2;
        switch (quadrant)
        {
            case 1:
                return new[] { moduleX, moduleY };
            case 2:
                return new[] { -moduleX, moduleY };
            case 3:
                return new[] { -moduleX, -moduleY };
            case 4:
                return new[] { moduleX, -moduleY };
        }

        return new int[] { };
    }

    private void SetCoordinates(ShipBase ship, int quadrant, int moduleX, int moduleY, bool isHorizontal)
    {
        var cartesianCoordinates = this.ChangeCoordinatesToCartesian(quadrant, moduleY, moduleX);
        if (isHorizontal)
        {
            ship.StartCoordinates = new int[] { cartesianCoordinates[0], cartesianCoordinates[1] };
            ship.EndCoordinates = new int[] { this.GetEndCoordinate(cartesianCoordinates[0], ship.Size), cartesianCoordinates[1] };
        }
        else
        {
            ship.StartCoordinates = new int[] { cartesianCoordinates[0], cartesianCoordinates[1] };
            ship.EndCoordinates = new int[] { cartesianCoordinates[0], this.GetEndCoordinate(cartesianCoordinates[0], ship.Size) };
        }
    }

    private int GetEndCoordinate(int startCoordinate, int shipSize)
    {
        var halfLength = this.Field.GetLength(0) / 2;
        if (startCoordinate + shipSize - 1 > halfLength)
        {
            return startCoordinate - halfLength - 1;
        }
        else
        {
            return startCoordinate + shipSize - 1;
        }
    }

    private void Sort()
    {
        if (this.Ships == null)
        {
            return;
        }

        this.Ships.Sort((first, second) =>
        {
            var firstDistance = this.GetDistanceToCenter(first);
            var secondDistance = this.GetDistanceToCenter(second);

            if (firstDistance > secondDistance)
            {
                return 1;
            }
            else if (firstDistance < secondDistance)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        });
    }

    private double GetDistanceToCenter(ShipBase ship)
    {
        if (ship.StartCoordinates[0] == ship.EndCoordinates[1])
        {
            return Math.Sqrt(Math.Pow(ship.StartCoordinates[1], 2) + Math.Pow(ship.EndCoordinates[1], 2));
        }
        else
        {
            return Math.Sqrt(Math.Pow(ship.StartCoordinates[0], 2) + Math.Pow(ship.EndCoordinates[0], 2));
        }
    }
}