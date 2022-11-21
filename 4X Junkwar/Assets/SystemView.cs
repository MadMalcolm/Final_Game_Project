using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Junkwars;

public class SystemView : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("System:OnEnable -- " + StarSystem.Name);
        // Update UI ELements

        // Setup render view of planets
        SpawnRenderables();
        
    }

    private void OnDisable()
    {
        // remove planets while on galaxy map
        while(StarSystem3dContainer.transform.childCount > 0)
        {
            Transform t = StarSystem3dContainer.transform.GetChild(0);
            t.SetParent(null);
            Destroy(t.gameObject);

            //StarSystem3dContainer.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public StarSystem StarSystem;

    public GameObject StarSystem3dContainer;

    public GameObject StarPrefab; //will have to be read in from some library linking star type to many images of each type

    public GameObject PlanetPrefab; // ditto

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRenderables()
    {
        //spawn star
        GameObject go;

        go = Instantiate(StarPrefab, StarSystem3dContainer.transform);
        go.transform.localPosition = Vector3.zero;

        //spawn planets
        float orbitDistance = 0f;
        for (int i = 0; i < StarSystem.GetMaxPlanets(); i++)
        {
            orbitDistance += Config.GetFloat("STAR_ORBIT_DISTANCE");
            Planet p = StarSystem.GetPlanetAtIndex(i);
            if (p == null)
            {
                continue;
            }

            // Valid planets here
            go = Instantiate(PlanetPrefab, StarSystem3dContainer.transform);
            go.transform.localPosition = Quaternion.Euler(0, 0, Random.Range(0, 359)) * new Vector3(orbitDistance, 0, 0);
            
        }
    }
}
