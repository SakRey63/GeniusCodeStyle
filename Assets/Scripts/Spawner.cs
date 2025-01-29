using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _delay;
    
    private Transform _targetToShoot;
    
    void Start() 
    {
        StartCoroutine(ShootingPlayer());
    }
    
    private IEnumerator ShootingPlayer()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        
        while (true)
        {
            Vector3 direction = (_targetToShoot.position - transform.position).normalized;
            
            Bullet bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.GetSetting(direction, _speed, _targetToShoot);

            yield return delay;
        }
    }
}