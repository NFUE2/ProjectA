using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiRE : MonoBehaviour
{
    [SerializeField]
    GameObject _gun;

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;
        _gun.transform.position = this.transform.position;
        GunRotate();
    }

    private void GunRotate()
    {
        Vector3 fireposition = _gun.transform.GetChild(1).transform.position;

        float dx = player.position.x - fireposition.x;
        float dy = player.position.y - fireposition.y;

        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;

        _gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
