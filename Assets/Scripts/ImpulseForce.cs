using UnityEngine;

class ImpulseForce : MonoBehaviour
{
	public KeyCode keyToApplyForce = KeyCode.Space;
	public float force = 100f;

	private Rigidbody _thisRigidbody;

	void Start()
	{
		_thisRigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKeyDown(keyToApplyForce))
		{
			_thisRigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
		}
	}
}