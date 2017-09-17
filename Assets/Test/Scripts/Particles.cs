using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {


    float _duration;
    float _counter = 0;
	// Use this for initialization
	void Awake () {
        var particles = GetComponent<ParticleSystem>();
        _duration = particles.main.duration;
    }

    private void OnEnable()
    {
        _counter = 0;
    }

    // Update is called once per frame
    void Update () {
        _counter += Time.deltaTime;
        if( _counter >= _duration )
            gameObject.SetActive( false );
	}
}
