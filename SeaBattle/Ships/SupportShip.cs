using SeaBattle.Interfaces;

namespace SeaBattle.Ships;

public class SupportShip : ShipBase, ISupport
{
    public SupportShip(int size, int speed, int range) : base(size, speed, range)
    {
    }

    public void Repair(int quadrant, int x, int y)
    {
        Console.WriteLine($"Shooting");
    }
}