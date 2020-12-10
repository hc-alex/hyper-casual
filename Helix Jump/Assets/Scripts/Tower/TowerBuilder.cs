using Platforms;
using UnityEngine;

namespace Tower
{
  [RequireComponent(typeof(PlatformGenerator))]
  public class TowerBuilder : MonoBehaviour
  {
    [SerializeField] private int _levelPlatformCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private float _distanceBetweenPlatformsY;

    [SerializeField] private GameObject _beam;
    [SerializeField] private GameObject _ball;

    private PlatformGenerator _platformGenerator;
    private GameObject _spawnPlatform;
    private float _ballPositionY;

    private float BeamScaleY => 
      (_levelPlatformCount + 1) * _distanceBetweenPlatformsY / 2f + _additionalScale / 2f;
        
    private void Awake()
    {
      _platformGenerator = GetComponent<PlatformGenerator>();
      Build();
      InstantiateBall();
    }

    private void Build()
    {
      GameObject beam = Instantiate(_beam, transform);
      beam.transform.localScale = new Vector3(1, BeamScaleY, 1);
            
      Vector3 spawnPosition  = transform.position;
      spawnPosition.y += BeamScaleY - _additionalScale;
      _ballPositionY = spawnPosition.y;
      
      _platformGenerator.Generate<SpawnPlatform>(spawnPosition, beam.transform, 1);
      spawnPosition.y -= _distanceBetweenPlatformsY;

      for (int i = 0; i < _levelPlatformCount; i++)
      {
        _platformGenerator.Generate<Platform>(spawnPosition, beam.transform);
        spawnPosition.y -= _distanceBetweenPlatformsY;
      }
            
      _platformGenerator.Generate<FinishPlatform>(spawnPosition, beam.transform, 0);
    }

    private void InstantiateBall()
    {
      float radians = 2 * Mathf.PI / Random.Range(1, 10);
      Vector3 direction = new Vector3 (Mathf.Cos(radians), 0, Mathf.Sin(radians));
      float radius = 0.75f;
      Vector3 position = new Vector3(0, _ballPositionY + 0.5f, 0) + direction * radius;
      Instantiate(_ball, position, Quaternion.identity);
    }
  }
}