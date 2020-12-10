using System;
using Player;
using Tower;
using UnityEngine;

namespace Camera
{
  public class BallTracker : MonoBehaviour
  {
    [SerializeField] private Vector3 _offset; 
    [SerializeField] private float _length;
    
    private Ball _ball;
    private Beam _beam;
    
    private Vector3 _cameraPosition;
    private Vector3 _ballMinimalPosition;

    private void Start()
    {
      _ball = FindObjectOfType<Ball>();
      _beam = FindObjectOfType<Beam>();

      _cameraPosition = _ball.transform.position;
      _ballMinimalPosition = _ball.transform.position;
    }

    private void Update()
    {
      if (!(_ball.transform.position.y < _ballMinimalPosition.y)) 
        return;
      
      TrackBall();
      _ballMinimalPosition = _ball.transform.position;
    }

    private void TrackBall()
    {
      Vector3 beamPosition = _beam.transform.position;
      Vector3 ballPosition = _ball.transform.position;
      beamPosition.y = ballPosition.y;

      _cameraPosition = ballPosition;
      Vector3 direction = (beamPosition - ballPosition).normalized + _offset;
      _cameraPosition -= direction * _length;
      
      SetCamera();
    }

    private void SetCamera()
    {
      transform.LookAt(_ball.transform);
      transform.position = _cameraPosition;
    }
  }
}
