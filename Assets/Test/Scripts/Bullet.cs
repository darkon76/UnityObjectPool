using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _disableTime = 10;
    [SerializeField] private float _disableCounter = 0;
    [Space]
    [SerializeField]
    private GameObject FX;
    PoolObjectDictionary _pool;

    private void Awake()
    {
        _pool = FindObjectOfType<PoolObjectDictionary>( );
    }


    private void OnEnable()
    {
        _disableCounter = 0;
    }
    // Update is called once per frame
    void Update () {
        _disableCounter += Time.deltaTime;
        if( _disableCounter >= _disableTime )
            gameObject.SetActive( false );
        transform.Translate( Vector3.forward * _speed * Time.deltaTime, Space.Self );
	}

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive( false );
        _pool.Get( FX, transform );
    }
}
