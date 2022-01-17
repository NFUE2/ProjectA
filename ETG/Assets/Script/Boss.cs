using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float _hp = 750.0f;

    private float _speed = 5.0f;

    private float attack_delay = 3.0f;

    private float delay = 0.0f;

    
    public GameObject bullet;

    void Start()
    {
        
    }

    void Update()
    {
        delay += Time.deltaTime;
        
        if(delay >= attack_delay)
        {
            int choice = Random.Range(0, 5);

            if(choice == 1)
            {

            }
        }
    }

    private void pattern1()
    {

    }
}
