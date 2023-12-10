using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnTap : MonoBehaviour
{
    public void PlaySound()
    {
        if (AudioSettings.isSoundsTurnedOff) return;
        ObjectsContainer.audioManager.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(PlacebleObjectsData.LoadFromAssets().buttonTapClip);
    }
}
