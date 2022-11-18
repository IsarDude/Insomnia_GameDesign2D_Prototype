using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Checkpoint _currentCheckpoint;
    [SerializeField] private GameObject _player;
    [SerializeField] private LightManager _lightManager;
    [SerializeField] private Trigger EndOfGameTrigger;
    private void Start() {
        EndOfGameTrigger.OntriggerActivated.AddListener(HanldeVictoryEvent);
        _player.GetComponent<Life>().OnDeath.AddListener(HandlePlayerDeathEvent);
        _player.GetComponent<Life>().OnLifesZero.AddListener(HandleGameOverEvent);
        
        FindObjectOfType<AudioManager> ().music("backgroundMusic");
    }
    private void OnEnable() {
        RegisterAllCheckPoints();
        _lightManager.OnLightsOff.AddListener(HandleLightsOffEvent);
        _lightManager.OnLightsOn.AddListener(HandleLightsOnEvent);  
    }

    private void RegisterAllCheckPoints(){
        Checkpoint[] AllCheckpoints = FindObjectsOfType<Checkpoint>();
        foreach(Checkpoint point in AllCheckpoints){
            point.OnCheckpointReached.AddListener(this.SetCurrentCheckpoint);
        }
    }

    private void SetCurrentCheckpoint(Checkpoint checkpoint){
        Debug.Log("SettingCheckpoint");
        _currentCheckpoint = checkpoint;
    } 

    private void HandlePlayerDeathEvent(){
        _currentCheckpoint.ReswpawnObject(_player.GetComponent<Life>().gameObject);
    }

    private void HandleGameOverEvent(){
        AuxiliariyClasses.SceneLoader.LoadSingle(AuxiliariyClasses.GameScenes.Room);
    }

    private void HanldeVictoryEvent(){
        AuxiliariyClasses.SceneLoader.LoadSingle(AuxiliariyClasses.GameScenes.endSequenz);
    }

    private void HandleLightsOnEvent(){
        _player.GetComponent<Mover>().FreezeMovement();
    }
    private void HandleLightsOffEvent(){
        _player.GetComponent<Mover>().AllowMovement();
    }
}
