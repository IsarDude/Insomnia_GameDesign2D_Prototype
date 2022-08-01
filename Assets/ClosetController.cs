using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosetController : MonoBehaviour
{
    Animator anim;
    private GameObject currentInteractionObject;
    public string levelToLoad;
    public GameObject LevelLoader; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Interact") && currentInteractionObject)
        {
            if (currentInteractionObject.tag == "Player")
            {
                LevelLoader.SendMessage("LoadNextLevel");
                


            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        currentInteractionObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentInteractionObject = null;

        }
    }

    public void Spook()
    {
        anim.SetBool("isSleeping", true);
    }

    public void StopSpook()
    {
        anim.SetBool("isSleeping", false);
    }
}
