using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_King : MonoBehaviour
{
    private float _hp = 750.0f;


    private float attack_delay = 100.0f;

    private float delay = 99.0f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject slowbullet;

    [SerializeField]
    GameObject spinbullet;

    void Start()
    {

    }

    void Update()
    {
        delay += Time.deltaTime;

        if (delay >= attack_delay)
        {
            StartCoroutine(pattern3());
            delay = 0;
        }
    }

    //private void pattern1() //보스로부터 플레이어가 전방 후방을 제외한 위치에 있을때 총알 두번발사
    //{

    //}
    //private void pattern2() //자신을 중심으로 나아가는 불꽃 모양 탄을 원형으로 발사
    //{
       
    //}
    //private void pattern3() //자신을 중심으로 깜빡거린는 총알 4개 발사
    //{
    //    for (int i = 0; i < 60; i++)
    //    {
    //        GameObject _spinbullet = Instantiate(spinbullet);
    //        _spinbullet.transform.position = this.transform.position;
    //        _spinbullet.transform.rotation = Quaternion.Euler(0, 0, i * 6);
    //    }
    //}
    //private void pattern4() //빙글빙글 하면서 발사 끝난뒤 원형으로 발사
    //{
    //    for (int i = 0; i < 7; i++)
    //    {
    //        for (int j = 0; j < 6; j++)
    //        {
    //            GameObject _bullet = Instantiate(bullet);
    //            bullet.transform.position = this.transform.position;
    //            bullet.transform.rotation = Quaternion.Euler(0, 0, j * 60);
    //            StartCoroutine(timedelay(1.0f));
    //        }
    //    }
    //}
    //private void pattern5() //자신위로 커다란 총알 발사후 나뉨
    //{

    //}
    IEnumerator pattern2()
    {
        for (int i = 0; i < 60; i++)
        {
            GameObject _bullet = Instantiate(bullet);
            _bullet.transform.position = this.transform.position;
            _bullet.transform.rotation = Quaternion.Euler(0, 0, i * 6);
        }
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator pattern3()
    {
        for (int i = 0; i < 60; i++)
        {
            GameObject _bullet = Instantiate(spinbullet);
            _bullet.transform.position = this.transform.position;
            _bullet.transform.rotation = Quaternion.Euler(0, 0, i * 6);


        }
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator pattern4()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject _bullet = Instantiate(slowbullet);
                _bullet.transform.position = this.transform.position;
                _bullet.transform.rotation = Quaternion.Euler(0, 0, (j * 60) + (i * 12));
            }
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(pattern2());
    }

    IEnumerator pattern5() //분열마다 원형의 각도가 다름  수정해야할부분
    {
        GameObject _bullet = Instantiate(bullet);

        _bullet.transform.position = this.transform.position;
        _bullet.transform.rotation = Quaternion.Euler(0,0,90);
        Debug.Log(_bullet.tag);

        yield return new WaitForSeconds(0.7f);

        for (int i = 0; i < 8; i++)
        {
            GameObject _bullet2 = Instantiate(_bullet);
            _bullet2.transform.position = _bullet.transform.position;
            _bullet2.transform.rotation = Quaternion.Euler(0, 0, i * 45);
        }
        //Destroy(_bullet);

        yield return new WaitForSeconds(0.7f);

        GameObject[] _bullet3 = GameObject.FindGameObjectsWithTag("Bullet");

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject _bullet2 = Instantiate(_bullet);
                float random_angle = Random.Range(0, 10);
                _bullet2.transform.position = _bullet3[i].transform.position;
                _bullet2.transform.rotation = Quaternion.Euler(0, 0, j * 45 + random_angle);
                //Destroy(_bullet3[i]);
            }
        }
    }

}
