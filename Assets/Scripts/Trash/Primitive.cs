using UnityEngine;

namespace Trash
{
  public static class Primitive
  {
    public static GameObject Create(Transform parent)
    {
      GameObject primitive = GameObject.CreatePrimitive(RandomPrimitiveType());
      primitive.AddComponent<Rigidbody>();
      primitive.GetComponent<Renderer>().material.color = RandomColor();
      primitive.transform.position = RandomPosition();
      primitive.transform.SetParent(parent);
      primitive.SetActive(false);
      
      return primitive;
    }

    private static Vector3 RandomPosition()
    {
      return new Vector3(Random.Range(0, 2), Random.Range(15, 20), Random.Range(0, 2));
    }

    private static Color RandomColor()
      => Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

    private static PrimitiveType RandomPrimitiveType()
    {
      PrimitiveType[] types = {PrimitiveType.Capsule, PrimitiveType.Cube, PrimitiveType.Cylinder, PrimitiveType.Sphere};
      return types[Random.Range(0, types.Length - 1)];
    }
  }
}