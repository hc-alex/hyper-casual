using System;
using UnityEngine;

namespace Conveyor
{
  [RequireComponent(typeof(Rigidbody))]
  public class Mover : MonoBehaviour
  {
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private bool _isMoving;

    private void Awake()
    {
      _rigidbody = transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
      Move();
    }

    private void Move()
    {
      if (_isMoving)
        _rigidbody.velocity = -Vector3.forward * _speed;
    }

    public void StartMoving() =>
      _isMoving = true;

    public void StopMoving()
    {
      _isMoving = false;
      _rigidbody.velocity = Vector3.zero;
    }
  }
}
