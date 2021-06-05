using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayHighscores : MonoBehaviour
{
	public GameObject content;
	public Text[] highscoreFields;
	private GameObject[] m_gameObjects;
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
				if (SceneManager.GetActiveScene().buildIndex > 0)
				{
					if (highscoreList[i].username == PlayerPrefs.GetString("NickName", "Player"))
					{
						highscoreFields[i].color = Color.red;
					}
				}
			}
		}
	}
	bool gov = true;
	public void OnHighscoresDownloadedMainMenu(Highscore[] highscoresListMain)
	{

		for (int i = 0; i < content.transform.childCount; i++)
		{

			for (int j = 0; j < highscoresListMain.Length; j++)
			{

				if (j < content.transform.GetChild(i).transform.Find("Scores").transform.childCount)
				{
					m_gameObjects = new GameObject[content.transform.GetChild(i).transform.Find("Scores").transform.childCount];
					m_gameObjects[j] = content.transform.GetChild(i).transform.Find("Scores").transform.GetChild(j).gameObject;
					highscoreFields[j] = m_gameObjects[j].GetComponent<Text>();
					highscoreFields[j].text = "";
				}


				string[] entryInfo = highscoresListMain[j].username.Split(new char[] { '|' });
				string username = entryInfo[0];
				string levelName = entryInfo[1];

				if (levelName == content.transform.GetChild(i).name)
				{
					gov = true;
					for (int k = 0; k < content.transform.GetChild(i).transform.Find("Scores").transform.childCount; k++)
					{
						if (content.transform.GetChild(i).transform.Find("Scores").transform.GetChild(k).GetComponent<Text>().text == "" &&gov)
						{
							highscoreFields[k].gameObject.SetActive(true);
							if (highscoresListMain[k].score == 0)
							{
								highscoreFields[k].gameObject.SetActive(false);
							}
							highscoreFields[k].text =(k+1)+". "+ username + " - " + highscoresListMain[j].score;
							gov = false;
						}
					}
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