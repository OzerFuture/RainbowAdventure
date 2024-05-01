using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;

public class download : MonoBehaviour
{
    public GameObject bar;
    public int time;
    void Start()
    {
        AnimateBar();
    }


    private void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time).setOnComplete(GameStart);
    }

    private void GameStart()
    {
        SceneManager.LoadScene(1);
    }    
}
