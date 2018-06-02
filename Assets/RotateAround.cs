using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public GameObject _Pillar;
    // Use this for initialization
	void Start () {
        _Pillar = GameObject.FindGameObjectWithTag("Pillar");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed primary button.");
            transform.RotateAround(_Pillar.transform.position, Vector2.right, 20 * Time.deltaTime);
	}

  
}
