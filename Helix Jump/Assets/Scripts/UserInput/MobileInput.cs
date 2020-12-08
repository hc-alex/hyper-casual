using UnityEngine;

namespace UserInput
{
  public class MobileInput : IInput
  {
    public float Torque {
      get
      {
        if (Input.touchCount == 0)
          return 0f;

        Touch touch = Input.GetTouch(0);

        return touch.phase != TouchPhase.Moved ? 0f : touch.deltaPosition.x;
      }
    }
  }
}
