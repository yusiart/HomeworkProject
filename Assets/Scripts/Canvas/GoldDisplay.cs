using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _goldDisplay;

    private void OnEnable()
    {
        _player.GoldChanged += OnGoldChanged;
    }

    private void OnDisable()
    {
        _player.GoldChanged -= OnGoldChanged;
    }

    private void OnGoldChanged(int gold)
    {
        _goldDisplay.text = gold.ToString();
    }
}
