using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTouch : MonoBehaviour
{
    public JoystickPlayerExample joys;
    private float moveSpeed = 250f;
    Rigidbody rigid;
    private int y;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (joys.left)
        {
            y = -1;
            //Vector3 move = new Vector3(y, 0, 3);
            //rigid.velocity = (move * Time.deltaTime * moveSpeed);
        }
        if (joys.mid)
        {
            y = 0;
            //Vector3 move = new Vector3(y, 0, 3);
            //rigid.velocity = (move * Time.deltaTime * moveSpeed);
        }
        if (joys.right)
        {
            y = 1;
            //Vector3 move = new Vector3(y, 0, 3);
            //rigid.velocity = (move * Time.deltaTime * moveSpeed);
        }

      
            Vector3 move = new Vector3(y, 0, 3);
            rigid.velocity = (move * Time.deltaTime * moveSpeed);
        }



    }
}
