using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float _speed = 5.0f;
    Animator _ani;
    Rigidbody _rb;
    SpriteRenderer _sr;

    bool Roll;

    float v,h;

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
    }

    PlayerState state;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        _ani = this.GetComponent<Animator>();
        state = PlayerState.Idle;
        _sr = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        //v = Input.GetAxis("Vertical"); //위아래
        //float h = Input.GetAxis("Horizontal"); //좌우

       Vector3 dir = h * Vector3.right + v * Vector3.up;

        if(v > 0) //위로 올라갈때
        {
            if(h == 0)
            {
                state = PlayerState.Up;
                _ani.SetFloat("Direction_X", dir.x);
                _ani.SetFloat("Direction_Y", dir.y);

            }
            else if (h > 0)
            {
                state = PlayerState.RightUp;
                _ani.SetInteger("Direction_X", 0);
                _ani.SetInteger("Direction_Y", 1);
            }
            else if (h < 0)
            {
                state = PlayerState.LeftUp;
                _ani.SetInteger("Direction_X", 1);
                _ani.SetInteger("Direction_Y", -1);
            }
        }
        else if(v <0) //아래로 내려갈때
        {
            if (h == 0)
            {
                state = PlayerState.Down;
                //_ani.SetFloat("Direction_X", -1f);
                _ani.SetFloat("Direction_Y", v);
            }
            else if (h > 0)
            {
                state = PlayerState.Right;
                _ani.SetInteger("Direction_X", 1);
                _ani.SetInteger("Direction_Y", -1);

            }
            else if (h < 0)
            {
                state = PlayerState.Left;
                _ani.SetInteger("Direction_X", -1);
                _ani.SetInteger("Direction_Y", -1);
            }
        }
        
        if(dir == Vector3.zero)
        {
            state = PlayerState.Idle;
        }

        this.transform.position += dir * _speed * Time.deltaTime;

        if(Input.GetMouseButtonDown(1) && Roll == false)
        {
            
            Roll = true;
            dir = Vector3.zero;
            StartCoroutine(Rolling());
        }
    }

    IEnumerator Rolling()
    {
        //if (v > 0 && h > 0)
        //{
        //    dir = Vector3.up + Vector3.right;

        //}
        //else if (v > 0 && h < 0)
        //{
        //    dir = Vector3.up + Vector3.left;

        //}
        //else if (v < 0 && h > 0)
        //{
        //    dir = Vector3.down + Vector3.right;

        //}
        //else if (v < 0 && h < 0)
        //{
        //    dir = Vector3.down + Vector3.left;

        //}
        //else if (v == 0 && h > 0)
        //{
        //    dir = Vector3.right;
        //}
        //else if (v == 0 && h < 0)
        //{
        //    dir = Vector3.left;
        //}
        //else if (v > 0 && h == 0)
        //{
        //    dir = Vector3.up;
        //}
        //else if (v < 0 && h == 0)
        //{
        //    dir = Vector3.down;
        //}
        Vector3 dir = h * Vector3.right + v * Vector3.up;

        _rb.AddForce(dir * _speed, ForceMode.Impulse);

        yield return new WaitForSeconds(0.7f);
        Debug.Log("구른다");
        _rb.AddForce(dir * (_speed * 0.1f), ForceMode.Impulse);

        yield return new WaitForSeconds(0.2f);


        _rb.velocity = Vector3.zero;

        Roll = false;
    }
}
