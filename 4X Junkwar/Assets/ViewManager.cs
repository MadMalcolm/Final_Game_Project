using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    
    private void OnEnable() //runs immediately as opposed to after next frame...I thinks
    {
        Instance = this;
    }

    public static ViewManager Instance { get; set; }

    public GalaxyVisuals GalaxyVisuals;
    public SystemView SystemView;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // back out of windows one at a atime
            // or open menu at main screen
            HideView(SystemView);
        }

    }

    public void ShowView( MonoBehaviour viewComponent)
    {
        viewComponent.gameObject.SetActive(true);

    }

    public void HideView(MonoBehaviour viewGComponent)
    {
        viewGComponent.gameObject.SetActive(false);
    }

}
