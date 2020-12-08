using UnityEngine;

namespace Platforms
{
  public class PlatformSegment : MonoBehaviour
  {
    public void Bounce(float force, Vector3 position, float radius)
    {
      if (!TryGetComponent(out Rigidbody rigidbody)) 
        return;
      
      rigidbody.isKinematic = false;
      rigidbody.AddExplosionForce(force, position, radius);
    } 
  }
}