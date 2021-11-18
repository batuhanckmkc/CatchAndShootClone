using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // camera will follow this object
    [SerializeField] Transform[] Target;
    //camera transform
    [SerializeField] Transform camTransform, ball;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    private Vector3 targetPosition;
    public float smoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;
    private Vector3 distancePos;
    private Vector3 distanceRot;
    private void Start()
    {
        distancePos = new Vector3(0, 0, -camTransform.position.z);
        distanceRot = new Vector3(camTransform.rotation.x , 0, 0);
        //- distancePos - distanceRot;
        Offset = camTransform.position - Target[BallCatcher.friendIndex].position;
    }

    private void LateUpdate()
    {
        // update position
        targetPosition = Target[BallCatcher.friendIndex].position + Offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // update rotation
        transform.LookAt(Target[BallCatcher.friendIndex]);
        LookAtBall();
    }

    void LookAtBall()
    {
        if(ThrowBall.isThrowed == true)
        {
            targetPosition = ball.position + Offset;
            //camTransform.position = Vector3.SmoothDamp(transform.position, ball.position, ref velocity, smoothTime);
            camTransform.position = (Vector3.Lerp(transform.position, targetPosition, ThrowBall.ballSpeed));

            // update rotation
            transform.LookAt(ball);
        }
    }
}
