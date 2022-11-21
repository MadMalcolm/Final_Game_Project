using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junkwars
{
    public static class Config
    {
        // Values are coded here for now, but the goal will be to load in from a 
        // config file that is modable

        public static int GetInt(string Parameter)
        {
            switch (Parameter)
            {
                case "PLANET_MAX_POPULATION_TINY":
                    return 4;
                case "PLANET_MAX_POPULATION_SMALL":
                    return 6;
                case "PLANET_MAX_POPULATION_MEDIUM":
                    return 9;
                case "PLANET_MAX_POPULATION_LARGE":
                    return 12;
                case "PLANET_MAX_POPULATION_HUGE":
                    return 16;
                case "STAR_MAX_PLANETS":
                    return 6;
                default:
                    Debug.LogError("GetInt: not found" + Parameter);
                        return 0;

            }
        }
        public static float GetFloat(string Parameter)
        {
            switch (Parameter)
            {
                case "STAR_ORBIT_DISTANCE":
                    return 1.0f;
                default:
                    Debug.LogError("GetFloat: not found" + Parameter);
                    return 0;

            }
        }
    }
}