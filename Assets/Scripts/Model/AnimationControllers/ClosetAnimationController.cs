using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetAnimationController : MonoBehaviour, IAnimationController
{
    public Animator Anim { get; set;}
    [SerializeField] private GameObject _outline;
    public void PlayAnimation(string animationName)
    {
        if(Anim != null)
        Anim.SetBool("isSleeping", true);
    }

    public void StopAnimation(string animationName)
    {
        if(Anim != null)
        Anim.SetBool("isSleeping", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        PlayAnimation("isSleeping");
    }

    public void ShowOutline(){
        Debug.Log("Show Outline:" + _outline);
        _outline.SetActive(true);
    }

    public void HideOutline(){
        Debug.Log("Hide Outline:" + _outline);
        _outline.SetActive(false);
    }

}
