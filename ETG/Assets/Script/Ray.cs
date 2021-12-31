using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    Ray _ray;
    public GameObject _player;
    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(_player.transform.position,Camera.main.ScreenToViewportPoint(Input.mousePosition),Color.red);
    }
}
