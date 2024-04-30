using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private bool isSwiping = false;
    private float XPosition;
    private Vector2 SwipePosition;
    private Vector2 SwipeDelta;
    public float speed = 1f;
    public static bool Gamestarted = false;
    private float xboundary; 

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb = GetComponent<Rigidbody>();
       rb.velocity = new Vector3(0, 0, speed);



        if (Input.touchCount > 0)
        {
            Gamestarted = true;


            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                XPosition = transform.position.x;
                isSwiping = true;
                SwipePosition = Input.GetTouch(0).position;
            }

            else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {

                transform.position = new Vector3(xboundary, transform.position.y, transform.position.z);
                ResetSwipe();
            }

        }

        CheckSwipe();

    }

    private void CheckSwipe()

    {
        SwipeDelta = Vector2.zero;

        if (Input.touchCount > 0)
        {
            SwipeDelta = Input.GetTouch(0).position - SwipePosition;
  
        }

        if (SwipeDelta.magnitude > 80)
        {

            if (Mathf.Abs(SwipeDelta.x) > Mathf.Abs(SwipeDelta.y))
            {
                OnSwipe(SwipeDelta.x > 0 ? Vector2.right : Vector2.left);
            }
            //else
            //{
                //OnSwipe(SwipeDelta.y > 0 ? Vector2.up : Vector2.down);
           // }

            ResetSwipe();
        }


    }

    private void ResetSwipe()
    {
        isSwiping = false;
        SwipePosition = Vector2.zero;
        SwipeDelta = Vector2.zero;
    }


    private void OnSwipe(Vector3 direction)

    {
        Vector3 newposition = transform.position + 0.9f*direction;
        xboundary = Mathf.Clamp(newposition.x, -1.4f, 1.3f);
        //rb.AddForce(direction * 9);
    }
}
