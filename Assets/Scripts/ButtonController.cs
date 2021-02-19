using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public int buttonCode;

    public KeyCode keyToPress;


    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    int f1 = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
        Vector3 touchPosWorld;
        int i = 0;
        
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 pos = t.position;

            touchPosWorld = Camera.main.ScreenToWorldPoint(pos);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            
            //BUTTON 1L
            if (t.phase == TouchPhase.Began && hitInformation.collider.gameObject.name == "Button_1L" && buttonCode == 1)
            {
                f1 = t.fingerId;
                theSR.sprite = pressedImage;
                Debug.Log("f1 в if = " + f1.ToString());

            }
            else if (Input.GetTouch(f1).phase == TouchPhase.Ended)
            {
                theSR.sprite = defaultImage;
            }
            
            /*
            //BUTTON 2L
            if (t.phase == TouchPhase.Began && hitInformation.collider.gameObject.name == "Button_2L" && buttonCode == 2)
            {
                f2 = t.fingerId;
                theSR.sprite = pressedImage;
            }
            if (Input.GetTouch(f2).phase == TouchPhase.Ended)
            {
                theSR.sprite = defaultImage;
            }

            
            //BUTTON 3L
            if (t.phase == TouchPhase.Began && hitInformation.collider.gameObject.name == "Button_3L")
            {
                theSR.sprite = pressedImage;
            }
            if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Moved && hitInformation.collider.gameObject.name == "Button_3L")
            {
                theSR.sprite = defaultImage;
            }

            //BUTTON 1R
            if (t.phase == TouchPhase.Began && hitInformation.collider.gameObject.name == "Button_1R")
            {
                theSR.sprite = pressedImage;
            }
            if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Moved && hitInformation.collider.gameObject.name == "Button_1R")
            {
                theSR.sprite = defaultImage;
            }


            //BUTTON 2R
            if (t.phase == TouchPhase.Began && hitInformation.collider.gameObject.name == "Button_2R")
            {
                theSR.sprite = pressedImage;
            }
            if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Moved && hitInformation.collider.gameObject.name == "Button_2R")
            {
                theSR.sprite = defaultImage;
            }


            //BUTTON 3R
            if (t.phase == TouchPhase.Began && hitInformation.collider.gameObject.name == "Button_3R")
            {
                theSR.sprite = pressedImage;
            }
            if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Moved && hitInformation.collider.gameObject.name == "Button_3R")
            {
                theSR.sprite = defaultImage;
            }
            */
            ++i;
        }
    }
}
