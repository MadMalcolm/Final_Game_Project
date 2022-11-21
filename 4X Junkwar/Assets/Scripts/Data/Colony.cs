using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junkwars
{
    public class Colony
    {

        public readonly int ColonyIndex;
        public Planet Planet;

        


        int population { get { return workers + farmers + researchers; } }
        int workers;
        int farmers;
        int researchers;

        int flatProduction; //Normally zero without automated factories
        int productionPerWorker; // PlanetRichness/2 + 1

        public int TotalProductionPerTurn()
        {
            return flatProduction + productionPerWorker * workers;
            // also loop through all buildings(modify workers, flat
        }

        //List<Building> BuiltBuildings;

        List<int> BuiltBuildingIndexes;
        List<int> BuildingBuiltTurn;

        public void DoEndOfTurn()
        {
            // foreach built building, call EOT update and pass value of turn built on
        }

        public int MaxPopulation()
        {
            int pMax = Config.GetInt("PLANET_MAX_POPULATION_" + Planet.PlanetSize.ToString());
            // Add additional species, tech modifiers here
            // planetary specials
            return pMax;
        }

        void GetListOfValidBuilding()
        {
            // returns array of all buildings that can be build

            // for each building, look up in tech list
            // OR.....
            //whenever tech unlocked...update some list of available buildings

            // filter out already built buildings


        }

        public void DoTurnProduction()
        {
           // int foodAmount = Player.Race.Basefood;
            // now look up all tech might affect the food
           // foreach(Technology t in allTechs)
            {
                //is this tech unlocked by this player?
               // foodAmount += t.foodBonus;
            }
        }
    }
}
