using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPresenter : MonoBehaviour
{
   [SerializeField] private Button _startGameButton;

    private MainMenuModel _mainMenu;

    private void Awake() {
        _mainMenu = new MainMenuModel();
        _startGameButton.onClick.AddListener(StartGame);
    }

   private void StartGame(){
        Debug.Log("Clicked");
        _mainMenu.HandleStartGameEvent();
   }
}
