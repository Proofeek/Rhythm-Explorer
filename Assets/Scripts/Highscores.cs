using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Highscores : MonoBehaviour
{
	public GameObject levelName;
	const string privateCode = "UyEqiqStpUqH1YX6y1ZQAAZwvx3bRYRE-h9nhpDSD7Uw";
	const string publicCode = "60af66028f40bb64ec9cd54d";
	const string webURL = "http://dreamlo.com/lb/";

	DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;
	public Highscore[] highscoresListMain;
	static Highscores instance;

	void Awake()
	{
		highscoreDisplay = GetComponent<DisplayHighscores>();
		instance = this;
	}
	private void Start()
	{

		//print(levelName.name);
		DownloadHighscoresMainMenu();
	}

	public static void AddNewHighscore(string username, int score)
	{
		instance.StartCoroutine(instance.UploadNewHighscore(username, score));
	}

	IEnumerator UploadNewHighscore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			print("Upload Successful");
			DownloadHighscores();
		}
		else
		{
			print("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores()
	{
			StartCoroutine("DownloadHighscoresFromDatabase");	
	}
	public void DownloadHighscoresMainMenu()
	{
		instance.StartCoroutine("DownloadHighscoresFromDatabaseMainMenu");
	}

	IEnumerator DownloadHighscoresFromDatabaseMainMenu()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			FormatHighscoresMainMenu(www.text);
			highscoreDisplay.OnHighscoresDownloadedMainMenu(highscoresListMain);
		}
		else
		{
			print("Error Downloading: " + www.error);
		}
	}
	IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			FormatHighscores(www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else
		{
			print("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];
		int j = 0;
		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			string levelName = entryInfo[1];
			int score = int.Parse(entryInfo[2]);
			//print("ТО самое|"+username + levelName + score);
			if (levelName == SceneManager.GetActiveScene().name)
			{
				highscoresList[j] = new Highscore(username, score);
				print("j="+j+highscoresList[j].username + ": " + highscoresList[j].score);
				j++;
			}
		}
	}

	void FormatHighscoresMainMenu(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

		highscoresListMain = new Highscore[entries.Length];
		for (int k = 0; k < entries.Length; k++)
		{
			string[] entryInfo = entries[k].Split(new char[] { '|' });
			string username = entryInfo[0];
			string levelName = entryInfo[1];
			string usernameAndLevel = username + "|" + levelName;
			int score = int.Parse(entryInfo[2]);
			highscoresListMain[k] = new Highscore(usernameAndLevel, score);
		}
	}


}

public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}

}