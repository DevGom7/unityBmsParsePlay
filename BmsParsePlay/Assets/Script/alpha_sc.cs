using UnityEngine;
using System.Collections;

public class alpha_sc : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Color color = GetComponent<Renderer>().material.color;
        color.a = 0.5f;

        GetComponent<Renderer>().material.SetColor("_Color", color );
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
