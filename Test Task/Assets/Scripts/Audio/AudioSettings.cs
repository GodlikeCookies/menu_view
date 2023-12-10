using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public static bool isSoundsTurnedOff;
    public static bool isMusicTurnedOff;

    public void OpenPanel() => GameObject.Instantiate(PlacebleObjectsData.LoadFromAssets().settingsPanel, ObjectsContainer.menuViewCanvas);
    public void ClosePanel() => GameObject.Destroy(gameObject);
    public void TurnSounds()
    {
        if (isSoundsTurnedOff) isSoundsTurnedOff = false;
        else isSoundsTurnedOff = true;
    }
    public void TurnMusic()
    {
        if (isMusicTurnedOff) isMusicTurnedOff = false;
        else isMusicTurnedOff = true;
    }
}
