using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationController
{
    Animator Anim {get; set;}
    void PlayAnimation(string animationName);
    void StopAnimation(string animationName);
}
