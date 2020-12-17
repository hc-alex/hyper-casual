using TMPro;
using UnityEngine;

namespace Towers
{
  public class TowerSizeView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;
    [SerializeField] private string _finalMessage = "The End";

    private void OnEnable()
    {
      _tower.SizeUpdated += OnSizeUpdated;
      _tower.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
      _tower.SizeUpdated -= OnSizeUpdated;
      _tower.GameOver -= OnGameOver;
    }

    private void OnSizeUpdated(int size) =>
      _sizeView.text = size.ToString();

    private void OnGameOver() =>
      _sizeView.text = _finalMessage;

  }
}