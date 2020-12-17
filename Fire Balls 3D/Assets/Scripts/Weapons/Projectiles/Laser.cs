using System.Collections;
using Towers;
using UnityEngine;

namespace Weapons.Projectiles
{
  public class Laser : MonoBehaviour
  {
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private LaserEffect _laserEffectPrefab;
    [SerializeField] private float _laserLifeTime;
    
    private LaserEffect _laserEffect;
    private ParticleSystem _laserParticle;
    [SerializeField]private Vector3 _laserEffectOffset;

    public void Enable()
    {
      if (!_lineRenderer.enabled)
        StartCoroutine(Live());
    }

    private IEnumerator Live()
    {
      _lineRenderer.enabled = true;
      yield return new WaitForSeconds(_laserLifeTime);

      TryBreakPipe();
      
      _lineRenderer.enabled = false;
      DisableLaserEffect();
    }

    private void TryBreakPipe()
    {
      if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit)) 
        return;
      
      if (hit.transform.gameObject.TryGetComponent(out Pipe pipe))
        pipe.Break();
    }

    private void Start()
    {
      _laserEffect = Instantiate(_laserEffectPrefab, Vector3.zero, _laserEffectPrefab.transform.rotation);
      _laserParticle = _laserEffect.GetComponent<ParticleSystem>();

      DisableLaserEffect();
      
      _lineRenderer.SetPosition(0, transform.position);
      _lineRenderer.enabled = false;
    }

    private void Update()
    {
      if (!_lineRenderer.enabled)
        return;

      if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
      {
        _lineRenderer.SetPosition(1, hit.point);

        Vector3 direction = transform.position - hit.point;
        Vector3 position = hit.point + direction.normalized * 0.1f;
        EnableLaserEffect(position);
      }
      else
      {
        _lineRenderer.SetPosition(1, transform.position + new Vector3(0, 0, 20f));
        DisableLaserEffect();
      }
    }

    private void EnableLaserEffect(Vector3 position)
    {
      _laserEffect.transform.position = position;
      _laserEffect.gameObject.SetActive(true);
      _laserParticle.Play();
    }

    private void DisableLaserEffect()
    {
      _laserEffect.gameObject.SetActive(false);
      _laserParticle.Pause();
    }
  }
}