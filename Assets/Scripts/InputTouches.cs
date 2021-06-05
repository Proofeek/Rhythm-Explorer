using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouches : MonoBehaviour
{
    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    private RaycastHit hit;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();
            //Debug.Log("ПЕРВЫЙ IF");

            foreach (Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
                RaycastHit[] colliderHits = Physics.RaycastAll(ray, 10000f);

                if (Physics.Raycast(ray,out hit, touchInputMask))
                {
                    Debug.Log("IF");

                    foreach (RaycastHit iter in colliderHits)
                    {

                        GameObject recipient = iter.transform.gameObject;
                        touchList.Add(recipient);
                        Debug.Log(" fOr");

                        if (touch.phase == TouchPhase.Began)
                        {
                            recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                            //Debug.Log("InputBegan");
                        }
                        if (touch.phase == TouchPhase.Ended)
                        {
                            recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                            //Debug.Log("InputUP");
                        }
                        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                        {
                            recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                            //Debug.Log("InputStay");
                        }
                        if (touch.phase == TouchPhase.Canceled)
                        {
                            recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                            //Debug.Log("InputExit");
                        }
                    }
                }
                foreach (GameObject g in touchesOld)
                {
                    if (!touchList.Contains(g))
                    {
                        g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                        //Debug.Log("InputExit");
                    }
                }
            }
            
        }
    }
}
