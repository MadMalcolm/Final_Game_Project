using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Rendering;

namespace Junkwars
{
    public class Building
    {
        // Represents constructed buildings on planet
        // maybe also gets used in a constructor
        public Building( string Name, int RequiredProduction, int UnlockedByTech,
            BuildingEndOfTurnFunction endOfTurnFunction)
        {
            this.Name = Name;
            this.RequiredProduction = RequiredProduction;
            this.UnlockedByTechId = UnlockedByTech;
            this.endOfTurnFunction = endOfTurnFunction;
        }
        string Name;
        int RequiredProduction;
        int UnlockedByTechId = -1;

        // int BonusFlatProd???? 
        // int BonusResearch
        // int BonusFoods???

        public delegate void BuildingEndOfTurnFunction(Colony colony, int currentGameTurn, int builtGameTurn);
        event BuildingEndOfTurnFunction endOfTurnFunction;

        public void DoEndOfTurn(Colony colony, int currentGameTurn, int builtGameTurn)
        {
            endOfTurnFunction(colony, currentGameTurn, builtGameTurn);
        }
    }

    static public class SetupBuildings
    {
        static SetupBuildings ()
        {
            // This function will read a config file with building
            // params and maybe LUA code for EoT logic....
            AllBuildings = new Building[]
            {
                new Building("Barracks", 100, -1, (c, turn, built) => 
                {Debug.Log("Barracks Turn Processing!"); } ),
            };
        }

        static public Building[] AllBuildings;
    }

}
