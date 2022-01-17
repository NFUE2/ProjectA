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
    bool Battle = false;
    float v,h;
    Vector3 dir;
    GameObject hand;

    enum PlayerState
    {
        Battle_Idle,
        Battle_Run,
        Idle,
        Run,
        Rolling,
    }

    PlayerState state;
    void Start()
    {
        //state = PlayerState.Idle;
        state = PlayerState.Idle;
        hand = this.transform.GetChild(1).gameObject;
        _rb = this.GetComponent<Rigidbody>();
        _ani = this.GetComponent<Animator>();
        _sr = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Battle = true;

        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        dir = h * Vector3.right + v * Vector3.up;

        if (dir != Vector3.zero && Roll == false)
        {
            _ani.SetBool("Run", true);
        }
        else if(dir == Vector3.zero)
        {
            _ani.SetBool("Run", false);
        }

        if (Battle)
        {
            _ani.SetBool("Battle", true);
            if(dir == Vector3.zero) state = PlayerState.Battle_Idle;
            BattleMove();
        }
        else
        {
            state = PlayerState.Idle;
            if (dir == Vector3.zero) state = PlayerState.Idle;
            RunMove();
        }

        if(Input.GetMouseButtonDown(1) && Roll == false) 
        {
            v = 0;
            h = 0;
            state = PlayerState.Rolling;
            Roll = true;
            _ani.SetTrigger("Rolling");
            StartCoroutine(Rolling());
        }
        this.transform.position += dir * _speed * Time.deltaTime;
    }

    IEnumerator Rolling()
    {
        _ani.SetBool("Rolling", true);
        yield return new WaitForSeconds(1.0f); //구른거 1초정도임
        dir = Vector3.zero;
        Roll = false;
        _ani.SetBool("Rolling", false);
    }

    private float MousePosition() //마우스와 캐릭터의 위치를 알아내서 각도를 계산 -180 ~ 180
    {
        Vector3 MousePosition = Input.mousePosition;
        Vector3 PlayerPosition = this.transform.position;

        MousePosition.z = PlayerPosition.z - Camera.main.transform.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(MousePosition);

        float dy = target.y - PlayerPosition.y;
        float dx = target.x - PlayerPosition.x;

        float rotateDegree = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;

        return rotateDegree;
    }

    private void RunMove()
    {
        if (v > 0) //위로 올라갈때
        {
            if (h == 0)
            {
                _ani.SetInteger("Dir_X", 0);
                _ani.SetInteger("Dir_Y", 1);
                _sr.flipX = false;
            }
            else if (h > 0)
            {
                _ani.SetInteger("Dir_X", 1);
                _ani.SetInteger("Dir_Y", 1);
                _sr.flipX = false;
            }
            else if (h < 0)
            {
                _ani.SetInteger("Dir_X", -1);
                _ani.SetInteger("Dir_Y", 1);
                _sr.flipX = true;
            }
        }
        else if (v < 0) //아래로 내려갈때
        {
            if (h == 0)
            {
                _ani.SetInteger("Dir_X", 0);
                _ani.SetInteger("Dir_Y", -1);
                _sr.flipX = false;
            }
            else if (h > 0)
            {
                _ani.SetInteger("Dir_X", 1);
                _ani.SetInteger("Dir_Y", -1);
                _sr.flipX = false;
            }
            else if (h < 0)
            {
                _ani.SetInteger("Dir_X", -1);
                _ani.SetInteger("Dir_Y", -1);
                _sr.flipX = true;
            }
        }
        else if (v == 0)
        {
            _ani.SetBool("Run", true);

            if (h > 0)
            {
                _ani.SetInteger("Dir_X", 1);
                _ani.SetInteger("Dir_Y", 0);
                _sr.flipX = false;

            }
            else if (h < 0)
            {
                _ani.SetInteger("Dir_X", -1);
                _ani.SetInteger("Dir_Y", 0);
                _sr.flipX = true;
            }
        }
    }

    private void BattleMove()
    {
        GameObject _hand = this.transform.GetChild(1).gameObject;
        hand.SetActive(true);
        if (MousePosition() > -22.5f || MousePosition() < -157.5f)
        {
            _sr.flipX = false;
            if (MousePosition() > -22.5f && MousePosition() < 22.5f) //위
            {
                _ani.SetInteger("Dir_X", 0);
                _ani.SetInteger("Dir_Y", 1);
            }
            else if (MousePosition() > 157.5f || MousePosition() < -157.5f) //아래
            {
                _ani.SetInteger("Dir_X", 0);
                _ani.SetInteger("Dir_Y", -1);
            }

            else if (MousePosition() > 22.5f && MousePosition() < 67.5f) //우상
            {
                _ani.SetInteger("Dir_X", 1);
                _ani.SetInteger("Dir_Y", 1);
            }
            else if (MousePosition() > 67.5f && MousePosition() < 157.5) //우,우하
            {
                _ani.SetInteger("Dir_X", 1);
                _ani.SetInteger("Dir_Y", 0);
            }
        }

        else
        {
            _sr.flipX = true;
            if (MousePosition() < -22.5f && MousePosition() > -67.5f) //좌상
            {
                _ani.SetInteger("Dir_X", -1);
                _ani.SetInteger("Dir_Y", 1);
            }
            else if (MousePosition() < -67.5f || MousePosition() > -157.5) //좌,좌하
            {
                _ani.SetInteger("Dir_X", -1);
                _ani.SetInteger("Dir_Y", -1);
            }
        }

        GameObject _handle = hand.transform.GetChild(0).gameObject;
        if (_handle.transform.position.x > 0 && (MousePosition() < -15.0f && MousePosition() > -165.0f))
        {
            _hand.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        else if (_handle.transform.position.x < 0 && (MousePosition() > 15.0f && MousePosition() < 165.0f))
        {
            _hand.transform.rotation = Quaternion.AngleAxis(180, Vector3.down);
        }
        //Debug.Log(MousePosition());
    }
}
