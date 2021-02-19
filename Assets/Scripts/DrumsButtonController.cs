using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrumsButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public bool bDown;
    public DrumsColliderScript theDCS;
    public GameObject light1;
    public GameObject light2;


    void Start()
    {   
        //theSR = GetComponent<SpriteRenderer>();
    }

    void OnTouchDown(Vector2 point)
    {
        //theSR.sprite = pressedImage;
        bDown = true;
        if (theDCS.canDrumDone)
        {
            Debug.Log("ПОПАЛ В DRUM");
            GameManager.instance.theDrum(true,point);
            theDCS.col.gameObject.SetActive(false);

            light1.gameObject.transform.position = point;
            light1.GetComponent<Animator>().SetTrigger("ButtonPressed");
        }
        else
        {
            Debug.Log("мимо DRUM");
            GameManager.instance.theDrum(false, point);

            light2.gameObject.transform.position = point;
            light2.GetComponent<Animator>().SetTrigger("ButtonPressed");
        }
    }

    void OnTouchUp()
    {
        //theSR.sprite = defaultImage;
        bDown = false;

        light1.GetComponent<Animator>().SetTrigger("ButtonUp");
        light2.GetComponent<Animator>().SetTrigger("ButtonUp");
    }

    void OnTouchStay()
    {
        //theSR.sprite = pressedImage;
        bDown = false;
    }

    void OnTouchExit()
    {
        //theSR.sprite = defaultImage;
        bDown = false;

        light1.GetComponent<Animator>().SetTrigger("ButtonUp");
        light2.GetComponent<Animator>().SetTrigger("ButtonUp");
    }
}
