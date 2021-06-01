using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
	public Text NickNameText;

	private void Start()
	{
		if (PlayerPrefs.HasKey("NickName"))
		{
			NickNameText.text = PlayerPrefs.GetString("NickName");
		}
	}
	public void SaveNickname(string name)
	{
		if(name.Length >2)
		{
			PlayerPrefs.SetString("NickName", name);
			Debug.Log(PlayerPrefs.GetString("NickName"));
		}
		
	}
}
