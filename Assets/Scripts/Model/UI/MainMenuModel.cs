using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuModel
{
    public void HandleStartGameEvent(){
        
        AuxiliariyClasses.SceneLoader.LoadSingle(AuxiliariyClasses.GameScenes.Room);
    }
}
