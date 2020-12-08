using UnityEngine;

namespace Conveyor
{
  public class ConveyorBelt : MonoBehaviour
  {
    private Renderer _renderer;
    [SerializeField] private float _speed;

    private void Start() => 
      _renderer = GetComponent<Renderer>();

    private void Update() => 
      _renderer.material.SetTextureOffset("_MainTex", new Vector2(0, -Time.time * _speed));
  }
}