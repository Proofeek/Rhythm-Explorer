using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomByBeat : MonoBehaviour
{
    public BeatScroller theBS;
	UnityEngine.Rendering.Universal.Bloom bloom;

	private float t;
	bool halfBeat;
	bool KOK;

	void Start()
    {
		UnityEngine.Rendering.VolumeProfile volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;
		if (!volumeProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
		
		if (!volumeProfile.TryGet(out bloom)) throw new System.NullReferenceException(nameof(bloom));

		
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		t += Time.deltaTime;
		if (theBS.beat16|| KOK)
		{
			KOK= true;
			bloom.intensity.Override(Mathf.Lerp(2.5f,10.5f,t/0.3f));
		}
	}
}
