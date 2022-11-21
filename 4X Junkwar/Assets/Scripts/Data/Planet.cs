using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junkwars
{
    public class PlanetGraphic
    {

    }

    // Kept out of Planet class too declare PlanetType PlanetType below....
    public enum PlanetType { Asteroid, GasGiant, Continental, Gaia, Oceanic, Barren, Radiated, Toxic, Desert, Arid, Tundra }

    public enum PlanetSize { Tiny, Small, Medium, Large, Huge, COUNT}

    public enum PlanetRichness { VeryPoor, Poor, Average, Rich, VeryRich}

    public enum PlanetTrait { GoldDeposit, ArtifactWorld, Natives }


    public class Planet
    {
        public PlanetGraphic PlanetGraphic;

        public string Name;



        public readonly int PlanetIndex;
        
        public PlanetType PlanetType;

        public PlanetSize PlanetSize;

        public PlanetRichness PlanetRichness;

        List<PlanetTrait> PlanetTraits;

        public Colony Colony;


        //public Dictionary<string, float> NumValues;
    }
}
