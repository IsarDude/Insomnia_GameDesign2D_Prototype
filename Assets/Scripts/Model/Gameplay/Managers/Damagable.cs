using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] private List<string> TagsThatDamage;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(TagsThatDamage.Contains(other.tag)){
            if(GetComponent<Life>()){
                Debug.Log("Damagerecieved");
                GetComponent<Life>().Die();
            }
        }
    }
}

