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

    NavMeshAgent _agent;

    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Move();

        //if ((Vector3.Distance(_player.position, this.transform.position) > _playerdistance) || Vector3.Distance(_player.position, this.transform.position) > _gunRange)
        //{
        //    Move();
        //}

        //if (Vector3.Distance(_player.position, this.transform.position) <= _gunRange)
        //{
        //    Shot();
        //}

    }

    private void Move()
    {
        Vector3 dir = _player.position;

        Debug.DrawRay(this.transform.position, _player.position, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(this.transform.position,_player.position,out hit, 100.0f))
        {
            Debug.Log(hit.transform.name);
        }

        //플레이어와 적 사이에 방해물이 없을때의 이동
        
        //if()
        //{ 
        //    float distance_x = _player.position.x - this.transform.position.x;
        //    float distance_y = _player.position.y - this.transform.position.y;
        //    if(Mathf.Abs(distance_x) > Mathf.Abs(distance_y)) //짧은거리를 먼저 가게할예정
        //    {
        //        if(distance_y > 0 )
        //        {
        //            dir = Vector3.up;
        //        }
        //        else if(distance_y < 0)
        //        {
        //            dir = Vector3.down;
        //        }
        //    }
        //    else if (distance_x <= distance_y)
        //    {
        //        if(distance_x > 0)
        //        {
        //            dir = Vector3.down;
        //        }
        //        else if(distance_x < 0)
        //        {
        //            dir = Vector3.down;
        //        }
        //    }
        //}

        //this.transform.position += dir * _speed * Time.deltaTime; //
    }

    private void Shot()
    {
        //float _shootdelay = 0.0f;
        //_shootdelay += Time.deltaTime;

        //if(_delay == _shootdelay)
        //{

        //}
    }
}
