using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Animator anim;
    public GameObject Closet;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isInBed") && Input.GetButton("Horizontal"))
        {
            anim.SetBool("isInBed", false);
            Debug.Log("NotSleeping");
            Closet.SendMessage("StopSpook");
        }
    }

   public void Sleep()
    {
        Debug.Log("Sleeping");
        anim.SetBool("isInBed", true);
        Closet.SendMessage("Spook");
    }

}
