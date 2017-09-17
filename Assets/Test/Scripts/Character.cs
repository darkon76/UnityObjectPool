using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField] Bullet _bullet;
    [SerializeField] PoolObjectDictionary _pool;
    [SerializeField] Transform _nozzle;

    [SerializeField] Vector3 mousePos;

    [SerializeField] float _shootCD = .5f;
    private float _shootTimer = 0;

    private Camera _mainCamera;
    private float _distanceToCamera;

    private Plane _plane = new Plane(Vector3.up, 0 );

    private void Awake()
    {
        _mainCamera = Camera.main;
        _distanceToCamera = Vector3.Distance( transform.position, _mainCamera.transform.position );
    }

    // Update is called once per frame
    void Update ()
    {
        Aim( );

        _shootTimer += Time.deltaTime;
        if(_shootTimer >= _shootCD)
        {
            _shootTimer -= _shootCD;
            Shoot( );
        }
	}

    private void Aim()
    {
        Ray ray = _mainCamera.ScreenPointToRay( Input.mousePosition);
        float enter;
        if( _plane.Raycast( ray, out enter ) )
        {
            Vector3 rayPoint = ray.GetPoint(enter);
            transform.LookAt( rayPoint );
        }
    }

    private void Shoot()
    {
        _pool.Get( _bullet.gameObject, _nozzle );
    }
}
