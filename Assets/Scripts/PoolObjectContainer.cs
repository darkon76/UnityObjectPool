using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolObjectContainer
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _parent;

    private Stack<GameObject> _poolStack = new Stack<GameObject>();

    public PoolObjectContainer(GameObject gameObject, Transform parent, int count = 1)
    {
        _parent = parent;
        count = Mathf.Max( count, 1 );
        _template = gameObject;
        _template = CreateObject( );
        _template.name = gameObject.name;
        for( var i = 0; i < count; ++i )
        {
            _poolStack.Push( CreateObject( ) );
        }
    }

    public GameObject Get()
    {
        if( _poolStack.Count > 0 )
        {
            var obj = _poolStack.Pop();
            if( !obj.activeSelf )
                return obj;
        }
        return CreateObject( );
    }

    private GameObject CreateObject()
    {
        var gameObject = GameObject.Instantiate(_template, _parent, false);
        gameObject.SetActive( false );
        var poolObject = gameObject.GetComponent<PoolObject>();
        if(poolObject == null)
            poolObject = gameObject.AddComponent<PoolObject>( );
        poolObject.Containter = this;

        return gameObject;
    }

    public void ReturnToPool(PoolObject poolObject)
    {
        //It is normal to have errors here, when the game stops. 
        _poolStack.Push( poolObject.gameObject );
    }
}