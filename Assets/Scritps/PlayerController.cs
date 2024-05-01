using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isTouching = false;
    private float touchDuration = 0.0f;

    public float shootTime;

    public float vx = 0.33f;
    public float vz = -0.706f;

    private Rigidbody rb;

    public Transform groundPlane;
    private Camera mainCamera;

    public LineRenderer lineRenderer;
    private Vector3 hitPoint;
    private Vector3 way;

    public static bool gameStarted;

    private Vector3 pos;

    private float dis = 0.4f;

    public GameObject sphere;

    private void Start()
    {
        mainCamera = Camera.main;
        gameStarted = false;
        hitPoint = Vector3.zero;
    }


    private void Update()
    {
        HandleInput();
        ProcessMovement();
    }

    private void HandleInput()
    {
        // Check if the mouse is within the screen bounds
        if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width &&
            Input.mousePosition.y >= 0 && Input.mousePosition.y <= Screen.height)
        {
            // Start the game on any touch or mouse click
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
            }
        }
    }

    private void ProcessMovement()
    {
        if (!gameStarted) return;

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (gameStarted == true)
                MoveTowards(hit.point);
        }
    }

    private void MoveTowards(Vector3 hitPoint)
    {
        Vector3 pos = new Vector3(hitPoint.x, 5.767758f, hitPoint.z);
        Vector3 distancev = (pos - transform.position);
        float distance = Vector3.Magnitude(distancev);

        transform.position = Vector3.MoveTowards(transform.position, pos, 1 * Time.deltaTime);

        if (distance > 0.005f)
        {
            transform.rotation = Quaternion.LookRotation(distancev + transform.forward, Vector3.up);
            gameObject.GetComponent<Animator>().SetBool("Move", true);
        }

        if (distance < 0.005f)
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
        }
    }
}