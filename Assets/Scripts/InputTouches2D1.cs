using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouches2D1 : MonoBehaviour
{
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    //private RaycastHit hit;
    void Update()
    {

        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();
            //Debug.Log("ПЕРВЫЙ IF");
            Vector3 touchPosWorld;
            foreach (Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);

                touchPosWorld = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                if (Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    //Debug.Log("ВТОРОЙ IF");

                    if (touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", SendMessageOptions.DontRequireReceiver);
                        Debug.Log("InputBegan");
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                        Debug.Log("InputUP");
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                        Debug.Log("InputStay");
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                        Debug.Log("InputExit");
                    }
                }
                foreach (GameObject g in touchesOld)
                {
                    if (!touchList.Contains(g))
                    {
                        g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                        Debug.Log("InputExit2");
                    }
                }
            }
            
        }
    }
}
