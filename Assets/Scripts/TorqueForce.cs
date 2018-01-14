using UnityEngine;

public class TorqueForce : MonoBehaviour
{
	public float force = 100f;

	private Rigidbody _thisRigidbody;

	void Start()
	{
		_thisRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		_thisRigidbody.AddTorque(transform.right * force, ForceMode.Force);
	}
}
