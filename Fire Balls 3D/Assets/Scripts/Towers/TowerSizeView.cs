using TMPro;
using UnityEngine;

namespace Towers
{
  public class TowerSizeView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;
    [SerializeField] private string _finalMessage = "The End";
    [SerializeField] private Game _game;

    private void Awake()
    {
      _game = FindObjectOfType<Game>();
    }

    private void OnEnable()
    {
      _tower.SizeUpdated += OnSizeUpdated;
      _game.Over += OnGameOver;
    }

    private void OnDisable()
    {
      _tower.SizeUpdated -= OnSizeUpdated;
      _game.Over -= OnGameOver;
    }

    private void OnSizeUpdated(int size) =>
      _sizeView.text = size.ToString();

    private void OnGameOver() =>
      _sizeView.text = _finalMessage;

  }
}