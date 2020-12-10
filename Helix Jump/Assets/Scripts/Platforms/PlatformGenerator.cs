using UnityEngine;

namespace Platforms
{
    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] private PlatformSegment _segment60Prefab;
        [SerializeField] private PlatformSegment _segment90Prefab;

        private readonly Vector2[] _segmentCombinations = { new Vector2(6, 0), new Vector2(3, 2), new Vector2(0, 4) };
        private PlatformSegment[] _segments;
        private int _segmentsLength;

        public void Generate<TComponent>(Vector3 position, Transform parent, int disabled = 2) where TComponent : Platform
        {
            GameObject platform = new GameObject("Platform");
            
            platform.transform.SetParent(parent);
            platform.transform.localScale = new Vector3(1, 1.1f, 1);
            platform.transform.position = position;
            platform.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
            
            platform.AddComponent<TComponent>();
            
            Vector2 combination = _segmentCombinations[Random.Range(0, _segmentCombinations.Length)];
            
            _segmentsLength = (int) (combination.x + combination.y);
            _segments = new PlatformSegment[_segmentsLength];
            int segmentPosition = 0;
            
            float rotationZ = 0;
            
            if(combination.x > 0)
                SpawnSegments(_segment60Prefab, (int) combination.x, position, ref rotationZ, 60, platform.transform, ref segmentPosition);
            
            if(combination.y > 0)
                SpawnSegments(_segment90Prefab, (int) combination.y, position, ref rotationZ, 90, platform.transform, ref segmentPosition);
            
            if (disabled > 0 && disabled < _segmentsLength)
                DisableRandomSegments(disabled);
        }

        private void SpawnSegments(PlatformSegment prefab, int number, Vector3 position, ref float rotationZ, float arcLength, Transform parent, ref int segmentPosition)
        {
            for (int i = 0; i < number; i++)
            {
                _segments[segmentPosition] = Instantiate(prefab, position, Quaternion.Euler(-90, 0, rotationZ), parent);
                
                segmentPosition++;
                rotationZ -= arcLength;
            }
        }

        private void DisableRandomSegments(int number)
        {
            for (int i = 0; i < number; i++)
            {
                int randomPosition = Random.Range(0, _segmentsLength);
                _segments[randomPosition].GetComponent<MeshRenderer>().enabled = false;
                _segments[randomPosition].GetComponent<MeshCollider>().isTrigger = true;
                Vector3 transformPosition = _segments[randomPosition].transform.position;
                transformPosition.y -= 0.1f;
                _segments[randomPosition].transform.position = transformPosition;
            }
        }
    }
}
