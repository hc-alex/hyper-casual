using Platforms;
using UnityEngine;

namespace Player
{
  public class Ball : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      if(other.TryGetComponent(out PlatformSegment platformSegment)) 
        platformSegment.GetComponentInParent<Platform>().Break();
    }

    private void OnCollisionEnter(Collision other)
    {
      FinishPlatform componentInParent = other.gameObject.GetComponentInParent<FinishPlatform>(); 
      
      if (componentInParent == null)
        return;
      
      GetComponent<Rigidbody>().isKinematic = true;
      Debug.Log("The Finish Platform has been reached! Relax.");
    }
  }
}