using UnityEngine;

public class Creep: MonoBehaviour
{
    [SerializeField] float _maxHealth = 3;
    [SerializeField] float _currentHealth = 0;
    [Space]
    [SerializeField]
    float _speed = 2;

    private Transform _target;

    private void Awake()
    {
        //Expensive operations can be done only once per awake 
        var player = FindObjectOfType<Character>();
        _target = player.transform;
    }


    private void OnEnable()
    {
        //Setup when the object is pooled. 
        _currentHealth = _maxHealth;
        transform.LookAt( _target );
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate( Vector3.forward * _speed * Time.deltaTime, Space.Self );
    }

    private void OnCollisionEnter(Collision collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if(bullet)
        {
            _currentHealth--;
            if( _currentHealth <= 0 )
                Dead( );
        }
        else//The player
        {
            gameObject.SetActive( false );
        }
    }

    private void Dead()
    {
        gameObject.SetActive( false );
    }
}