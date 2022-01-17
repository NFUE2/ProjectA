using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Kin : MonoBehaviour
{
    public enum ShotgunKin
    {
        Red,
        Blue
    }

    [SerializeField]
    ShotgunKin Choice;

    [SerializeField]
    GameObject _bullet;

    Transform _player;

    float attackdelay = 10.0f;
    float delay = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        _player = GameObject.Find("Player").transform;
        if(delay > attackdelay)
        {
            if (Choice == ShotgunKin.Red) Red();
            else if (Choice == ShotgunKin.Blue) StartCoroutine(Blue());
            delay = 0;
        }
    }


    private void Red()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, RockOn() + (i * 6) - 12);
        }
    }

    IEnumerator Blue()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, RockOn() + (i * 12) - 24);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, RockOn() + (i * 15.0f) - 22.5f);
        }
    }

    private float RockOn() //vector.right의 각도가 0도  up이 90도 down -90도
    {
        float dx = _player.position.x - this.transform.position.x;
        float dy = _player.position.y - this.transform.position.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        return angle;
    }
}
