using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour, IAnimationController {
    public Animator Anim { get; set; }

    private void Awake() {
        Anim = GetComponent<Animator>();
    }
    public void PlayAnimation (string animationName) {
        
    }

    public void StopAnimation (string animationName) {

    }

    public void HandleAirAnimation(bool isGrounded){
        Debug.Log("Controller" + isGrounded);
        if(isGrounded){
            StopAnimation(PlayerAnimations.isFalling);
        }
        else{
            PlayAnimation(PlayerAnimations.isFalling);
        }
    }

    public void HandleMoveAnimation(bool isWalking){
        if(isWalking){
            PlayAnimation(PlayerAnimations.isWalking);
            FindObjectOfType<AudioManager>().Play("walkingSound");
        }else{
            StopAnimation(PlayerAnimations.isWalking);
            FindObjectOfType<AudioManager>().Stop("walkingSound");
        }
        
    }

    public void PlayIdleAnimation(){
        PlayAnimation(PlayerAnimations.toIdle);
    }


    public void PlayAnimation (PlayerAnimations animation) {
        switch (animation) {
            case PlayerAnimations.isFalling:
                Anim.SetBool (animation.ToString(), true);
                break;
            case PlayerAnimations.isWalking:
                Anim.SetBool(animation.ToString(), true);
                break;
            case PlayerAnimations.toIdle:
                Anim.SetTrigger(animation.ToString());
                break;
            case PlayerAnimations.torchUp:
                Anim.SetBool(animation.ToString(), true);
                break;
            case PlayerAnimations.torchOut:
                 Anim.SetTrigger(animation.ToString());
                break;
            case PlayerAnimations.GetOnKnee:
                Anim.SetTrigger(animation.ToString());
                break;
            case PlayerAnimations.GetUpKnee:
                Anim.SetTrigger(animation.ToString());
                break;
            case PlayerAnimations.StartCrying:
                Anim.SetTrigger(animation.ToString());
                break;
        }
    }

    public void StopAnimation (PlayerAnimations animation) {
        switch (animation) {
            case PlayerAnimations.isFalling:
                Anim.SetBool (animation.ToString(), false);
                break;
            case PlayerAnimations.isWalking:
                Anim.SetBool(animation.ToString(), false);
                break;
            case PlayerAnimations.toIdle:
                break;
            case PlayerAnimations.torchUp:
                Anim.SetBool(animation.ToString(), false);
                break;
            case PlayerAnimations.torchOut:
                break;
            case PlayerAnimations.GetOnKnee:
                break;
            case PlayerAnimations.GetUpKnee:
                break;
            case PlayerAnimations.StartCrying:
                break;
        }
    }

}

public enum PlayerAnimations {

    isFalling,
    isWalking,
    toIdle,
    torchUp,
    torchOut,
    GetOnKnee,
    GetUpKnee,
    StartCrying
}