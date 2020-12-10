using UnityEngine;
using UserInput;

namespace Tower
{
  [RequireComponent(typeof(Rigidbody))]
  public class TowerRotator : MonoBehaviour
  {
    [SerializeField] private float _rotationSpeed;
    private Rigidbody _rigidbody;

    private static IInput UserInput => 
      Application.isEditor ? (IInput) new EditorInput() : new MobileInput();

    private void Start()
    {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      float torque = UserInput.Torque * _rotationSpeed * Time.deltaTime;
      _rigidbody.AddTorque(Vector3.up * torque);
    }
  }
}
