using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    
    private int _currentPointIndex;
    private float _epsilon = 0.1f;
    
    public void Update()
    {
        Transform target = _points[_currentPointIndex];
        
        transform.LookAt(target);
        
        transform.position = Vector3.MoveTowards(transform.position , target.position, _speed * Time.deltaTime);

        if ((transform.position - target.position).sqrMagnitude < _epsilon)
        {
            NextTargetPosition();
        }
    }
    
    private void NextTargetPosition()
    {
        _currentPointIndex++;

        if (_currentPointIndex >= _points.Length)
            _currentPointIndex  = 0;
    }
}