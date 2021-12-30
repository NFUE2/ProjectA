using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float _speed = 5.0f;
    Animator _ani;
    Rigidbody _rb;

    enum PlayerState
    {
        Idle,
        Walk,
        Rolling,
        Up,
        Down,
        Left,
        Right,
        LeftUp,
        RightUp,
        LeftDown,
        RightDown
    }

    PlayerState state;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        _ani = this.GetComponent<Animator>();
        state = PlayerState.Idle;
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical"); //위아래
        float h = Input.GetAxis("Horizontal"); //좌우

        Vector3 dir = h * Vector3.right + v * Vector3.up;

        if(v > 0) //위로 올라갈때
        {
            if(h == 0)
            {
                state = PlayerState.Up;
            }
            else if (h > 0)
            {
                state = PlayerState.RightUp;
            }
            else if (h < 0)
            {
                state = PlayerState.LeftUp;
            }
        }
        else if(v <0) //아래로 내려갈때
        {
            if (h == 0)
            {
                state = PlayerState.Down;
            }
            else if (h > 0)
            {
                state = PlayerState.RightDown;
            }
            else if (h < 0)
            {
                state = PlayerState.LeftDown;
            }
        }
        else if(v==0)
        {
            if(h > 0)
            {
                state = PlayerState.Right;
            }
            else if (h < 0)
            {
                state = PlayerState.Left;
            }
        }
        
        if(dir == Vector3.zero)
        {
            state = PlayerState.Idle;
        }

        Debug.Log(state);


        this.transform.position += dir * _speed * Time.deltaTime;

        if(Input.GetMouseButtonDown(1))
        {
            _rb.AddForce(dir * _speed, ForceMode.Impulse);

            _rb.velocity = Vector3.zero; //일정 시간 뒤 작동하게 해야할듯
            Debug.Log("구른다");
        }
    }
    
}
