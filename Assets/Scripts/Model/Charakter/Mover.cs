using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent : UnityEvent<bool> {

}
public class Mover : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveInput;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask whatIsGround;

    public BoolEvent OnIsGroundedChanged;
    public BoolEvent OnIsWalkingChanged;

    public UnityEvent OnJump;

    private bool _isGrounded;
    public bool IsGrounded {
        get {
            return _isGrounded;
        }
        private set {
            _isGrounded = value;
            OnIsGroundedChanged?.Invoke (_isGrounded);
        }
    }
    private bool _isWalking;
    public bool IsWalking {
        get {
            return _isWalking;
        }
        private set {
            _isWalking = value;
            OnIsWalkingChanged?.Invoke (_isWalking);
        }
    }

    [SerializeField] private float _maxSpeed;
    public float acceleration;

    private bool _movable;

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
        _movable = true;
        if (OnIsGroundedChanged == null)
            OnIsGroundedChanged = new BoolEvent ();
        if (OnIsWalkingChanged == null)
            OnIsWalkingChanged = new BoolEvent ();
        IsGrounded = false;
    }

    private void Update () {
        if (CheckPlayerGrounded () != IsGrounded) {
            IsGrounded = CheckPlayerGrounded ();
        }
        if (_movable && Input.GetKeyDown (KeyCode.Space) && IsGrounded) {
            Jump ();
        }
        if (_movable && Input.GetButton ("Horizontal")) {
            if (_speed < _maxSpeed) {
                _speed = _speed + acceleration;
                IsWalking = true;
            }
        } else {
            _speed = 0;
            IsWalking = false;
        }

        Move (Input.GetAxis ("Horizontal"), _speed);
    }

    private void Move (float moveInput, float currentSpeed) {
        rb.velocity = new Vector2 (moveInput * currentSpeed, rb.velocity.y);
        if ((moveInput < 0 && this.transform.localScale.x > 0) || (moveInput > 0 && this.transform.localScale.x < 0)) {
            this.transform.localScale = new Vector3 (this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    private void Jump () {
        rb.velocity = Vector2.up * _jumpForce;
        FindObjectOfType<AudioManager> ().Play ("jumpStartSound");
    }

    private bool CheckPlayerGrounded () {
        return Physics2D.OverlapCircle (_feetPosition.position, 1f, whatIsGround);
    }

    public void FreezeMovement () {
        _movable = false;
    }

    public void AllowMovement () {
        _movable = true;
    }

}