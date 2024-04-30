using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVolume : MonoBehaviour
{
    public GameObject Music;
    public GameObject SoundFX;
    void Update()
    {
        Music.GetComponent<AudioSource>().volume = Volume.musicvolume;
        SoundFX.GetComponent<AudioSource>().volume = Volume.soundfxvolume;
    }
}
