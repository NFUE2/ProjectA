using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    Transform weapon;
    GameObject _bullet;
    Transform FirePosition;

    void Start()
    {
        weapon = this.transform.GetChild(0).transform;
        _bullet = this.transform.GetChild(0).GetChild(2).gameObject;
        FirePosition = this.transform.GetChild(0).GetChild(1).transform;
    }

    void Update()
    {
        GunRotate();
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
