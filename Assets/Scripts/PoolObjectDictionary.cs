using System.Collections.Generic;
using UnityEngine;

public class PoolObjectDictionary: MonoBehaviour
{
    private readonly Dictionary<GameObject, PoolObjectContainer> _poolDictionary = new Dictionary<GameObject, PoolObjectContainer>();
    [SerializeField] private Transform _parent;


    public PoolObjectContainer GetPool(GameObject template, int poolSize = 1)
    {
        PoolObjectContainer pool;
        if( !_poolDictionary.TryGetValue( template, out pool ) )
        {
            var parent = _parent;
            if( parent == null )
                parent = transform;
            pool = new PoolObjectContainer( template, parent, poolSize );
            _poolDictionary.Add( template, pool );
        }
        return pool;
    }

    public GameObject Get(GameObject template)
    {
        PoolObjectContainer pool = GetPool(template);
        return pool.Get( );
    }

    public T Get<T>(T template) where T : Component
    {
        var obj = Get(template.gameObject);
        return obj.GetComponent<T>( );
    }

    public GameObject Get(GameObject template, Transform transform)
    {
        var obj = Get(template);
        obj.gameObject.transform.SetPositionAndRotation( transform.position, transform.rotation );
        obj.gameObject.SetActive( true );
        return obj;
    }
}