using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] GameObject[] friendParent;
    [SerializeField] Transform[] friend;
    [SerializeField] Transform[] ballPickUp;
    [SerializeField] Transform player, ball;
    public static int ballPickUpIndex = 0;
    public static bool isThrowed, isPickUp, isTouched, isExitFriend , isExitPlayer;
    public static float ballSpeed = 100;
    private Vector3 vecRot;
    Rigidbody ballRb;

    void Start()
    {
        ballPickUpIndex = 0;
        isExitPlayer = false;
        ballRb = GetComponent<Rigidbody>();
        for (int i = 0; i < friend.Length; i++)
        {
            friend[i].GetComponent<MovementScript>().enabled = false;
            friend[i].GetComponent<JoystickPlayerExample>().enabled = false;
            friend[i].GetComponent<EnemyAIManager>().enabled = false;
            Debug.Log(i);
        }

    }
    void Update()
    {
        //Debug.Log(BallCatcher.friendIndex);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Bastýn");
            if (isThrowed == false)
            {
                Debug.Log("Parmaðýný çekti!");

                if(isExitPlayer == false)
                {
                    ballRb.AddForce(player.transform.forward * ballSpeed);
                }
                else
                {
                    ballRb.AddForce(friend[BallCatcher.friendIndex - 1].transform.forward * ballSpeed);
                }
                //transform.parent = ballPickUp[ballPickUpIndex].transform;
                isThrowed = true;
                player.GetComponent<MovementScript>().enabled = false;
                for (int i = 0; i < friend.Length; i++)
                {
                    friend[i].GetComponent<MovementScript>().enabled = false;
                    friend[i].GetComponent<JoystickPlayerExample>().enabled = false;
                    //friend[i].GetComponent<EnemyAIManager>().enabled = false;
                }
            }
        }
        /*if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Ended)
            {
                if (isThrowed == false)
                {
                    Debug.Log("Parmaðýný çekti!");
                    ballRb.AddForce(player.transform.forward * 120);
                    transform.parent = ballPickUp[ballPickUpIndex].transform;
                    isThrowed = true;
                    isPickUp = false;
                }
            }
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            //ball.position = ballPickUp[ballPickUpIndex].position;
            //transform.parent = ballPickUp[ballPickUpIndex];
        }
        if (other.gameObject.tag == "Friend")
        {
            isTouched = true;
            ball.position = ballPickUp[ballPickUpIndex].position;
            transform.parent = ballPickUp[ballPickUpIndex];
            ballPickUpIndex++;
            Debug.Log("Yakaladým!!");
            vecRot = new Vector3(0, 180, 0);
            friend[BallCatcher.friendIndex].Rotate(vecRot);
            friend[BallCatcher.friendIndex].GetComponent<MovementScript>().enabled = true;
            friend[BallCatcher.friendIndex].GetComponent<JoystickPlayerExample>().enabled = true;
            ballRb.constraints = RigidbodyConstraints.FreezePositionZ;
            ballRb.constraints = RigidbodyConstraints.FreezePositionY;
            ballRb.constraints = RigidbodyConstraints.FreezePositionX;

            ballRb.constraints = RigidbodyConstraints.None;
            ballRb.constraints = RigidbodyConstraints.None;
            ballRb.constraints = RigidbodyConstraints.None;
            friend[BallCatcher.friendIndex].GetComponent<EnemyAIManager>().enabled = true;
            BallCatcher.friendIndex++;
            isPickUp = true;
            isThrowed = false;
            isExitFriend = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Friend")
        {
            isExitFriend = true;
        }

        if(other.gameObject.tag == "Player")
        {
            isExitPlayer = true;
            player.GetComponent<JoystickPlayerExample>().enabled = false;
        }
    }
}
