using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> colors = new List<GameObject>();
    void Start()

    {

        for (int i = 0; i < 4; i++)
        {
            float x = 1.3f - (i*0.9f);
            colors[i].transform.position = new Vector3(x, 6.24f, -5f);

        }

    }

}
