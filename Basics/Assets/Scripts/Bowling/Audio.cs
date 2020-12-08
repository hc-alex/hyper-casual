using UnityEngine;

namespace Bowling
{
  [RequireComponent(typeof(AudioSource))]
  [RequireComponent(typeof(Ball))]
  public class Audio : MonoBehaviour
  {
    private AudioSource _audioSource;
    private Ball _ball;

    private const string BallAudioFile = "Audio/Ball";
    private const string KegelsAudioFile = "Audio/Kegels";
    private const string CollisionGameObjectName = "Kegel";

    private AudioClip _ballClip;
    private AudioClip _kegelsClip;

    private void Start()
    {
      _audioSource = GetComponent<AudioSource>();
      _ball = GetComponent<Ball>();
      
      GetAudioClips();

      PlayAudioClip(_ballClip);
    }

    private void OnCollisionEnter(Collision other)
    {
      if(other.gameObject.name == CollisionGameObjectName)
        PlayAudioClip(_kegelsClip);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
      _audioSource.clip = audioClip;
      _audioSource.Play();
    }

    private void GetAudioClips()
    {
      _ballClip = (AudioClip) Resources.Load(BallAudioFile);
      _kegelsClip = (AudioClip) Resources.Load(KegelsAudioFile);
    }
  }
}