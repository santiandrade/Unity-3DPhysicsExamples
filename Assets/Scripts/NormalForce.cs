using UnityEngine;
using UnityEngine.UI;

public class NormalForce : MonoBehaviour
{
	public float force = 150.0F;
	public Transform pointerObject;
	public Text forceValueIndicator;
	public ParticleSystem shotFX;

	private Camera _thisCamera;

	void Start()
	{
		Cursor.visible = false;
		_thisCamera = GetComponent<Camera>();
		RefreshForceValueIndicator();
	}

	void Update()
	{
		Vector3 pointerPosition = Input.mousePosition;
		pointerPosition.z = 5f;
		pointerPosition = Camera.main.ScreenToWorldPoint(pointerPosition);
		pointerObject.position = pointerPosition;

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = _thisCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				Rigidbody rigidbodyToApplyForce = hit.transform.GetComponent<Rigidbody>();
				if (rigidbodyToApplyForce != null)
				{
					rigidbodyToApplyForce.AddForceAtPosition(ray.direction * force, hit.point, ForceMode.Impulse);
				}

				if (force > 0f)
				{
					shotFX.transform.position = hit.point;
					shotFX.Clear(true);
					shotFX.Play(true);
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
