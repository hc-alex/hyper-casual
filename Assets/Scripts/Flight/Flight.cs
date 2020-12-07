using UnityEngine;

namespace Flight
{
  public class Flight : MonoBehaviour
  {
    private void Update() => 
      transform.position += Vector3.forward * Time.deltaTime;
  }
}