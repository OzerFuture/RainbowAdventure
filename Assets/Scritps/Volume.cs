using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Volume : MonoBehaviour
{
    public static float musicvolume = 1;
    public static float soundfxvolume = 1;
    public Slider mainSlider;
    public Slider soundfx;

    private void Awake()
    {
        mainSlider.value = musicvolume;
        soundfx.value = soundfxvolume;
    }
    void Update()
    {
        musicvolume = mainSlider.value;
        soundfxvolume = soundfx.value;
    }
}
