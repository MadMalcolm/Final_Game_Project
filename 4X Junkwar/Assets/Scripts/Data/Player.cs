using UnityEngine;
using System.Collections.Generic;


namespace Junkwars
{
    public abstract class Player
    {
        public Player (int planetIndex)
        {
            PlayerIndex = planetIndex;
            colonies = new List<Colony> ();
        }

        public readonly int PlayerIndex;
        int Race;
        int Money;

        

        bool[] unlockedTechnologies; // not good enough....figure something else out


        List<Colony> colonies;
        //List<int> colonyID;

        // returns true if still working on turn; false is done
        public abstract bool DoTurn();


    }

    public class Player_Human : Player
    {
        public Player_Human(int planetIndex) : base(planetIndex)
        {

        }

        bool endTurnButtonClicked = false;

        public void EndTurn()
        {
            endTurnButtonClicked = true;
        }

        public override bool DoTurn()
        {
            //what IS the humans turn
            // end turn is clicked

            if(endTurnButtonClicked) 
            {
                //done
                endTurnButtonClicked = false;
                return false;
            }
            // if we get here..not done taking turn...ask more time
            return true;
        }
    }

    public class Player_AI : Player
    {
        public Player_AI(int planetIndex) : base(planetIndex)
        {

        }
        public override bool DoTurn()
        {
            //AI stuff....
            // Don't freeze UI

            //use co-routins or a thread to do calculations
            //return from DoTurn() quickly/frequently
            //return true;

            return false;
        }
    }

}
