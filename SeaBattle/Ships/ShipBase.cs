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
        return this.Equals(obj);
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
        return $"{this.Size} cell ship has a speed of {this.Speed} and a range of {this.Range}";
    }
}
