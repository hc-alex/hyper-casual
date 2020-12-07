using UnityEngine;

namespace Rocks
{
  public class Input : MonoBehaviour
  {
    public GameObject[] Rocks;
    
    public void Update()
    {
      if (UnityEngine.Input.GetKeyUp(KeyCode.W))
      {
        foreach (GameObject rock in Rocks)
        {
          new MoveUp(rock.transform).Execute();
        }
      }

      if (UnityEngine.Input.GetKeyUp(KeyCode.Space))
      {
        foreach (GameObject rock in Rocks)
        {
          new MoveForward(rock.GetComponent<Rigidbody>()).Execute();
        }
      }
    }
  }
}
