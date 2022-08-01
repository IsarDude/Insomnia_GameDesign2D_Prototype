using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel("Level_1"));
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void LoadEndLevel()
    {
        
        StartCoroutine(LoadEndTransition("endSequenz"));
    }


    IEnumerator LoadEndTransition(string levelName)
    {
        transition.SetTrigger("startEndTransition");
        Debug.Log("end");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("startTransition");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);
    }
}
