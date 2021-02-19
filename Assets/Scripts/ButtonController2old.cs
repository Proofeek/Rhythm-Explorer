using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController2old : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public bool bDown;
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
    }

    void OnTouchUp()
    {
        theSR.sprite = defaultImage;
        bDown = false;
    }

    void OnTouchStay()
    {
        theSR.sprite = pressedImage;
        bDown = false;
    }

    void OnTouchExit()
    {
        theSR.sprite = defaultImage;
        bDown = false;
    }
}
