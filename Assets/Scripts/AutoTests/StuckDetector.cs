using System;
using UnityEngine;

namespace AutoTests
{
    public class StuckDetector : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _minimumMovementDistance = 0.05f;
        [SerializeField] private float _maximumStuckTime = 2f;

        private Vector3 _lastPosition;
        private float _stuckTimer;
        private float _sqrMinimumMovementDistance;

        public bool IsStuck { get; private set; }

        private void Awake()
        {
            _sqrMinimumMovementDistance = _minimumMovementDistance * _minimumMovementDistance;
        }

        private void Start()
        {
            _lastPosition = _target.position;
        }

        private void Update()
        {
            Vector3 direction = _lastPosition - _target.position;

            if (direction.sqrMagnitude < _sqrMinimumMovementDistance)
            {
                _stuckTimer += Time.deltaTime;

                if (_stuckTimer >= _maximumStuckTime)
                {
                    IsStuck = true;
                }
            }
            else
            {
                _stuckTimer = 0f;
                IsStuck = false;
                _lastPosition = _target.position;
            }
        }
    }
}