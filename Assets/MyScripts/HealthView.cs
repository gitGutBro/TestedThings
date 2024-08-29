using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour 
{
    [SerializeField] private TMP_Text _value;
    [SerializeField] private Slider _slider;

    public Health Health { get; private set; }

    private void OnDestroy() =>
        Health.Changed -= OnHealthChanged;

    public void Init(Health health)
    {
        Health = health ?? throw new System.ArgumentNullException(nameof(health));
        Health.Changed += OnHealthChanged;

        OnHealthChanged(health.Current, health.Max);
    }

    private void OnHealthChanged(int health, int max)
    {
        _value.text = $"{health:F0}/{max:F0}";

        if (max < 0)
        {
            Debug.LogError($"Value max below zero! {GetType()}");
            return;
        }

        _slider.value = (float)health / max;
    }
}