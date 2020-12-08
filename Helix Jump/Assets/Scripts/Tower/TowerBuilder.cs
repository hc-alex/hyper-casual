using Platforms;
using UnityEngine;

namespace Tower
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private int _levelPlatformCount;
        [SerializeField] private float _additionalScale;
        [SerializeField] private float _distanceBetweenPlatformsY;

        [SerializeField] private GameObject _beam;

        [SerializeField] private Platform[] _platformPrefabs;
        [SerializeField] private SpawnPlatform _spawnPlatformPrefab;
        [SerializeField] private FinishPlatform _finishPlatformPrefab;

        private float BeamScaleY => 
            (_levelPlatformCount + 1) * _distanceBetweenPlatformsY / 2f + _additionalScale / 2f;
        
        private void Start()
        {
            Build();
        }

        private void Build()
        {
            GameObject beam = Instantiate(_beam, transform);
            beam.transform.localScale = new Vector3(1, BeamScaleY, 1);
            
            Vector3 spawnPosition  = transform.position;
            spawnPosition.y += BeamScaleY - _additionalScale;

            SpawnPlatform(_spawnPlatformPrefab, ref spawnPosition, transform);
            
            for (int i = 0; i < _levelPlatformCount; i++) 
                SpawnPlatform(_platformPrefabs[Random.Range(0, _platformPrefabs.Length)], ref spawnPosition, transform);

            SpawnPlatform(_finishPlatformPrefab,ref spawnPosition, transform);
        }

        private void SpawnPlatform(Platform prefab, ref Vector3 spawnPosition, Transform parent)
        {
            Instantiate(prefab, spawnPosition, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), parent);
            spawnPosition.y -= _distanceBetweenPlatformsY;
        }
    }
}
