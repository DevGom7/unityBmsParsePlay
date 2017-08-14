using UnityEngine;
using System.Collections;

public class Effect_sc : MonoBehaviour {

    ParticleSystem testParticle;

    // Use this for initialization
    void Start () {
        testParticle = gameObject.GetComponent<ParticleSystem>();
        testParticle.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
