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
      if (!other.gameObject.transform.parent.TryGetComponent(out FinishPlatform finishPlatform))
        return;
     
      GetComponent<Rigidbody>().isKinematic = true;
      Debug.Log("The Finish Platform has been reached! Relax.");
    }
  }
}