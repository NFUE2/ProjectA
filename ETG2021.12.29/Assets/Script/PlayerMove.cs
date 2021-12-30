using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float _speed = 5.0f;
    Rigidbody _rb;
    bool rolling = false;

    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float h = Input.GetAxis("Horizontal"); //좌우
        float v = Input.GetAxis("Vertical"); //위아래

        Vector3 dir = h * Vector3.right + v * Vector3.up;
        if(dir == Vector3.zero)
        {
            
        }
        
        this.transform.position += dir * _speed * Time.deltaTime;

        if(Input.GetMouseButtonDown(1) && rolling == false && dir !=Vector3.zero)
        {
            rolling = true;
            _rb.AddForce(dir * _speed, ForceMode.Impulse);
        }
        rolling = false;
    }
}
