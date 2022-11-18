using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace AuxiliariyClasses {
    //Contains methods to load scenes Single or Additive
    public static class SceneLoader {
        public static void LoadSingle (GameScenes scene) {
            SceneManager.LoadScene (scene.ToString (), LoadSceneMode.Single);
        }

        public static void LoadAdditive (GameScenes scene) {
            SceneManager.LoadScene (scene.ToString (), LoadSceneMode.Additive);
        }
    }

    //Contains all scenes as enums
    public enum GameScenes {
        MainMenu,
        Level_1,
        Room,
        endSequenz
    }
}