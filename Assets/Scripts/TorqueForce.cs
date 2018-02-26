using UnityEngine;
using UnityEngine.UI;

public class TorqueForce : MonoBehaviour
{
	public float force = 2f;
	public Text forceValueIndicator;

	private Rigidbody _thisRigidbody;

	void Start()
	{
		_thisRigidbody = GetComponent<Rigidbody>();
		_thisRigidbody.maxAngularVelocity = 20f;
		RefreshForceValueIndicator();
	}

	void FixedUpdate()
	{
		_thisRigidbody.AddTorque(transform.forward * force);
	}

	public void IncrementForce()
	{
		force = Mathf.Clamp(force + 1f, force, 20f);
		RefreshForceValueIndicator();
	}

	public void DecrementForce()
	{
		force = Mathf.Clamp(force - 1f, 0, force);
		RefreshForceValueIndicator();
	}

	private void RefreshForceValueIndicator()
	{
		forceValueIndicator.text = force.ToString();
	}
}
