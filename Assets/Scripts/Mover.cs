using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _speed;
    [SerializeField] private Spawner _spawner;
    
    private Transform[] _points;
    private int _currentPointIndex;
    private float _epsilon = 0.1f;
    
    void Start()
    {
        GetTargetPoints();
    }
    
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

    private void GetTargetPoints()
    {
        _points = new Transform[_point.childCount];
        
        for (int i = 0; i < _point.childCount; i++)
        {
            _points[i] = _point.GetChild(i);
        }
    }
    
    private void NextTargetPosition()
    {
        _currentPointIndex++;

        if (_currentPointIndex >= _points.Length)
            _currentPointIndex  = 0;
    }
}