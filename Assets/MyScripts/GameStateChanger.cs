using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameStateChanger
{
    [SerializeField] private int _targetToKillEnemies;
    [SerializeField] private Text _gameStatusText;
}