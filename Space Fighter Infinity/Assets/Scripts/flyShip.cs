using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyShip : MonoBehaviour
{

    void Start()
    {
        Debug.Log("fly ship script added to: " + gameObject.name);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 50.0f;
        transform.Rotate(Input.GetAxis("Horizontal"), 0.0f, -Input.GetAxis("Vertical"));
    }
}
