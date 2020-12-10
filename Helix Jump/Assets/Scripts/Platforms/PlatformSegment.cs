using UnityEngine;

namespace Platforms
{
  public class PlatformSegment : MonoBehaviour
  {
    public void Bounce(float force, Vector3 position, float radius)
    {
      if (!TryGetComponent(out Rigidbody outRigidbody)) 
        return;
      
      outRigidbody.isKinematic = false;
      outRigidbody.AddExplosionForce(force, position, radius);
    } 
  }
}