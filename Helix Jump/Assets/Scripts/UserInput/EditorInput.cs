using UnityEngine;

namespace UserInput
{
  public class EditorInput : IInput
  {
    public float Torque => 
      -Input.GetAxis("Horizontal");
  }
}