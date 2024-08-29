using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private const int MaxHealthValue = 100;

    [SerializeField] private PlayerCharacter _character;
    [SerializeField] private Enemy[] _enemies;

    private void Awake()
    {
        _character.Init(MaxHealthValue);

    }
}