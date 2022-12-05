using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _startHealth = 100;
    [SerializeField] private int _minHealth = 0;
    [SerializeField] private int _maxHealth = 100;

    private Health _health;

    public int MaxHealth => _maxHealth;
    public int Health => _health.Value;

    public event UnityAction<int, int> HealthChanged;

    private void Awake()
    {
        _health = new Health(_startHealth, _minHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _health.Damage(damage);
        HealthChanged?.Invoke(_health.Value, _health.MaxValue);
    }

    public void TakeHeal(int heal)
    {
        _health.Heal(heal);
        HealthChanged?.Invoke(_health.Value, _health.MaxValue);
    }
}
