﻿using Platforms;
using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallJumper : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent(out PlatformSegment platformSegment))
                return;
            
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * _speed, ForceMode.Impulse);
        }
    }
}
