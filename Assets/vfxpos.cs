using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Unity.Mathematics;

public class vfxpos : MonoBehaviour
{
	private void Start()
	{
		gameObject.transform.position = transform.parent.position;
	}
	void Update()
    {
        //GetComponent<VisualEffect>().SetVector3("pos", new Vector3(0f,transform.parent.position.y, 0f));
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, transform.parent.position.y, 0f);
	}
}
