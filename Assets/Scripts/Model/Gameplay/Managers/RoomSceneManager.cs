using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextScene(){
        AuxiliariyClasses.SceneLoader.LoadSingle(AuxiliariyClasses.GameScenes.Level_1);
    }
}
