using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyManager : MonoBehaviour
{
    //거리까지 걸어가고
    //딜레이가 되면 발사
    [SerializeField, Range(0, 50)]
    float _hp;

    [SerializeField, Range(0, 50)]
    float _speed;

    [SerializeField, Range(0, 50)]
    float _playerdistance;

    [SerializeField, Range(0, 50)]
    float _gunRange;

    [SerializeField, Range(0, 50)]
    float _delay;

    Transform _player;

    //bool left;
    //float _handPosition;
    //Transform _hand;
    //Transform _gun;
    //public GameObject _bullet;
    //GameObject _firebullet;

    //float _shootdelay = 0.0f;
    //Animator _ani;
    //Transform _fireposition;
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        //_hand = this.transform.GetChild(0).GetComponent<Transform>(); //Hand
        //_handPosition = _hand.localPosition.x;
        //_gun = this.transform.GetChild(0).GetChild(0).GetChild(0).transform; //Magnum - Gun
        //_ani = this.GetComponent<Animator>();
        //_fireposition = _hand.transform.GetChild(0).GetChild(1).transform;
    }

    void Update()
    {
        Animation();
        //Move();
        //RockOn();
        //Shot();
        //Debug.Log(_fireposition);
        //Debug.Log("포지션" + _fireposition.position);
    }

    //private void Move()
    //{
    //    Vector2 it = new Vector2(5.0f * Mathf.Cos(10.0f),10.0f);
    //    Search();
    //    if (left)
    //    {
    //        _hand.localPosition = new Vector3(-_handPosition, _hand.localPosition.y, _hand.localPosition.z);
    //        _gun.GetComponent<SpriteRenderer>().flipY = true;
    //    }
    //    else if (!left)
    //    {
    //        _hand.localPosition = new Vector3(_handPosition, _hand.localPosition.y, _hand.localPosition.z);
    //        _gun.GetComponent<SpriteRenderer>().flipY = false;
    //    }
    //}

    private void Shot()
    {

    }
    private float Search()
    {
        float dx = _player.position.x - this.transform.position.x;
        float dy = _player.position.y - this.transform.position.y;
        
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;

        return angle;
    }

    private void Animation() //8방향
    {
        if(Search() > -22.5f && Search() < 22.5f)//위
        {
            //_ani.SetInteger("Dix_x", 0);
            //_ani.SetInteger("Dix_y", 1);
            Debug.Log("위");
        }
        //====================================================
        else if (Search() > -67.5f && Search() < -22.5f) //좌상
        {
            //_ani.SetInteger("Dix_x", -1);
            //_ani.SetInteger("Dix_y", 1);
            Debug.Log("좌상");

        }
        else if (Search() > -112.5f && Search() < -67.5f) //좌
        {
            //_ani.SetInteger("Dix_x", -1);
            //_ani.SetInteger("Dix_y", 0);
            Debug.Log("좌");

        }
        else if (Search() > -157.5f && Search() < -112.5f) //좌하
        {
            //_ani.SetInteger("Dix_x", -1);
            //_ani.SetInteger("Dix_y", -1);
            Debug.Log("좌하");

        }
        //====================================================
        else if (Search() > 22.5f && Search() < 67.5f) //우상
        {
            //_ani.SetInteger("Dix_x", 1);
            //_ani.SetInteger("Dix_y", 1);
            Debug.Log("우상");

        }
        else if (Search() > 67.5f && Search() < 112.5f) //우
        {
            //_ani.SetInteger("Dix_x", 1);
            //_ani.SetInteger("Dix_y", 0);
            Debug.Log("우");

        }
        else if (Search() > 112.5f && Search() < 157.5f) //우하
        {
            //_ani.SetInteger("Dix_x", 1);
            //_ani.SetInteger("Dix_y", -1);
            Debug.Log("우하");

        }
        //====================================================
        else if (Search() > 157.5f || Search() < -157.5f) //하
        {
            //_ani.SetInteger("Dix_x", 0);
            //_ani.SetInteger("Dix_y", -1);
            Debug.Log("하");

        }
    }

    private void RockOn()
    {

    }
}
