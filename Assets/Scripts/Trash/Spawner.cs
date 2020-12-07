using UnityEngine;
using Random = UnityEngine.Random;

namespace Trash
{
  public class Spawner : MonoBehaviour
  {
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject[] _primitives;
    [SerializeField] private int _primitiveLength = 10;
    
    private int _nextPrimitiveKey;
    private float _timer;
    
    private void Start()
    {
      CreatePrimitives();
    }

    private void Update()
    {
      SpawnPrimitives();
    }

    private void CreatePrimitives()
    {
      _primitives = new GameObject[_primitiveLength];
      
      for (int i = 0; i < _primitiveLength; i++)
      {
        GameObject primitive = Primitive.Create(_parent);
        _primitives[i] = primitive;
      }
    }

    private void SpawnPrimitives()
    {
      if (_nextPrimitiveKey >= _primitiveLength)
        return;
      
      _timer += Time.deltaTime;

      if (!(_timer > Random.Range(1,4)))
        return;

      _primitives[_nextPrimitiveKey].SetActive(true);

      _nextPrimitiveKey++;
      _timer = 0;
    }
  }
}