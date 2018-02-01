using UnityEngine;

public class TorqueForce : MonoBehaviour
{
	public float force = 100f;

	private Rigidbody _thisRigidbody;
	private bool _isOn = false;

	void Start()
	{
		_thisRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (_isOn)
		{
			_thisRigidbody.AddTorque(transform.forward * force, ForceMode.Acceleration);
		}
	}

	public void Activate()
	{
		_isOn = !_isOn;
	}
}
