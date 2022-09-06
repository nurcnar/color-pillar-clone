using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public float coolDown;
    public bool isClickable;
    void Start()
    {

    }
    
  
    
    void Update()
    {
        if(coolDown<2)
        {
            coolDown += Time.deltaTime;
        }
        else
        {
            isClickable = true;
        }
        if (Input.GetMouseButtonDown(0) && isClickable)
        {
            isClickable = false;
            coolDown = 0;
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 100);

        }

    }
}