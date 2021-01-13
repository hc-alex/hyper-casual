using UnityEngine;

namespace Player
{
  public class Jumper : MonoBehaviour
  {
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;
    private Rigidbody _rigidbody;

    private void Start()
    {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      if (!Input.GetKeyDown(KeyCode.Space) || !_isGrounded) 
        return;
      
      _isGrounded = false;
      _rigidbody.AddForce(Vector3.up * _jumpForce);
    }

    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.TryGetComponent(out Path path))
        _isGrounded = true;
    }

    public void ModifyJumpForce(float multiplicator) => 
      _jumpForce *= multiplicator;
  }
}