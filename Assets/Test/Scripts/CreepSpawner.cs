using UnityEngine;

public class CreepSpawner: MonoBehaviour
{
    [SerializeField]
    private Creep creep;
    [SerializeField]
    private PoolObjectDictionary _pool;
    [Space]
    [SerializeField]
    private float Timer = 1;
    [SerializeField]
    private float _spawnRadius = 5;
    private void Start()
    {
        InvokeRepeating( "SpawnCreep", 0, Timer );
    }

    // Update is called once per frame
    private void SpawnCreep()
    {
        var randomPosition =  Random.insideUnitCircle.normalized;
        randomPosition *= _spawnRadius;
        var spawn = _pool.Get(creep.gameObject);
        spawn.transform.position = new Vector3(randomPosition.x, 0, randomPosition.y);
        spawn.SetActive( true );
        
    }
}