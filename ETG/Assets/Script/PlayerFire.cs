using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerFire : MonoBehaviour
{
    GameObject[] _weapon;
    GameObject _item;

    Image _image;
    void Start()
    {
        
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false; //커서를 안보이게 해줍니다.
        Vector3 dir = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        dir = _image.transform.position;

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 shoot = this.transform.position - dir;
            
        }


    }
}
