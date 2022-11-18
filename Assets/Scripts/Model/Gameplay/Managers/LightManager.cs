using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour {
    [SerializeField] private Light2D _playerLight;
    [SerializeField] private Light2D _globalLight;
    [SerializeField] private List<Lamp> _allLamps;
    [SerializeField] private List<Trigger> _allSwitches;
    [SerializeField] private float _flickeringTime;
    [SerializeField] private float _lightTime;
    [SerializeField] private Timer _timer;

    public UnityEvent OnLightsOn;
    public UnityEvent OnLightsOff;
    void Start () {
        _globalLight.intensity = 0;
        _playerLight.intensity = 1;
        _timer.OnTimeOver += HandleTimeOver;
        _timer.OnTimeLeftChanged += HandleTimeChanged;
        foreach (Trigger aTrigger in _allSwitches) {
            aTrigger.OntriggerActivated.AddListener (HandleSwitchOn);
        }
    }
    private void HandleSwitchOn () {
        foreach (Lamp lamp in _allLamps) {
            lamp.TurnOn ();
        }
        _playerLight.intensity = 0;
        _globalLight.intensity = 0.3f;
        _timer.StartTimer (_lightTime);
        OnLightsOn?.Invoke ();
    }

    private void HandleTimeOver () {
        foreach (Lamp lamp in _allLamps) {
            lamp.StopFlickering ();
            lamp.TurnOff ();
        }
        _playerLight.intensity = 1;
        _globalLight.intensity = 0;
        OnLightsOff?.Invoke ();
    }

    private void HandleFlickering () {
        foreach (Lamp lamp in _allLamps) {
            lamp.StartFlickering ();
        }
    }

    private void HandleTimeChanged () {
        if (_timer.TimeLeft < _flickeringTime) {
            HandleFlickering ();
        }
    }
}