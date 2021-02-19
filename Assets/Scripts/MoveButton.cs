using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        
    }

    private bool isStartMoving = false;

    void Update()
    {
        if (isStartMoving)
        {
            transform.position -= new Vector3(moveSpeed, 0f, 0f);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MovPosStart")
        {
            isStartMoving = true;
        }
        //other.gameObject.transform.position()
        if (other.tag == "MovPosFinish")
        {
            isStartMoving = false;
        }

    }
}
