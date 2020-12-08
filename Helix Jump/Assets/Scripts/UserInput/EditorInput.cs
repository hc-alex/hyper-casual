using UnityEngine;

namespace Inputs
{
  public class EditorInput : IInput
  {
    public float Torque => 
      -Input.GetAxis("Horizontal");
  }
}