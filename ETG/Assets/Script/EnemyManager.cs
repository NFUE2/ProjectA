using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float _hp;
    private float _speed;
    private float _playerRange;
    private float _shootRange;
    Transform _player;

    [SerializeField, Range(1.0f, 100.0f)]
    float _sethp;

    [SerializeField, Range(1.0f, 10.0f)]
    float _setspeed; 

    [SerializeField, Range(1.0f, 100.0f)]
    float _setplayerRange;

    [SerializeField, Range(1.0f, 100.0f)]
    float _setshootRange;

    enum EnemyState
    {
        Walk,
        Attack,
        Die
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;

        _hp = _sethp;
        _speed = _setspeed;
        _playerRange = _setplayerRange;
        _shootRange = _setshootRange;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position,_player.position) > _playerRange)
        {
            Moving();
        }
        else
        {
            this.transform.position = Vector3.zero;
        }

        if(Vector3.Distance(this.transform.position, _player.position) < _shootRange)
        {
            Attack();
        }


    }

    private void Moving()
    {
        //Vector3 dir = _speed * Time.deltaTime; 플레이어를 향해서 이동
        //맵 타일을 계산해서 이동
    }

    private void Attack()
    {
        //공격해야함
        //각자 무기가 다름
    }
}
