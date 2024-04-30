using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private Vector3 velocity;
    void Start()
    {
        StartCoroutine(Deactive());
    }


    private IEnumerator Deactive()
    {
        yield return new WaitForSeconds(3);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(Active());
    }

    private IEnumerator Active()
    {
        yield return new WaitForSeconds(3);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(Deactive());
    }

}
