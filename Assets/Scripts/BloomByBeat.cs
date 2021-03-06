using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomByBeat : MonoBehaviour
{
    public BeatScroller theBS;
	UnityEngine.Rendering.Universal.Bloom bloom;

	void Start()
    {
		UnityEngine.Rendering.VolumeProfile volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;
		if (!volumeProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
		
		if (!volumeProfile.TryGet(out bloom)) throw new System.NullReferenceException(nameof(bloom));

		
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		if (theBS.beat16)
		{
			bloom.intensity.Override(10.5f);
		}
		else
		{
			bloom.intensity.Override(1.5f);
		}
	}
}
