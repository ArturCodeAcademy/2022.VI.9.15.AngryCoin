using UnityEngine;

[DisallowMultipleComponent]
public class PigRegistration : MonoBehaviour
{
	private void OnEnable() => PigLevelPool.Instance?.Add(transform);

	private void OnDisable() => PigLevelPool.Instance?.Remove(transform);
}
