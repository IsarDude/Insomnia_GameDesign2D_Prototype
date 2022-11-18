using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour
{
    public string levelToLoad;
    public GameObject LevelLoader;
    

    public void ReturnToTitleScreen()
    {

        LevelLoader.SendMessage("LoadStartScreen");

    }
}
