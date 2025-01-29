using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;
    private Rigidbody _rigidbody;
    private Transform _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        
        
    }
    
    private void Move()
    {
        _rigidbody.velocity = _direction * (_speed * Time.deltaTime);
        transform.LookAt(_target);
    }
    
    public void GetSetting(Vector3 direction, float speed, Transform targetToShoot)
    {
        _direction = direction;
        _speed = speed;
        _target = targetToShoot;
    }
}
