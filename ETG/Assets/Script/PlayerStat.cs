using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField,Range(0,6)]
    int health;

    int blank = 2;

    int key = 0;

    int money = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * 10.0f * Time.deltaTime, Space.Self)
    }
}
