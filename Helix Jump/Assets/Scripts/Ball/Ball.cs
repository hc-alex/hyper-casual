using Platforms;
using UnityEngine;

namespace Ball
{
  public class Ball : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      if(other.TryGetComponent(out PlatformSegment platformSegment)) 
        platformSegment.GetComponentInParent<Platform>().Break();
    }
  }
}