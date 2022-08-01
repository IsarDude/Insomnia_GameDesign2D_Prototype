using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncer : MonoBehaviour
{
    public float bounciness; // Determines jump height
    public float maxJumpForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        float jumpForce = -other.relativeVelocity.y;
        if (jumpForce > maxJumpForce)
        {
            jumpForce = maxJumpForce;
        }
        Debug.Log(other.relativeVelocity.y);
        other.rigidbody.AddForce(new Vector2(0f, jumpForce) * bounciness, ForceMode2D.Impulse);
    }
}
