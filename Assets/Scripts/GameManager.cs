using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public BeatScroller theBS;
    public ButtonsScript theButtonScript;
    public bool startPlaying;
    public bool godMode;
    public static GameManager instance;
    
    public List<GameObject> hearts;
    public GameObject HP_heart;
    public GameObject HP_heartsContainer;
    public int scorePerBadNote = 20;
    public int scorePerOkNote = 40;
    public int scorePerGoodNote = 70;
    public int max_HP;
    public float maxDrumMultiplier = 7f;
    public int beatsPerTact;
    public float currentScore;
    public int currentHP;
    public int currentCombo = 0;
    public float currentMultiplier;
    public float CurrentDrumMultiplier = 1f;
    public float[] multiplierThresholds;
    public float[] drumMultiplierPointsForComplitedTact;

    private bool halfHeart = false;
    private int halfHeartInt = 0;
    private int hitDrumCounterLocal = 0;
    private int hitNotesTracker;
    private int thresholdTracker;
    private int drumThresholdTracker;
    private int tactCounterLocal;

    private int totalNotes;
    private int globalBadHits;
    private int globalOKhits;
    private int globalGoodHits;
    private int globalMissedHits;
    private int globalBeatsCounter;

    public GameObject startGameScreen;
    public GameObject resultsScreen;
    public GameObject gameOverScreen;
    public GameObject NickNameWindow;

    public Text badsText, oksText, goodsText, missedText, finalscoreText, allNotesText, hitsNotesText, scoreText, multiText, multiDrumText, DrumComboText, ComboText, NewHighscoreText;

    void Start()
    {
        instance = this;
        currentMultiplier = 1;
        thresholdTracker = 1;
        hitNotesTracker = 0;
        drumThresholdTracker = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;

        currentHP = max_HP;
        addHPhearts(currentHP);

        theButtonScript.gameObject.SetActive(false);
        //PlayerPrefs.DeleteAll();
    }

    void Update()
    {

    }

    public void NoteHit()
    {


        if (thresholdTracker - 1 < multiplierThresholds.Length)
        {
            hitNotesTracker++;

            if (multiplierThresholds[thresholdTracker - 1] <= hitNotesTracker)
            {
                thresholdTracker++;
                hitNotesTracker = 0;
                currentMultiplier = currentMultiplier + 0.4f;
                updateCurrentMultiplier();
            }
        }
        if (currentHP < max_HP)
        {
            currentHP++;
            hearts[currentHP - 1].SetActive(true);
            //---------------------------------
        }
        hearts[0].GetComponentInChildren<SpriteMask>().enabled = false;
        //addHPhearts(1);
        //currentScore += scorePerNote * currentMultiplier;
        //scoreText.text = currentScore.ToString();

        currentCombo++;
        //ComboText.text = currentCombo.ToString();
    }

    public void NoteHitBad()
    {
        currentScore += scorePerBadNote * currentMultiplier * (float)CurrentDrumMultiplier;
        NoteHit();

        globalBadHits++;
        //ComboText.text = "плохо (" + currentCombo.ToString() + ")";
        ComboText.text = "нормально";
    }

    public void NoteHitOK()
    {
        currentScore += scorePerOkNote * currentMultiplier * (float)CurrentDrumMultiplier;
        NoteHit();

        globalOKhits++;
        //ComboText.text = "хорошо (" + currentCombo.ToString() + ")";
        ComboText.text = "хорошо";
    }

    public void NoteHitGood()
    {
        currentScore += scorePerGoodNote * currentMultiplier * (float)CurrentDrumMultiplier;
        NoteHit();

        globalGoodHits++;
        //ComboText.text = "отлично (" + currentCombo.ToString() + ")";
        ComboText.text = "отлично";
    }

    public void LaserHitGetPoints()
    {
        currentScore = currentScore + (2 * (float)CurrentDrumMultiplier);
    }

    public void NoteMissed()
    {

        if(godMode)
        {
            currentHP = max_HP;
        }

        currentCombo = 0;
        ComboText.text = currentCombo.ToString();

        if (currentHP > 0)
        {
            hearts[currentHP - 1].SetActive(false);
            hearts[0].GetComponentInChildren<SpriteMask>().enabled = false;
            halfHeart = false;
            halfHeartInt = 0;
        }
        currentHP = currentHP - 1;

        if (max_HP - currentHP == 1)
        {
            if (currentMultiplier > 2)
            {
                thresholdTracker = 1;
                hitNotesTracker = 0;
                currentMultiplier = currentMultiplier / 2;
                updateCurrentMultiplier();
            }
            else
            {
                thresholdTracker = 1;
                hitNotesTracker = 0;
                currentMultiplier = 1;
                updateCurrentMultiplier();
            }
        }

        if (max_HP - currentHP == 2)
        {
            thresholdTracker = 1;
            hitNotesTracker = 0;
            currentMultiplier = 1;
            updateCurrentMultiplier();
        }

        if (currentHP == 0 && CurrentDrumMultiplier == maxDrumMultiplier && !halfHeart)
        {
            CurrentDrumMultiplier = 1;
            updateCurrentMultiplier();
            hearts[0].SetActive(true);
            hearts[0].GetComponentInChildren<SpriteMask>().enabled = true;
            halfHeart = true;
            halfHeartInt++;
        }

        if ((currentHP <= 0) && halfHeartInt != 1)
        {
                GameOver();
                Debug.Log("Проиграл");
        }

		if (halfHeart)
		{
            halfHeartInt++;
        }

        globalMissedHits++;
        ComboText.text = "мимо";

    }

    public void Finish()
    {
        theButtonScript.gameObject.SetActive(false);
        HP_heartsContainer.SetActive(false);
        missedText.text = globalMissedHits.ToString();
        //allNotesText.text = totalNotes.ToString();
        finalscoreText.text = currentScore.ToString("F0");
        badsText.text = globalBadHits.ToString();
        oksText.text = globalOKhits.ToString();
        goodsText.text = globalGoodHits.ToString();
        //hitsNotesText.text = (globalBadHits + globalGoodHits + globalOKhits).ToString() + " / ";
        allNotesText.text = (globalBadHits + globalGoodHits + globalOKhits).ToString() + " / " + totalNotes.ToString();
        
        theMusic.Stop();
        theBS.gameObject.SetActive(false);
		if (PlayerPrefs.HasKey("NickName"))
		{
            if (currentScore > PlayerPrefs.GetInt("HighScore" + "|" + SceneManager.GetActiveScene().name, 0))
            {
                NewHighscoreText.gameObject.SetActive(true);
                AddHighscore();
            }
            resultsScreen.SetActive(true);
        }
		else
		{
            NickNameWindow.SetActive(true);
        }
    }

    public void AddHighscore()
	{
        PlayerPrefs.SetInt("HighScore" + "|" + SceneManager.GetActiveScene().name, (int)currentScore);
        Highscores.AddNewHighscore(PlayerPrefs.GetString("NickName", "Player") + "|" + SceneManager.GetActiveScene().name, PlayerPrefs.GetInt("HighScore" + "|" + SceneManager.GetActiveScene().name, 0));
    }

    public void GameOver()
    {
        theMusic.Stop();
        gameOverScreen.SetActive(true);
        theBS.gameObject.SetActive(false);
        theButtonScript.gameObject.SetActive(false);
    }

    public void GameStart()
    {
        startPlaying = true;
        theBS.hasStarted = true;
        theButtonScript.gameObject.SetActive(true);
        startGameScreen.SetActive(false);
        theMusic.Play();
    }

    public void addHPhearts(int numberOfHearts)
    {
        for (int i = 0; i < numberOfHearts; i++)
        {
            GameObject HeartClone = Instantiate(HP_heart);
            HeartClone.transform.SetParent(HP_heartsContainer.transform, false);
            HeartClone.name = "Heart_" + (HP_heartsContainer.transform.childCount);
        }
        foreach (Transform child in HP_heartsContainer.transform) hearts.Add(child.gameObject);
    }

    public void updateCurrentMultiplier()
    {
        currentMultiplier = Mathf.Round(currentMultiplier * 10f) / 10f;
        multiText.text = currentMultiplier.ToString() + "x";


        multiDrumText.text = (Mathf.Round(CurrentDrumMultiplier * 10f) /10f).ToString() + "x";
        if (CurrentDrumMultiplier == maxDrumMultiplier)
        {
            multiDrumText.text = multiDrumText.text + "(max)";
        }
    }

    public void theDrum(bool hitDrum, Vector2 point)
    {


        if (hitDrum)
        {
            hitDrumCounterLocal++;
            if (CurrentDrumMultiplier < maxDrumMultiplier)
            {
                DrumComboText.gameObject.transform.position = point;
                //comboText.gameObject.transform.position = Vector3.Lerp(comboText.gameObject.transform.position, point, 0.3f);
                DrumComboText.color = Color.white;
                globalBeatsCounter++;
                DrumComboText.text = globalBeatsCounter.ToString();
            }


            if (hitDrumCounterLocal == beatsPerTact)
            {
                hitDrumCounterLocal = 0;
                DrumComboText.color = new Color32(255, 179, 0, 255);
                tactCounterLocal++;

                if ((tactCounterLocal - 1 < drumMultiplierPointsForComplitedTact.Length) && (CurrentDrumMultiplier < maxDrumMultiplier))
                {
                    CurrentDrumMultiplier = drumMultiplierPointsForComplitedTact[drumThresholdTracker - 1] + CurrentDrumMultiplier;

                    if(CurrentDrumMultiplier > maxDrumMultiplier)
					{
                        CurrentDrumMultiplier = maxDrumMultiplier;
					}

                    drumThresholdTracker++;
                    updateCurrentMultiplier();
                }
            }
        }


        if (globalBeatsCounter == 0 || CurrentDrumMultiplier == maxDrumMultiplier)
        {
            DrumComboText.gameObject.SetActive(false);
        }
        else
        {
            DrumComboText.gameObject.SetActive(true);
        }


        if (CurrentDrumMultiplier < maxDrumMultiplier) 
        { 
            if (!hitDrum)
            {
                hitDrumCounterLocal = 0;
                globalBeatsCounter = 0;
                tactCounterLocal = 0;
                drumThresholdTracker = 1;
                DrumComboText.text = globalBeatsCounter.ToString();
            }
        }
    }
}
