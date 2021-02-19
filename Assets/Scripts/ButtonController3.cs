using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController3 : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public bool bDown;

    public bool canTargetDone;
    Collider2D col;


    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTouchDown()
    {
        theSR.sprite = pressedImage;
        bDown = true;
        if (canTargetDone)
        {
            Debug.Log("ПОПАЛ В ЦЕЛЬ");
            
            if((col.transform.position.y > (gameObject.transform.position.y + 12)) || (col.transform.position.y < (gameObject.transform.position.y - 12)))
            {
                GameManager.instance.NoteHitBad();
                Debug.Log("BAD hit");
            }else if((col.transform.position.y > (gameObject.transform.position.y + 6)) || (col.transform.position.y < (gameObject.transform.position.y - 6)))
            {
                GameManager.instance.NoteHitOK();
                Debug.Log("OK hit");
            }
            else
            {
                GameManager.instance.NoteHitGood();
                Debug.Log("Good hit");
            }

            col.gameObject.SetActive(false);
            
        }
        if(!canTargetDone)
        {
            GameManager.instance.NoteMissed();
            Debug.Log("нажал мимо");
        }

    }

    void OnTouchUp()
    {
        theSR.sprite = defaultImage;
        bDown = false;
        
    }

    void OnTouchStay(Vector2 point)
    {
            theSR.sprite = pressedImage;
            bDown = false;

        //Debug.Log("x= " + point.x);
        //Debug.Log("y= " + point.y);
    }

    void OnTouchExit()
    {
        theSR.sprite = defaultImage;
        bDown = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        col = other;
        if (other.tag == "Target")
        {
            canTargetDone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Target")
        {
            if(canTargetDone && !bDown)
            {
                GameManager.instance.NoteMissed();
                Debug.Log("МИМО");
            }
            canTargetDone = false;
        }
    }
}