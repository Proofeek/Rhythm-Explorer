using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_levels : MonoBehaviour
{
    public GameObject transition;

    public float transitionTime = 1f;

    public void LoadSelectedLevel(int sceneIndex)
    {
        StartCoroutine(LoadLevel(sceneIndex));
    }

    public void RestartLevel()
	{
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
	}

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetActive(true);
        transition.GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
