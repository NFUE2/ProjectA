using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    Transform weapon;
    GameObject bullet;
    GameObject _bullet;
    Transform FirePosition;
    bool _fire;
    Vector3 _target;
    GunManager GM;

    void Start()
    {
        _fire = false;
        weapon = this.transform.GetChild(0).transform;
        bullet = this.transform.GetChild(0).GetChild(2).gameObject;
        FirePosition = this.transform.GetChild(0).GetChild(1).transform;
        GM = this.GetComponentInChildren<GunManager>();
    }

    void Update()
    {
        GunRotate();

        if(Input.GetMouseButtonDown(0))
        {
            _bullet = Instantiate(bullet);
            _bullet.transform.position = FirePosition.transform.position;
            _bullet.SetActive(true);
            _fire = true;
        }

        if (_fire == true)
        {
            _bullet.transform.position += _target * 5.0f * Time.deltaTime; 
        }
    }

    private void GunRotate() //총 회전
    {
        Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = weapon.transform.position.z;
        Vector3 dir = Target - weapon.transform.position;
        float angle = Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward); //각도,축
    }
}
