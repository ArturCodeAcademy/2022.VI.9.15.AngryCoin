using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Rigidbody2D))]
public class PigDamager : MonoBehaviour
{
    [SerializeField, Min(0)] private float _minDamage;
    [SerializeField, Range(0.5f, 10)] private float _velocityMultiplier;
    private Rigidbody2D _rigidbody;
    private Health _health;
    private float _recievedDamage = 0;

	private void Start()
	{
		_health = GetComponent<Health>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void LateUpdate()
	{
        if (_recievedDamage >= _minDamage)
            _health.Hit(_recievedDamage);
        _recievedDamage = 0;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		float hit = _rigidbody.velocity.magnitude * _velocityMultiplier;
		_recievedDamage = hit;

		if (collision.transform.TryGetComponent(out PigDamager pigDamager))
			pigDamager.Hit(_recievedDamage);
	}

	public void Hit(float damage)
	{
		_recievedDamage = Mathf.Max(damage, _recievedDamage);
	}
}
