using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuModel : MonoBehaviour
{
    private bool _isActive;
    private bool IsActive{
        get{ return _isActive;}
        set{ 
            _isActive = value;
            OnActiveChanged?.Invoke(value);
        }
    }

    public System.Action<bool> OnActiveChanged;

    private void Awake() {
        IsActive=false;
    }
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            ToggleActive();
        }
    }

    public void ToggleActive(){
        IsActive = !IsActive;
    }

    public void ExitGame(){
        Application.Quit();
    }
}
