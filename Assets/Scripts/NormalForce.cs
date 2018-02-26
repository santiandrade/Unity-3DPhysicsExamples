using UnityEngine;
using UnityEngine.UI;

public class NormalForce : MonoBehaviour
{
	public float force = 30.0F;
	public Text forceValueIndicator;

	private Camera _thisCamera;

	void Start()
	{
		_thisCamera = GetComponent<Camera>();
		RefreshForceValueIndicator();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = _thisCamera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				Rigidbody rigidbodyToApplyForce = hit.transform.GetComponent<Rigidbody>();
				if (rigidbodyToApplyForce != null)
				{
					rigidbodyToApplyForce.AddForceAtPosition(ray.direction * force, hit.point, ForceMode.Impulse);
				}
			}
		}
	}

	public void IncrementForce()
	{
		force = Mathf.Clamp(force + 10f, force, 500f);
		RefreshForceValueIndicator();
	}

	public void DecrementForce()
	{
		force = Mathf.Clamp(force - 10f, 0, force);
		RefreshForceValueIndicator();
	}

	private void RefreshForceValueIndicator()
	{
		forceValueIndicator.text = force.ToString();
	}
}
