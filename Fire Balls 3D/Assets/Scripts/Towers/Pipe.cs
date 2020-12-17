using UnityEngine;
using UnityEngine.Events;

namespace Towers
{
  [RequireComponent(typeof(MeshRenderer))]
  public class Pipe : MonoBehaviour
  {
    [SerializeField] private ParticleSystem _destroyEffect;
    private MeshRenderer _meshRenderer;
    public event UnityAction<Pipe> ProjectileHit;

    private void Awake()
    {
      _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetColor(Color color) => 
      _meshRenderer.material.color = color;

    public void Break()
    {
      ProjectileHit?.Invoke(this);

      Vector3 position = transform.position;
      position.y -= transform.localScale.y;
      ParticleSystemRenderer renderer = Instantiate(_destroyEffect, position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
      renderer.material.color = _meshRenderer.material.color;
      
      Destroy(gameObject);
    }
  }
}