using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyShip : MonoBehaviour {

    public float speed = 10f;
    public float movementSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(1* speed, 0,  Input.GetAxis("Horizontal")*Time.deltaTime*movementSpeed);
	}
}
