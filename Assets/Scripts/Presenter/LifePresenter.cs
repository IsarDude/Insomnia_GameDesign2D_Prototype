using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePresenter : MonoBehaviour
{
    [SerializeField] private List<GameObject> _displayedLifes;
    [SerializeField] private Life _lifeModel;
    // Start is called before the first frame update
    void Start()
    {
        _lifeModel.OnDeath.AddListener(HandleLifeChangedEvent);
        DisplayLifes(_lifeModel.Lifes);    
    }

    private void HandleLifeChangedEvent(){
        DisplayLifes(_lifeModel.Lifes);
    }

    private void DisplayLifes(int lifes){
        foreach(GameObject aLife in _displayedLifes){
            if(_displayedLifes.IndexOf(aLife) < lifes){
                aLife.SetActive(true);
                Debug.Log("On");
            }
            else{
                aLife.SetActive(false);
                Debug.Log("Off");
            }
        }
    }
}
