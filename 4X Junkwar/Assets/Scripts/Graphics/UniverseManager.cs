using Junkwars;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UniverseManager : MonoBehaviour

// Script is resonsible for holding the main galaxy data objects,
// triggering file save/loads or triggering the generation of the new galaxy


{
    // Start is called before the first frame update
    void Start()
    {
        Generate();// for now we will put here for testingz..itz onlyz testingz
    }

    // public GameObject[] StarPrefab;
    //public GalaxyVisuals GalaxyVisuals;

    static UniverseManager _instance;
    public static UniverseManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UniverseManager>();
            }

            return _instance;
        }
    }
   

    public Galaxy galaxy { get; set; }

    Player currentPlayer; // could be AI or human player

    public Player_Human HumanPlayer { get; set; } // UI player -- change in hotseat...

    private void Update()
    {/*
        if(galaxy.GetCurrentPlayer().DoTurn() == true )
        {
            //current player needs more time,
        }
        else
        {
            //current player done
            galaxy.AdvanceCurrentPlayer();
            UpdateCurrentHumanPlayer();
            // if hotseat, could do something like
            // if new current player is of type Player_Human, update PlayerHuman
        }
        */

        //currentPlayer.DoTurn();
    }
    void UpdateCurrentHumanPlayer()
    {
        // Update player used for the UI -- that will be the current
        // next human
        HumanPlayer = galaxy.GetCurrentHumanPlayer();
    }

    public void Generate()
    {
        Debug.Log("UniverseManager::Generate -- Generating new galaxy");

        galaxy = new Galaxy();
        galaxy.Generate();

        //UpdateCurrentHumanPlayer();

        ViewManager.Instance.GalaxyVisuals.InitiateVisuals(galaxy);
    }
}
