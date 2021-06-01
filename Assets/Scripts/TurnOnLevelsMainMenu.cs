using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLevelsMainMenu : MonoBehaviour
{
    public float seconds = 0.4f;
    void Start()
    {
        StartLevel();
    }

    int k = 0;
    void StartLevel()
    {
        if (k < transform.childCount)
        {
            StartCoroutine(LoadLevel1(k));
            k++;
        }
    }

    IEnumerator LoadLevel1(int levelIndex)
    {
        transform.GetChild(levelIndex).gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        StartLevel();
    }
}
