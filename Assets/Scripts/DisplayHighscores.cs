using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{

	public Text[] highscoreFields;
	Highscores highscoresManager;

	void Start()
	{
		/*
		for (int i = 0; i < highscoreFields.Length; i++)
		{
			highscoreFields[i].text = i + 1 + ". Fetching...";
		}


		highscoresManager = GetComponent<Highscores>();
		StartCoroutine("RefreshHighscores");*/
		for (int i = 0; i < highscoreFields.Length; i++)
		{
			highscoreFields[i].gameObject.SetActive(false);
		}
	}
	
	public void OnHighscoresDownloaded(Highscore[] highscoreList)
	{
		for (int i = 0; i < highscoreFields.Length; i++)
		{
			highscoreFields[i].text = i + 1 + ". ";
			if (i < highscoreList.Length)
			{
				
				highscoreFields[i].gameObject.SetActive(true);
				if (highscoreList[i].score == 0)
				{
					highscoreFields[i].gameObject.SetActive(false);
				}
				highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
				if(highscoreList[i].username == PlayerPrefs.GetString("NickName", "Player"))
				{
					highscoreFields[i].color = Color.red;
				}
			}
		}
	}

	IEnumerator RefreshHighscores()
	{
		while (true)
		{
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}
}