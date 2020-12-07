using UnityEngine;

namespace Bowling
{
  [RequireComponent(typeof(Rigidbody))]
  public class Ball : MonoBehaviour
  {
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Start()
    {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      _rigidbody.AddForce(Vector3.forward * _speed);
    }
  }
}