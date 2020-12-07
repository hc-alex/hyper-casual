using UnityEngine;

namespace Rocks
{
  public interface ICommand
  {
    void Execute();
  }

  public class MoveUp : ICommand
  {
    private readonly Transform _transform;
  
    public MoveUp(Transform transform) => 
      _transform = transform;

    public void Execute() => 
      _transform.Translate(Vector3.up * 5);
  }
  
  public class MoveForward : ICommand
  {
    private readonly Rigidbody _rigidbody;

    public MoveForward(Rigidbody rigidbody) => 
      _rigidbody = rigidbody;

    public void Execute()
    {
      _rigidbody.isKinematic = false;
      _rigidbody.AddForce(Vector3.forward * 1000);
    }
  }
}