﻿using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(BoxCollider))]
public class CameraFollow : MonoBehaviour {

    private GameObject p1, p2;
    public GameObject P1
    {
        set { p1 = value; }
    }
    public GameObject P2
    {
        set { p2 = value; }
    }

    private Vector3 target;
    public float dist, speed;

    private Renderer p1R, p2R;

	// Use this for initialization
	void Start () {
        
	}

    public void SetRenderer()
    {
        p1R = p1.GetComponent<Renderer>();
        p2R = p2.GetComponent<Renderer>();
    }

    private Vector3 FindTarget()
    {
        Vector3 temp = (p1.transform.position + p2.transform.position) / 2;
        temp.y = transform.position.y;
        return temp;
    }

	// Update is called once per frame
	void Update () {
        target = FindTarget();

        //Debug.Log(Vector3.Distance(p1.transform.position, p2.transform.position) / transform.position.y);

        target.y = (Vector3.Distance(p1.transform.position, p2.transform.position) / 2 + 10 > dist)?Vector3.Distance(p1.transform.position, p2.transform.position) / 2 + 10 : dist;

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
	}
}
