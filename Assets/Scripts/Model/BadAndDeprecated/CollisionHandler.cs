using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CollisionHandler : MonoBehaviour
{
    public float tweak = 0;
    private bool aktive = true;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Player") && aktive)
            {
                Vector3 camPos = Camera.main.transform.position;
                Camera.main.GetComponent<CameraMover>().targetX = camPos.x + ((transform.position.x - camPos.x) * 2)-tweak;
                aktive = false;
            }
          
        }
    }

}
