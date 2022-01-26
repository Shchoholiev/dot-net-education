using SeaBattle.Interfaces;

namespace SeaBattle.Ships;

public class CombinedShip : ShipBase, IMilitary, ISupport
{
    public CombinedShip(int size, int speed, int range) : base(size, speed, range)
    {
    }

    public void Shoot(int quadrant, int x, int y)
    {
        Console.WriteLine($"Shooting");
    }

    public void Repair(int quadrant, int x, int y)
    {
        Console.WriteLine($"Repairing");
    }
}