using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Place
{
    private static readonly string[] possiblePlaces = new string[] {"Stack", "Hand", "Table", "Coffin"};
    public static string Stack => possiblePlaces[0];
    public static string Hand => possiblePlaces[1];
    public static string Table => possiblePlaces[2];
    public static string Coffin => possiblePlaces[3];
}
