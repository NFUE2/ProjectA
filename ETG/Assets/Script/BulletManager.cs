using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public enum Bullettype
    {
        normal,
        spin
    }

    public Bullettype _type;

    [SerializeField, Range(0, 50)]
    float _speed;

    [SerializeField, Range(0, 100000.0f)]
    float spin;

    bool spintime = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_type == Bullettype.normal) this.transform.Translate(Vector3.right * _speed * Time.deltaTime);

        else if(_type == Bullettype.spin)
        {
            Vector3 dir = Vector3.right + (Vector3.up * Time.deltaTime * spin);
            this.transform.Translate(dir* _speed * Time.deltaTime);
        }
    }
}
