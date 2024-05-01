using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        float playerz = player.transform.position.z - 2f;
        transform.position = new Vector3(transform.position.x, transform.position.y, playerz);
    }
}
