using UnityEngine;

namespace Conveyor
{
  [RequireComponent(typeof(Rigidbody))]
  public class Mover : MonoBehaviour
  {
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    public bool IsMoving;
    
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
      if (IsMoving)
        _rigidbody.velocity = -Vector3.forward * _speed;
    }

    public void Stop()
    {
      IsMoving = false;
      _rigidbody.velocity = Vector3.zero;
    }
  }
}
