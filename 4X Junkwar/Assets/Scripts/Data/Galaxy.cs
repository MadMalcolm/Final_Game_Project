using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Junkwars
{

    public static class GalaxyConfig
    {
        // This gets filled out by "new game" screen and is used
        // by Generate function to tune the game params
        public static int NumPlayers = 8;
        public static int NumStars = 50;

        // Total width/range of da galaxy
        public static int GalaxyWidth = 80; // perhaps adjustable as well

        // Fine Tune Spacing
        public static int DetectDistance = 12;
        public static int MoveDistance = 24;
        // consider reading defaults from a config file
    }
   public class Galaxy
    {

        public Galaxy()
        {
            players = new List<Player>();
            starSystems = new List<StarSystem>();
            
        }

        

        private List<StarSystem> starSystems;

        private List<Planet> planets;

        private List<Colony> colonies;

        private List<Player> players;

        Player currentPlayer; // UI player -- change in hotseat...

        int currentPlayerIndex = 0;

        int turnCounter;

        public Player[] GetPlayers()
        {
            return players.ToArray();
        }

        public Player GetPlayer(int playerIndex)
        {
            return players[playerIndex];
        }

        public Player GetCurrentPlayer()
        {
            return GetPlayer(currentPlayerIndex);
        }

        public Player_Human GetCurrentHumanPlayer()
        {
            // Return player due to take turn...current or nextist

            int i = currentPlayerIndex;
            do
            {
                if(players[i] is Player_Human)
                {
                    return (Player_Human)players[i];
                }
                i = (i + 1) % players.Count; 
            } while (i != currentPlayerIndex);

            Debug.LogError("No human players?");
            return null;

        }

        public void AdvanceCurrentPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            if(currentPlayerIndex == 0)
            {
                turnCounter++;
            }
        }
        public StarSystem GetStarSystem(int StarSystemId)
        {
            return starSystems[StarSystemId];
        }

        public int GetNumStarSystems()
        {
            return starSystems.Count;
        }

        public void Generate()
        {
            // First pass, just make some random stars for us

            int galaxyWidth = GalaxyConfig.GalaxyWidth;
            for (int i = 0; i < GalaxyConfig.NumStars; i++)
            {
                StarSystem ss = new StarSystem();
                ss.Position = new Vector3(
                    Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                    Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                    0
                    );

                // changes based upon distance from center?
                // players spread? or somewhere else?

                // make sure they don't spawn to close to one another...SpacedApartStars(ss)
                SpacedApartStars(ss).Generate();

                ss.Name = "Star " + i.ToString();

                starSystems.Add(ss);

                //Debug.Log("Star Generated at: " + ss.Position.x + ", " + ss.Position.y);
            }

            Debug.Log("Num Stars Generated: " + starSystems.Count);

            // need something else for multiplayer; hotseat
            for (int i = 0; i < GalaxyConfig.NumPlayers; i++)
            {
                Player p;
                // 0th is humkan
                if (i == 0)
                {
                    p = new Player_Human(i);
                }
                else
                {
                    p = new Player_AI(i);
                }
            }
        }

        public void Load(/* some shit in here */)
        {

        }
        public void Save(/* some shit in here */)
        {

        }

        private StarSystem SpacedApartStars(StarSystem ss)
        {

            // fine tune final move a bit...
            int detectDistance = GalaxyConfig.DetectDistance;
            int moveDistance = GalaxyConfig.MoveDistance;
            int galaxyWidth = GalaxyConfig.GalaxyWidth;// poor mans' getter

            for (int j = 0; j < starSystems.Count; j++)
            {
                if (ss.Position.x < starSystems[j].Position.x + detectDistance && ss.Position.x > starSystems[j].Position.x - detectDistance &&
                    ss.Position.y < starSystems[j].Position.y + detectDistance && ss.Position.y > starSystems[j].Position.y - detectDistance)
                {               
                    ss.Position = new Vector3(
                    Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                    Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                    0
                    );

                }
                for (int k = 0; k < starSystems.Count; k++)
                {
                    if (ss.Position.x < starSystems[j].Position.x + detectDistance && ss.Position.x > starSystems[j].Position.x - detectDistance &&
                        ss.Position.y < starSystems[j].Position.y + detectDistance && ss.Position.y > starSystems[j].Position.y - detectDistance)
                    {
                        ss.Position = new Vector3(
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                        0
                        );
                    }

                    for (int l = 0; l < starSystems.Count; l++)
                    {
                        if (ss.Position.x < starSystems[j].Position.x + detectDistance && ss.Position.x > starSystems[j].Position.x - detectDistance &&
                            ss.Position.y < starSystems[j].Position.y + detectDistance && ss.Position.y > starSystems[j].Position.y - detectDistance)
                        {
                            ss.Position = new Vector3(
                            Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                            Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                            0
                            );
                        }
                    }
                }
                
            }
            
                return ss;
        }

        
    }
    
}
