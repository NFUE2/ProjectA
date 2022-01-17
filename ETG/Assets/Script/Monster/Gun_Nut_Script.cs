using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Nut_Script : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet;

    [SerializeField]
    GameObject _V_bullet;

    private float _hp;
    private float _attact_delay; //공격하기 까지 걸린시간
    private float _delay;
    private float _speed;

    Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _attact_delay = 10.0f;
        _delay = 9.9f;
    }

    // Update is called once per frame
    void Update()
    {
        _player = GameObject.Find("Player").transform;
        //Debug.Log(RockOn()); //음수 앞에 - 넣으면 양수로 나옴

        //if (_hp < 0) return;

        ////Move();

        _delay += Time.deltaTime;

        if (_attact_delay < _delay)
        {
            StartCoroutine(attack());
            _delay = 0;
        }
    }

    //private void Move()
    //{
    //    //float distance = Vector3.Distance(_player.transform.position, this.transform.position);
    //    Vector3 dir = _player.position - this.transform.position;

    //    this.transform.Translate(dir * _speed * Time.deltaTime);
    //}

    IEnumerator attack()
    {
        V_Shot(RockOn());

        yield return new WaitForSeconds(0.4f);

        circle_shot();
        V_Shot(RockOn() - 45);
        V_Shot(RockOn() + 45);


        //GameObject V_bullet = Instantiate(_V_bullet);
        //V_bullet.transform.position = this.transform.position;
        //V_bullet.transform.rotation = Quaternion.Euler(0, 0, RockOn());


        //for (int i = 0; i < 45; i++)
        //{
        //    GameObject bullet = Instantiate(_bullet);
        //    bullet.transform.position = this.transform.position;
        //    bullet.transform.rotation = Quaternion.Euler(0, 0, RockOn() + (i * 2) - 45);
        //}

        //for(int i = 0; i< 2; i++)
        //{
        //    GameObject V_bullet2 = Instantiate(_V_bullet);
        //    V_bullet2.transform.position = this.transform.position;
        //    V_bullet2.transform.rotation = Quaternion.Euler(0, 0, RockOn() + (i * 90) - 45);
        //}

    }

    private void V_Shot(float angle)
    {
        GameObject V_bullet = Instantiate(_V_bullet);
        V_bullet.transform.position = this.transform.position;
        V_bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void circle_shot()
    {
        for (int i = 0; i < 45; i++)
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, RockOn() + (i * 2) - 45);
        }
    }

    private float Search()
    {
        float dx = _player.position.x - this.transform.position.x;
        float dy = _player.position.y - this.transform.position.y;

        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;

        return angle;
    }

    private float RockOn()
    {
        float dx = _player.position.x - this.transform.position.x;
        float dy = _player.position.y - this.transform.position.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        return angle;
    }
}
