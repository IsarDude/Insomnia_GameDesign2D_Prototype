using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lamp : MonoBehaviour
{
    [SerializeField] private Light2D _lampLight;
    [SerializeField] private float _flickeringInterval;
    private bool _isFlickering;

    private void Awake() {
        _isFlickering = false;
    }

    public void TurnOn(){
        _lampLight.intensity = 1;
        FindObjectOfType<AudioManager>().Play("switchOn");
    }

    public void TurnOff(){
        _lampLight.intensity = 0;
        FindObjectOfType<AudioManager>().Play("lightBreak");
        FindObjectOfType<AudioManager>().Play("switchOff");
    }

    public void StartFlickering(){
        if(!_isFlickering){
             _isFlickering = true;
            StartCoroutine(Flickering());
        }
       
        
    }

    public void StopFlickering(){
        _isFlickering = false;
        FindObjectOfType<AudioManager>().Stop("lightFlicker");
    }

    IEnumerator Flickering(){
        Debug.Log("Flickering");
        bool lightOn = true;
        while(_isFlickering){
            if(lightOn){
                TurnOff();
                lightOn = false;
            }else{
                TurnOn();
                lightOn = true;
            }
            FindObjectOfType<AudioManager>().Play("lightFlicker");
            yield return new WaitForSeconds(_flickeringInterval);
        }
        yield return null;
    }
}
