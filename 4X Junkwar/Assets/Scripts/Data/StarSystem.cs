using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Junkwars
{
    public class StarSystemGraphic
    {
        // int? string? sprite? texture?
    }
    public class StarSystem
    {
        public StarSystem()
        {
            planets = new Planet[GetMaxPlanets()];
            // generate the dang planets idiot
        }

        public Vector3 Position;

        //private const int MAX_PLANETS = 6;

        private Planet[] planets;

        public string Name;

        public const int MIN_STAR_TYPE = -2; // just for now
        public const int MAX_STAR_TYPE = 2;

        public int StarType { get; private set; } // 0 = Yellow : + = older, less rich : - = younger, less hab



        public StarSystemGraphic StarSystemGraphic { get; set; }

        public Planet GetPlanet(int PlanetIndex)
        {
            return planets[PlanetIndex];
        }
        public void Generate()//galacitc age/rich info...special info
        {
            this.StarType = StarType;


            GeneratePlanets();
        }

        public int GetNumPlanets()
        {
            int c = 0;
            for (int i = 0; i < Config.GetInt("STAR_MAX_PLANETS"); i++)
            {
                if (planets[i] != null)
                {
                    c++;
                }
            }
            return c;
        }

        public int GetMaxPlanets()
        {
            return Config.GetInt("STAR_MAX_PLANETS");
        }

        public Planet GetPlanetAtIndex(int i)
        {
            return planets[i];
        }

        public void Load(/* some shit in here */)
        {

        }

        public void Save(/* some shit in here */)
        {

        }

        public int GetStarTypeIndex()
        {
            // convert from -2 to 2 to 0  to 4
            return StarType - MIN_STAR_TYPE;
        }

        private void GeneratePlanets(int starType = 0)
        {
            // Generate 0 to Max planets, weighting planet class based on 
            // Star type, and distance to the sun
            //generate planets

            //star type influence types of planets?

            float planetChance = 0.50f;

            for (int i = 0; i < Config.GetInt("STAR_MAX_PLANETS"); i++)
            {
                if(UnityEngine.Random.Range(0f,1f) < planetChance)
                {
                    //make planet
                    Planet planet = new Planet();
                    planets[i] = planet;
                    planet.Name = GeneratePlanetName(i);

                    int size_max = (int)PlanetSize.COUNT;     //Enum.GetValues(typeof(PlanetSize)).Length;
                    planet.PlanetSize = (PlanetSize)Enum.GetValues(typeof(PlanetSize)).GetValue(UnityEngine.Random.Range(0, size_max));

                }
            }

        }
        string GeneratePlanetName(int pos)
        {
            // do real planet names later on
            return Name + " " + (pos + 1).ToString();
        }

        PlanetType GeneratePlanetType(int pos)
        {
            float goldilocksRange = 0.5f; // tweak this on star type, galaxy settings

            float distance = (float)pos / (float)GetMaxPlanets();
            float distanceSquared = distance * distance;

            float gasGiantWeight = Mathf.Lerp(0f, 1f, distanceSquared);
            float goldilocksWeight = Mathf.Lerp(1f, 0f, 2 * Mathf.Abs( goldilocksRange - distance));
            float asteroidWeight = 1.0f;

            // Cool suns should have goldilocks closer to sun; vice versa


            float allWeights = gasGiantWeight + goldilocksWeight + asteroidWeight;

            float r = UnityEngine.Random.Range(0, allWeights);

            if (r < gasGiantWeight) //is less than one?
            {
                return PlanetType.GasGiant;
            }

            r -= gasGiantWeight; //remove 1 and ask again

            if (r < goldilocksWeight) // is less than 1?
            {
                return PlanetType.Continental;
            }

            r -= goldilocksWeight; //remove 1 ask again

            return PlanetType.Asteroid; // if we make it to here, an asteroid was rolled
        }
    }
}
