using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedAnimationController : MonoBehaviour, IAnimationController
{
 

    public Animator Anim { get; set; }
   
    public void PlayAnimation(string animationName)
    {
         Anim.SetBool(animationName, false);
    }

    public void StopAnimation(string animationName)
    {
         Anim.SetBool(animationName, true);
    }


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        PlayAnimation("isInBed");
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim.GetBool("isInBed") && Input.GetButton("Horizontal"))
        {
            StopAnimation("isInBed");
        }
    }

    

  
}
