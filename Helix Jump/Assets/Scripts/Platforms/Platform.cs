using UnityEngine;

namespace Platforms
{
  public class Platform : MonoBehaviour
  {
    private const float BounceForce = 50f;
    private const float BounceRadius = 50f;

    public void Break()
    {
      PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();
      
      foreach (PlatformSegment segment in platformSegments) 
        segment.Bounce(BounceForce, transform.position, BounceRadius);
    }
  }
}