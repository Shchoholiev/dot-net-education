namespace SeaBattle.Ships;

public class ShipBase
{
    public ShipBase(int size, int speed, int range)
    {
        this.Size = size;
        this.Speed = speed;
        this.Range = range;
    }

    public int Size { get; set; }

    public int Speed { get; set; }

    public int Range { get; set; }

    public int[]? StartCoordinates { get; set; }

    public int[]? EndCoordinates { get; set; }

    public static bool operator ==(ShipBase first, ShipBase second)
    {
        return first.GetType().Name == second.GetType().Name
               && first.Size == second.Size
               && first.Speed == second.Speed;
    }

    public static bool operator !=(ShipBase first, ShipBase second)
    {
        return !(first == second);
    }

    public override bool Equals(object? obj)
    {
        if (this.GetType().Name != obj?.GetType().Name)
        {
            return false;
        }

        var ship = (ShipBase)obj;
        return this.Size == ship.Size
               && this.Speed == ship.Speed;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public void Move(int speed, string direction)
    {
        Console.WriteLine("Moving");
    }

    public override string ToString()
    {
        var text = $"{this.Size} cell ship has a speed of {this.Speed} and a range of {this.Range}";
        if (this.StartCoordinates != null && this.EndCoordinates != null)
        {
            text += $" and coordinates: [ ( {this.StartCoordinates[0]}; {this.StartCoordinates[1]} ) " +
                $"( {this.EndCoordinates[0]}; {this.EndCoordinates[1]} ) ]";
        }

        return text;
    }
}
