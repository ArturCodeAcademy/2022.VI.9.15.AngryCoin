using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field:SerializeField] public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }
    public UnityEvent OnHealthEnd;

	private void Awake()
	{
		OnHealthEnd ??= new UnityEvent();
		CurrentHealth = MaxHealth;
	}

	public float Hit(float damage)
	{
		if (damage <= 0)
			return 0;

		float res = Mathf.Min(damage, CurrentHealth);
		CurrentHealth -= damage;

		if (CurrentHealth <= 0)
			OnHealthEnd?.Invoke();

		return res;
	}
}
