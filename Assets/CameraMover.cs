using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float targetX;
    // Start is called before the first frame update
    void Start()
    {
      targetX  = Camera.main.transform.position.x;
    }
    //lol noob
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(transform.position.x, targetX, 0.01f);
        transform.position = pos;
    }
}
