using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
	public Transform target;
	public bool lookAtTarget = true;
	public float rotationSpeed = 10f;

	void Update ()
	{
		transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);

		if (lookAtTarget)
		{
			transform.LookAt(target);
		}
	}
}
