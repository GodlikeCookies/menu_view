using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlacebleObjectsData : ScriptableObject
{
    public AudioClip buttonTapClip;

    public GameObject settingsPanel;
    public GameObject weeklyBonusPanel;
    public GameObject day7BonusPanel;

    public GameObject shopItemTickets;
    public static PlacebleObjectsData LoadFromAssets()
    {
        return Resources.Load("PlacebleObjects") as PlacebleObjectsData;
    }
}
