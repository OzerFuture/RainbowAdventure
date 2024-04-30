using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CrystalCollect : MonoBehaviour
{

    private float score;
    public TMP_Text scoretext;
    public TMP_Text resulttext;
    public TMP_Text levelname;
    public GameObject result;
    public GameObject main;
    public GameObject SoundFX;

    void Update()
    {
        scoretext.text = score.ToString();

        if (Abilities.isMagnit == true && score < 3)

        {

            GameObject crystal = GameObject.FindWithTag("Crystal");

            if ((transform.position - crystal.transform.position).magnitude  < 3)
            {
               
                crystal.transform.position = Vector3.MoveTowards(crystal.transform.position, transform.position, 2 * Time.deltaTime);

               
            }

            
        }

        if(score == 3)
        {
           result.SetActive(true);
           main.SetActive(false);
           GetComponent<ColourChange>().enabled = false;
           GetComponent<PlayerController>().enabled = false;
            levelname.text = "Level" + " " + Levels.currentlevel.ToString();
            Abilities.isMagnit = false;
            gameObject.GetComponent<Animator>().SetBool("Move", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Crystal"))

        {
            score++;
            Destroy(other.gameObject);
            Abilities.isMagnit = false;
            SoundFX.GetComponent<AudioSource>().Play();
            if (score == 3)
            {
                Shop.balance += 3;
            }
        }

    }



}
