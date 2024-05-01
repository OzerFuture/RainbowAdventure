using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Levels : MonoBehaviour
{
    public GameObject level;
    public TMP_Text leveltext;
    public static int currentlevel = 1;
    public List<TMP_Text> levelnames = new List<TMP_Text>();
    private int pagenumber;
    private int number;
    public GameObject nextpage;
    public GameObject prepage;

    void Start()
    {
        for (int i = 0; i < 5; i++ )
        {
            Vector3 newposition_y = new Vector3(0, 1350 - i * 200, 0); 

            for (int j = 0; j < 3; j++)

            {
                Vector3 newposition_x = new Vector3(160 + 200 * j, newposition_y.y, 0);

                GameObject newlevel = Instantiate(level, newposition_x, transform.rotation);
                TMP_Text newleveltext = Instantiate(leveltext, newposition_x, transform.rotation);

                newlevel.transform.SetParent(transform,true);
                newlevel.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                newlevel.transform.name = (3 * (i) + j + 1).ToString();

                newleveltext.transform.SetParent(transform, true);
                newleveltext.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

                newleveltext.text = (3*(i) + j + 1).ToString();
            }

        }    
    }

    public void OpenScene()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        currentlevel = int.Parse(buttonName);
        if (currentlevel <= 10)
        {
            SceneManager.LoadScene(currentlevel + 1);
        }

        if (currentlevel > 10)
        {
            SceneManager.LoadScene(currentlevel - 9);
        }


    }

    public void NextPage()
    {
        pagenumber++;
        LevelNames();

        prepage.SetActive(true);

        if (pagenumber == 33)
        {
            nextpage.SetActive(false);
        }
    }

    public void PrePage()
    {
        pagenumber--;
        LevelNames();

        nextpage.SetActive(true);

        if (pagenumber == 0)
        {
            prepage.SetActive(false);
        }
    }


    public void LevelNames()
    {
        for (int i = 0; i < levelnames.Count; i++)
        {
            levelnames[i].text = ((i+1) + 15*pagenumber).ToString();
        }

    }
}

