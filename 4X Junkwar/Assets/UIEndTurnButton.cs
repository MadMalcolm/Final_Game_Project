using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndTurnButton : MonoBehaviour
{
    public void ButtonClicked()
    {
        UniverseManager.Instance.HumanPlayer.EndTurn();
    }
}
