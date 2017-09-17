using UnityEngine;

public class PoolObject: MonoBehaviour
{
    public PoolObjectContainer Containter;

    private void OnDisable()
    {
        if( Containter != null )
            Containter.ReturnToPool( this );
    }
}