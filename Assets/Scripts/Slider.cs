using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{

    public LaserButtonController knob;
    private Vector3 targetPos;
    void Start()
    {
        targetPos = knob.transform.position;

    }

    void Update()
    {
		//knob.position = Vector2.Lerp(knob.position, targetPos,Time.deltaTime*20);

		if (knob.knobPressed) 
        { 
        knob.transform.position = targetPos;
        }
    }

    void OnTouchStay(Vector3 point)
    {
        Vector2 ray = new Vector2(point.x, point.y);
        RaycastHit2D[] hitColliders = Physics2D.RaycastAll(ray, Camera.main.transform.forward);
        
        foreach(RaycastHit2D iter in hitColliders)
        {
            Debug.Log(iter.collider.name);
        }

        if (knob.knobPressed)
        {
            targetPos = new Vector3(point.x, targetPos.y, targetPos.z);
        }

    }
}
