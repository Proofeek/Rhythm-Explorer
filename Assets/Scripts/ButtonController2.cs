using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController2 : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public bool bDown;
    public GameObject light1;


    //public bool canTargetDone;
    //Collider2D col;

    public ButtonColliderScript buttonCollider;


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
        //theSR.sprite = pressedImage;
        bDown = true;
        if (buttonCollider.canTargetDone)
        {
            Debug.Log("ПОПАЛ В ЦЕЛЬ");

            buttonCollider.col.SendMessage("StartAnimDisappear");
            
            if((buttonCollider.col.transform.position.y > (gameObject.transform.position.y + 0.45)) || (buttonCollider.col.transform.position.y < (gameObject.transform.position.y - 0.45)))
            {
                GameManager.instance.NoteHitBad();
                Debug.Log("BAD hit");
            }else if((buttonCollider.col.transform.position.y > (gameObject.transform.position.y + 0.25)) || (buttonCollider.col.transform.position.y < (gameObject.transform.position.y - 0.25)))
            {
                GameManager.instance.NoteHitOK();
                Debug.Log("OK hit");
            }
            else
            {
                GameManager.instance.NoteHitGood();
                Debug.Log("Good hit");
            }

            //buttonCollider.col.gameObject.SetActive(false);
            
        }
        else
        {
            GameManager.instance.NoteMissed();
            Debug.Log("нажал мимо");
        }

        //light1.gameObject.SetActive(true);
        GetComponent<Animator>().SetBool("ButtonPressed", true);

    }

    void OnTouchUp()
    {
        //theSR.sprite = defaultImage;
        bDown = false;
        //light1.gameObject.SetActive(false);
        GetComponent<Animator>().SetBool("ButtonPressed", false);
    }

    void OnTouchStay(Vector2 point)
    {
            //theSR.sprite = pressedImage;
            bDown = false;
        //light1.gameObject.SetActive(true);
        //Debug.Log("x= " + point.x);
        //Debug.Log("y= " + point.y);
    }

    void OnTouchExit()
    {
        //theSR.sprite = defaultImage;
        bDown = false;
        //light1.gameObject.SetActive(false);
        GetComponent<Animator>().SetBool("ButtonPressed", false);
    }
    /*
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
    }*/
}