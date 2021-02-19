using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButtonColliderScript : MonoBehaviour
{

    public LaserButtonController theLBS;

    public bool touchLaser;
    public bool wasOnStartPoint;

    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "StartLaser")
        {
            wasOnStartPoint = true;
        }
        if (other.tag == "LaserSpot")
        {
            touchLaser = true;
        }
        if (other.tag == "FinishLaser")
        {
            theLBS.gameObject.SetActive(false);
            touchLaser = false;
            wasOnStartPoint = false;
            theLBS.knobPressed = false;
            Debug.Log("5");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "LaserSpot")
        {
            touchLaser = false;
        }
        if (other.tag == "StartLaser" && !theLBS.knobPressed)
        {
            theLBS.gameObject.SetActive(false);
            Debug.Log("6");
        }

    }
}
