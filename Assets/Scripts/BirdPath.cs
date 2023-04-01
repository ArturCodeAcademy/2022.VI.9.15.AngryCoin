using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPath : MonoBehaviour
{
    [SerializeField, Range(0.05f, 1)] private float _pause;
    [SerializeField, Range(0.05f, 10)] private float _lifeTime;
    
    private bool _isDrawing;

	private IEnumerator Start()
	{
		WaitForSeconds wait = new WaitForSeconds(_pause);
		LineRenderer path = GetComponent<LineRenderer>();
		List<Vector3> positions = new List<Vector3>();
		_isDrawing = true;

		while (_isDrawing)
		{
			positions.Add(transform.position);
			path.positionCount = positions.Count;
			path.SetPositions(positions.ToArray());
			yield return wait;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.isTrigger)
			return;
		_isDrawing = false;
		Destroy(gameObject, _lifeTime);
	}
}
