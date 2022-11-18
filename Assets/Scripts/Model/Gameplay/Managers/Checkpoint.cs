using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointEvent : UnityEvent<Checkpoint>{

}
public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float _respawnTime;
    public CheckpointEvent OnCheckpointReached = new CheckpointEvent();

    public UnityEvent OnRespawn;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Chekpoint reached");
            OnCheckpointReached?.Invoke(this);
        }
    }

    public void ReswpawnObject(GameObject objectToSpawn){
        StartCoroutine(RespawnCoroutine(objectToSpawn));
    }

    public IEnumerator RespawnCoroutine(GameObject objectToSpawn)
    {
            objectToSpawn.transform.position = this.transform.position;
        yield return new WaitForSeconds(_respawnTime);    
        objectToSpawn.SetActive(true);
        OnRespawn?.Invoke();
    }
}
