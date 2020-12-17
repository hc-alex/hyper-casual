using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
  public class TowerBuilder : MonoBehaviour
  {
    [SerializeField] private Pipe _pipePrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _pipeNumber;
    [SerializeField] private Color[] _colors;
 
    public List<Pipe> Build()
    {
      List<Pipe> pipes = new List<Pipe>();

      Vector3 position = _parent.transform.position;
      float localScaleY = _pipePrefab.transform.localScale.y;

      for (int i = 0; i < _pipeNumber; i++)
      {
        position.y = localScaleY * (i + 1);
        pipes.Add(BuildPipe(position));
      }

      return pipes;
    }

    private Pipe BuildPipe(Vector3 position)
    {
      Pipe pipe = Instantiate(_pipePrefab, position, Quaternion.identity, _parent);
      pipe.SetColor(_colors[Random.Range(0, _colors.Length)]);
      return pipe;
    }
  }
}
