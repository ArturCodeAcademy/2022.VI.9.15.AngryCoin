using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestroyPigOnEndHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;

	private void Start()
	{
		GetComponent<Health>().OnHealthEnd.AddListener(OnHealthEnd);
	}

	private void OnHealthEnd()
	{
		Destroy(gameObject);
	}
}
