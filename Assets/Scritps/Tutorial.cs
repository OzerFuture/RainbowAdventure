using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TMP_Text tuttext;
    public GameObject finger;
    private float tutphase;
    public static bool istutorial = true;
    private bool starttutorial;
    public GameObject player;
    public CrystalCollect crystls;

    private void Start()
    {
        tutphase = 0;
        starttutorial = false;
    }

    void Update()
    {

        gameObject.SetActive(istutorial);

        if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width &&
    Input.mousePosition.y >= 0 && Input.mousePosition.y <= Screen.height)
        {

            if (Input.touchCount > 0 && starttutorial == false)
            {
                tutphase++;
                starttutorial = true;
            }
        }

        if (tutphase > 0 && crystls.scoretext.text == "1")
        {
            StartCoroutine(Tutor());
            tutphase = 0;
        }

    }

    private IEnumerator Tutor()
    {
        player.GetComponent<Animator>().SetBool("Move", false);
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<ColourChange>().enabled = false;
        transform.position = new Vector3(350f, 1850, 0);
        tuttext.text = "Collect crystalls to win";
        StartCoroutine(Tutor2());
        yield return null;

    }
    private IEnumerator Tutor2()
    {
        yield return new WaitForSeconds(3f);
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<ColourChange>().enabled = false;
        transform.position = new Vector3(270f, 2150f, 0);
        tuttext.text = "Look for a safe color for moving";
        StartCoroutine(Tutor3());
        yield return null;
    }

    private IEnumerator Tutor3()
    {
        yield return new WaitForSeconds(3f);
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<ColourChange>().enabled = false;
        tuttext.gameObject.transform.position = tuttext.gameObject.transform.position + new Vector3(-2f, 100, 0);
        transform.position = new Vector3(340f, 450, 0);
        tuttext.text = "Buy special abilities and use";
        StartCoroutine(Tutor4());
        yield return null;
    }

    private IEnumerator Tutor4()
    {
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<ColourChange>().enabled = true;
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        istutorial = false;
        yield return null;
    }
 

}
