using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Junkwars;

public class GalaxyVisuals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public LayerMask ClickableStarsLayerMask;


    // Update is called once per frame
    void Update()
    {
      /*  
        if (Input.GetMouseButtonUp(0)) 
        { 
            // mouse was clicked is it on a clickable thang
            // Stars for now
            // IGNORE UI ELEMENTS

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // different reasons for different ray casts...
            //sometimes you want it to be blocked by another object
            // some times you want to click the star you want
            if(Physics.Raycast(ray, out hitInfo, ClickableStarsLayerMask))
            {
                // we hit a CLICKABLE STAR ONLY
                ClickableStar cs = hitInfo.collider.GetComponentInParent<ClickableStar>();

                if(cs == null)
                {
                    Debug.LogError("Star has no clickable component");
                    return; // for now
                }

                Debug.Log("Clicked Star: " + cs.name);

                // System View/View Manager objects
                //GameObject.FindObjectOfType<SystemView>().gameObject.SetActive(true); so system view need not be always active to 
                //be accessed....below better

                ViewManager.Instance.SystemView.StarSystem = cs.StarSystem;
                ViewManager.Instance.ShowView(ViewManager.Instance.SystemView);
            }
        }
        */
    }

    public GameObject[] StarPrefabs; // Index of array is a star type
                                    // prefabs responsible for having appearance variety

    Galaxy galaxy;
    public void InitiateVisuals(Galaxy galaxy)
    {
        this.galaxy = galaxy;

        for (int i = 0; i < galaxy.GetNumStarSystems(); i++)
        {
            StarSystem ss = galaxy.GetStarSystem(i);
            GameObject go = Instantiate(
                StarPrefabs[ss.GetStarTypeIndex()],
                ss.Position,  // mult by a scaler?
                Quaternion.identity,
                this.transform);

            go.GetComponent<ClickableStar>().StarSystem = ss;

            //go.GetComponentInChildren<Text>().text = ss.Name;

            
            
        }
    }
}
