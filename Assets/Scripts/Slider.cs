using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{

    public LaserButtonController knob;
    private Vector2 targetPos;
    void Start()
    {
        targetPos = knob.transform.position;
    }

    void Update()
    {
        //knob.position = Vector2.Lerp(knob.position, targetPos,Time.deltaTime*20);
        knob.transform.position = targetPos;
    }

    void OnTouchStay(Vector2 point)
    {
        Vector2 ray = new Vector2(point.x, point.y);
        RaycastHit2D[] hitColliders = Physics2D.RaycastAll(ray, Camera.main.transform.forward);
        
        foreach(RaycastHit2D iter in hitColliders)
        {
            Debug.Log(iter.collider.name);
        }
        
        
        targetPos = new Vector2(point.x, targetPos.y);

    }
}
