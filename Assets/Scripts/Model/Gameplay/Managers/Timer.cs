using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    [Header ("Static Data")]

    private float _time;
    private float _timeLeft;

    public float TimeLeft {
        get {
            return _timeLeft;
        }
        private set {
            _timeLeft = value;
            OnTimeLeftChanged?.Invoke ();
        }
    }

    public Action OnTimeOver;
    public Action OnTimeLeftChanged;

    public bool IsTimerRunning { get; private set; }

    private void Update () {
        if (IsTimerRunning) {
            TimeLeft -= Time.deltaTime;

            if (TimeLeft <= 0.0f) {
                TimeLeft = 0.0f;
                TimerEnded ();
            }
        }
    }

    private void TimerEnded () {
        IsTimerRunning = false;
        OnTimeOver?.Invoke ();
        FindObjectOfType<AudioManager> ().Stop ("tickingSound");
    }

    public void StartTimer (float aTime) {
        TimeLeft = aTime;

        IsTimerRunning = true;
        FindObjectOfType<AudioManager> ().Play ("tickingSound");
    }

}