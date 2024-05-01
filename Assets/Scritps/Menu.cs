using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject player;
    public GameObject pause;
    public GameObject pausebutton;
    public TMP_Text shield;
    public TMP_Text magnit;
    public void Pause()

    {
        pausemenu.SetActive(true);
        player.GetComponent<ColourChange>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        pause.SetActive(false);
        gameObject.GetComponent<Animator>().SetBool("Move", false);
    }
    public void Resume()

    {
        pausemenu.SetActive(false);
        player.GetComponent<ColourChange>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        pause.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("Move", true);
    }

    public void Restart()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()

    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel()

    {
        Levels.currentlevel++;
        if (Levels.currentlevel < 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Levels.currentlevel >= 10)
        {
            SceneManager.LoadScene(Levels.currentlevel - 9);
        }


    }

    private void Update()
    {
        if (Tutorial.istutorial)
        {
            pausebutton.SetActive(false);
        }
        else
        {
            pausebutton.SetActive(true);
        }

        magnit.text = Shop.magnitcount.ToString();
        shield.text = Shop.shieldcount.ToString();
    }

}
