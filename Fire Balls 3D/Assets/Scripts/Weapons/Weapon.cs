using UnityEngine;

namespace Weapons
{
  public abstract class Weapon : MonoBehaviour
  {
    [SerializeField] protected float _delayBetweenShots;

    public float DelayBetweenShots => 
      _delayBetweenShots;

    protected Transform ShotPoint;

    public virtual void Prepare(Transform shotPoint) => 
      ShotPoint = shotPoint;

    public abstract void Shoot();
    public abstract void CallRecoil(Transform target);
  }
}