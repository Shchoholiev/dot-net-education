namespace SeaBattle.Ships;

public class ShipBase
{
    public ShipBase(int size, int speed, int range)
    {
        Size = size;
        Speed = speed;
        Range = range;
    }
    public int Size { get; set; }

    public int Speed { get; set; }

    public int Range { get; set; }

    public void Move(int speed, string direction)
    {
        throw new NotImplementedException();
    }

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
}
