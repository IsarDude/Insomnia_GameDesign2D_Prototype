using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightHandler : MonoBehaviour
{
    public Light2D lampLight;
    public Light2D globalLight;
    public Light2D playerLight;
    private float lightTime = 15f;
    private float blinking = 10f;
    Animator anim;


    private bool isActive = true;

    public Light2D LampLight { get => lampLight; set => lampLight = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && isActive)
        {
            anim.SetBool("isOn",true);
            FindObjectOfType<AudioManager>().Stop("walkingSound");
            FindObjectOfType<AudioManager>().Play("switchOn");
            LampLight.intensity = 1;
            globalLight.intensity = 0.3f;
            playerLight.intensity = 0;
            
            FindObjectOfType<AudioManager>().Play("tickingSound");
          
            collision.GetComponent<PlayerController>().frozen = true;
            collision.GetComponent<PlayerController>().StopAllMovement();
            StartCoroutine(LightTimer(lightTime, collision.GetComponent<PlayerController>()));
            isActive = false;
        }
    }

    IEnumerator LightTimer(float time,PlayerController plc) 
    {
        bool toggle = true;
       for (float i=0f; i<time; i++)
        {
            Debug.Log(i);
            if((i > blinking))
            {
                if(!FindObjectOfType<AudioManager>().isPlaying("lightFlicker"))
                {
                    FindObjectOfType<AudioManager>().Play("lightFlicker");
                }
                if (toggle)
                {
                    LampLight.intensity = 0;
                    toggle = !toggle;
                }else
                {
                    LampLight.intensity = 1;
                    toggle = !toggle;
                }
                
            } 
           

            yield return new WaitForSeconds(0.5f);
        }
        FindObjectOfType<AudioManager>().Stop("lightFlicker");
        FindObjectOfType<AudioManager>().Stop("tickingSound");
        FindObjectOfType<AudioManager>().Play("lightBreak");
        anim.SetBool("isOn", false);
        FindObjectOfType<AudioManager>().Play("switchOff");
        globalLight.intensity = 0;
        playerLight.intensity = 1;
        LampLight.intensity = 0;
        plc.frozen = false;
        
    }

}
