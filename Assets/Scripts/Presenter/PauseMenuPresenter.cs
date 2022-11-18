using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuPresenter : MonoBehaviour
{
    [SerializeField] private PauseMenuModel _pauseMenu;
    [SerializeField] private  Button _continueBtn;
    [SerializeField] private Button _escBtn;
    [SerializeField] private Canvas _pauseCanvas;

    private void Awake() {
        _continueBtn.onClick.AddListener(OnContinue);
        _escBtn.onClick.AddListener(OnExitgame);
        _pauseCanvas.gameObject.SetActive(false);
        _pauseMenu.OnActiveChanged += OnActiveChange;
    }

    private void OnActiveChange(bool isActive){
        Debug.Log(isActive);
        _pauseCanvas.gameObject.SetActive(isActive);
    }

    private void OnContinue(){
        _pauseMenu.ToggleActive();
    }


    private void OnExitgame(){
        _pauseMenu.ExitGame();
    }

}
