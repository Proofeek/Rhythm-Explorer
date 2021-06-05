using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public bool knobPressed;

    public LaserButtonColliderScript colliderLaser;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        GetComponent<Animator>().SetTrigger("Laser");
    }

    void Update()
    {/*
        Debug.Log("knobPressed: " + knobPressed);
        if(knobPressed && !colliderLaser.wasOnStartPoint)
        {
            gameObject.SetActive(false);
            Debug.Log("1");
        }
        if(knobPressed && !colliderLaser.touchLaser && colliderLaser.wasOnStartPoint)
        {
            gameObject.SetActive(false);
            Debug.Log("2");
        }

        if (knobPressed && colliderLaser.touchLaser && colliderLaser.wasOnStartPoint)
        {
            GameManager.instance.LaserHitGetPoints();
        }
        */
        if (knobPressed && colliderLaser.touchLaser)
        {
            GameManager.instance.LaserHitGetPoints();
            GetComponent<Animator>().SetBool("ButtonLaser", true);

        }
		else
		{
            GetComponent<Animator>().SetBool("ButtonLaser", false);
        }
    }

    void OnTouchDown()
    {
        
        knobPressed = true;

    }

    void OnTouchUp()
    {
        /*
        if (colliderLaser.wasOnStartPoint)
        {
            gameObject.SetActive(false);
            Debug.Log("3");
        }*/
        knobPressed = false;
       
    }
    
    void OnTouchStay()
    {
        knobPressed = true;
        Debug.Log("OntouchStay");
        //targetPos = new Vector2(point.x, targetPos.y);
        // Debug.Log("x= " + point.x);
        // Debug.Log("y= " + point.y);
    }

    void OnTouchExit()
    {
        knobPressed = false;
        /*
        if (colliderLaser.wasOnStartPoint)
        {
            gameObject.SetActive(false);
            Debug.Log("4");
        }*/

    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="StartLaser")
        {
            wasOnStartPoint = true;
        }
        if (other.tag == "LaserSpot")
        {
            touchLaser = true;
        }
        if (other.tag == "FinishLaser")
        {
            gameObject.SetActive(false);
            touchLaser = false;
            wasOnStartPoint = false;
            knobPressed = false;
            Debug.Log("5");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "LaserSpot")
        {
            touchLaser = false;
        }
        if (other.tag == "StartLaser"&&!knobPressed)
        {
            gameObject.SetActive(false);
            Debug.Log("6");
        }

    }*/
}
