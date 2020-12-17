using Towers;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    private Tower _tower;

    public event UnityAction Over;
    
    private void Start()
    {
        _tower = FindObjectOfType<Tower>();
        _tower.SizeUpdated += OnSizeUpdated;
    }

    private void OnSizeUpdated(int size)
    {
        if(size == 0)
            Over?.Invoke();
    }

    private void OnDestroy()
    {
        _tower.SizeUpdated -= OnSizeUpdated;
    }
}
