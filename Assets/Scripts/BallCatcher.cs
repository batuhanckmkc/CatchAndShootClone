using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour
{
    [SerializeField] Transform[] friend;
    [SerializeField] Transform ball;
    //public Transform player;
    Vector3 distance;
    public static int friendIndex;
    private float distanceFloat;
    private bool targetDetected;
    private Vector3 vecRot;
    // Start is called before the first frame update
    void Start()
    {
        friendIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(distance);
        if (targetDetected == true) //&& ThrowBall.isPickUp == false)
        {
            TargetDetected();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            targetDetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            targetDetected = false;
        }
    }
    void TargetDetected()
    {
        distance = ball.position - friend[friendIndex].position;
        distance = distance.normalized; // The normalized direction in LOCAL space
        transform.Translate(distance.x * Time.deltaTime * 15f, 0, 0);
        //transform.LookAt(ball.position);
    }
}
