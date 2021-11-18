using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfriendWall : MonoBehaviour
{
    public static int index;
    public static bool gameOverBool;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            if(ThrowBall.isTouched == false)
            {
                index = index + 1;
                BallCatcher.friendIndex = index;
                ThrowBall.ballPickUpIndex = index;
                Debug.Log("Index:" + " " + index);
                gameOverBool = true;
            }
            ThrowBall.isTouched = false;
        }
    }
}
