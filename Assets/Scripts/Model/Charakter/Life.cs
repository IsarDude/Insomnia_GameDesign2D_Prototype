using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField] private int _initialLifes;
    [SerializeField] private int _lifes;
    
    public int Lifes { 
        get{
            return _lifes;
        }
        private set
        {
            _lifes= value;
            OnDeath?.Invoke();
        } 
    }

    public UnityEvent OnLifesZero;
    public UnityEvent OnDeath;

    private void Start() {
        Lifes = _initialLifes;
    }

    public void Die(){
        Lifes--;
        if(Lifes <= 0){
            OnLifesZero?.Invoke();
        }
        this.gameObject.SetActive(false);
        FindObjectOfType<AudioManager> ().Play("deathSound");
    }
    
    public void ResetLifes() {
        Lifes= _initialLifes;
    }
}
