using Assets.BattleAPI.Core;
using Card;

namespace Assets.BattleAPI.Zones
{
    public static class ZoneHelper
    {
        public static Vector GetPosition(Zone zone, int z)
        {
            return zone switch
            {
                Zone.Deck => new Vector(8.0f, 0, 2.0f * z),
                Zone.Hand => new Vector(-8.0f, 0, 3.3f * z),
                Zone.Battlefield => new Vector(8.0f, 0, 1.2f * z),
                Zone.Graveyard => new Vector(50.0f, 0, 0.0f * z),
                _ => null,
            };
        }
    }
}
