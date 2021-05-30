using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
	public void SaveNickname(string name)
	{
		PlayerPrefs.SetString("NickName", name);
		Debug.Log(PlayerPrefs.GetString("NickName"));
	}
}
