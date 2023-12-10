using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private void Update()
    {
        if (AudioSettings.isMusicTurnedOff && GetComponent<AudioSource>().volume > 0) GetComponent<AudioSource>().volume -= 0.01f;
        else if (!AudioSettings.isMusicTurnedOff && GetComponent<AudioSource>().volume < 100) GetComponent<AudioSource>().volume += 0.01f;
    }
}
