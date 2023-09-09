using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointsParent;
    [SerializeField] private float _moveSpeed = 1;
    
    private Transform[] _points;
    private int _nextPointIndex;

    private void Start()
    {
        _points = new Transform[_pointsParent.childCount];

        for (int i = 0; i < _pointsParent.childCount; i++)
        {
            _points[i] = _pointsParent.GetChild(i).transform;
        }
    }

    private void Update()
    {
        var nextPoint = _points[_nextPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, _moveSpeed * Time.deltaTime);

        if (transform.position == nextPoint.position)
            SetNextPoint();
    }

    private Vector3 SetNextPoint()
    {
        _nextPointIndex++;

        if (_nextPointIndex == _points.Length)
            _nextPointIndex = 0;

        var nextPointPosition = _points[_nextPointIndex].transform.position;
        transform.forward = nextPointPosition - transform.position;
        return nextPointPosition;
    }
}
