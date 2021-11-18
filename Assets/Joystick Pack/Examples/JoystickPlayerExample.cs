using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public bool left, mid, right;
    public float speed = 1f;
    public Joystick joystick;
    public float rotateHorizontal = 1;
    public void FixedUpdate()
    {
        rotateHorizontal = joystick.Horizontal * speed;
        transform.Rotate(0, rotateHorizontal, 0);
    }
    void Update()
    {
        if (joystick.Horizontal < -1)
        {
            left = true;
            mid = false;
            right = false;
        }

        if (joystick.Horizontal == 0)
        {

            left = false;
            mid = true;
            right = false;

        }

        if (joystick.Horizontal > 1)
        {
            left = false;
            mid = false;
            right = true;
        }
    }
}