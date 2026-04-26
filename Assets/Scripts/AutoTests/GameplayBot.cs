using UnityEngine;

namespace AutoTests
{
    public class GameplayBot : MonoBehaviour
    {
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private float _movementSpeed = 3.5f;
        [SerializeField] private float _waypointReachDistance = 0.2f;

        private float _sqrWaypointReachDistance;
        private int _currentWaypointIndex;
        private bool _isFinished;

        public bool IsFinished => _isFinished;

        private void Awake()
        {
            _sqrWaypointReachDistance = _waypointReachDistance * _waypointReachDistance;
        }

        private void Update()
        {
            if (_isFinished || _waypoints.Length == 0)
            {
                return;
            }

            MoveToCurrentWaypoint();
        }

        private void MoveToCurrentWaypoint()
        {
            Transform targetWaypoint = _waypoints[_currentWaypointIndex];

            Vector3 direction = targetWaypoint.position - transform.position;
            direction.y = 0;

            if (direction.sqrMagnitude <= _waypointReachDistance)
            {
                _currentWaypointIndex++;

                if (_currentWaypointIndex >= _waypoints.Length)
                {
                    _isFinished = true;
                }
            }
            else
            {
                transform.position += direction.normalized * (_movementSpeed * Time.deltaTime);
            }
        }
    }
}