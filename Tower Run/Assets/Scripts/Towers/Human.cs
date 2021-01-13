using UnityEngine;

namespace Towers
{
  [RequireComponent(typeof(Animator))]
  public class Human : MonoBehaviour
  {
    [SerializeField] private Transform _fixationPoint;
    public Transform FixationPoint => _fixationPoint;

    private Animator _animator;
    
    private static readonly int IsDead = Animator.StringToHash("isDead");
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int WaveTrigger = Animator.StringToHash("Wave");

    private bool _isExploded;

    private void Awake()
    {
      _animator = GetComponent<Animator>();
    }

    public void Explode()
    {
      if(_isExploded)
        return;

      _isExploded = true;
      
      PlayDeath();
      transform.parent = null;
      gameObject.AddComponent<Rigidbody>().AddExplosionForce(200f, Vector3.zero,30f);
      Destroy(gameObject, 2f);
    }

    public void Run() =>
      _animator.SetBool(IsRunning, true);

    public void StopRun() =>
      _animator.SetBool(IsRunning, false);

    public void Wave() =>
      _animator.SetTrigger(WaveTrigger);

    private void PlayDeath() => 
      _animator.SetBool(IsDead, true);
  }
}
