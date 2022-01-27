using SeaBattle.Interfaces;

namespace SeaBattle.Ships;

public class CombinedShip : ShipBase, IMilitary, ISupport
{
    public CombinedShip(int size, int speed, int range)
        : base(size, speed, range)
    {
    }

    public void Shoot(int quadrant, int moduleX, int moduleY)
    {
        Console.WriteLine($"Shooting");
    }

    public void Repair(int quadrant, int moduleX, int moduleY)
    {
        Console.WriteLine($"Repairing");
    }
}