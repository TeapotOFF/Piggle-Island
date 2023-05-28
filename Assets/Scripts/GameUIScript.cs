using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _coinText;

    private void Awake()
    {
        GlobalEventMangaer.updateGameUIEvent += UpdateGameUIText;
    }

    private void UpdateGameUIText(int _heal, int _coin)
    {
        _healthText.text = $"X {_heal}";
        _coinText.text = $"X {_coin}";
    }
}
