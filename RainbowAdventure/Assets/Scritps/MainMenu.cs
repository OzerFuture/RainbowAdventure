using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject ShopUI;
    public GameObject OptionsUI;
    public GameObject PlayUI;
    private bool notmenu;
   
    void Start()
    {
        notmenu = false;   
    }

    public void Play()
    {
        if (Tutorial.istutorial)
        {
        SceneManager.LoadScene(2);
        }
        else
        {
        MenuUI.SetActive(notmenu);
        PlayUI.SetActive(!notmenu);
        }
    }

    public void Shop()
    {
        MenuUI.SetActive(notmenu);
        ShopUI.SetActive(!notmenu);
    }

    public void Settings()
    {
        MenuUI.SetActive(notmenu);
        OptionsUI.SetActive(!notmenu);
    }


    public void ToMainMenu()
    {
        MenuUI.SetActive(!notmenu);
        ShopUI.SetActive(notmenu);
        OptionsUI.SetActive(notmenu);
        PlayUI.SetActive(notmenu);
    }
}
