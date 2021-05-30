using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_Menu : MonoBehaviour
{
    public GameObject scrollbar;
    private float scroll_pos = 0;
    float[] pos;
    private int OKpos = 0;
    public float switchDistance;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }
    private string swipe;
    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
        if(data.Direction.ToString() == "Left" || data.Direction.ToString() == "Right")
		{
            swipe = data.Direction.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.touchCount > 0 && (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            Debug.Log(scroll_pos);
        }
        else
        {

            if (swipe == "Left")
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    Debug.Log(pos[i]);
                    if (scroll_pos > pos[i] + switchDistance && scroll_pos < pos[i + 1])
                    {
                        scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i + 1], 0.1f);
                    }
                    if ((scroll_pos - pos[i]) > 0 && (scroll_pos - pos[i]) < switchDistance && scroll_pos < pos[i + 1])
                    {
                        scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                    }
                    /*if ((scroll_pos - pos[i]) < 0 && (scroll_pos - pos[i]) > -switchDistance && scroll_pos > pos[i - 1])
                    {
                        scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i + 1], 0.1f);
                    }*/
                }

            }
            if (swipe == "Right")
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    Debug.Log(pos[i]);
                    if (scroll_pos < pos[i] - switchDistance && scroll_pos > pos[i - 1])
                    {
                        scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i - 1], 0.1f);
                    }
                    if ((scroll_pos - pos[i]) < 0 && (scroll_pos - pos[i]) > -switchDistance && scroll_pos > pos[i - 1])
                    {
                        scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                    }
                }

            }

            /*
             for (int i = 0; i < pos.Length; i++)
             {
                 if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                 {
                     Debug.LogWarning("Current Selected Level" + i);
                     transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                     for (int j = 0; j < pos.Length; j++)
                     {
                         if (j != i)
                         {
                             transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                         }
                     }
                 }
             }*/

        }
    }
}