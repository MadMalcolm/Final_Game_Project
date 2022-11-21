using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Junkwars;

public class ClickableStar : MonoBehaviour
{
    
        private void Start()
        {
            GetComponentInChildren<TextMeshProUGUI>().text = StarSystem.Name;
        }
    
    public StarSystem StarSystem;

    public void OnClick()
    {
        Debug.Log("ClickableStar--OnClick: " + StarSystem.Name);
        ViewManager.Instance.SystemView.StarSystem = StarSystem;
        ViewManager.Instance.ShowView(ViewManager.Instance.SystemView);
    }

}
