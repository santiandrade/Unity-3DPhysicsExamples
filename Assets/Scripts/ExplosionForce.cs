using UnityEngine;
using UnityEngine.UI;

public class ExplosionForce : MonoBehaviour
{
	public float radius = 30.0F;
	public float force = 30.0F;
	public Text forceValueIndicator;

	void Start()
	{
		RefreshForceValueIndicator();
	}

	public void ExplodeBomb()
	{
		Vector3 explosionPosition = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rigidbodyToApplyForce = hit.GetComponent<Rigidbody>();

			if (rigidbodyToApplyForce != null)
			{
				rigidbodyToApplyForce.AddExplosionForce(force, explosionPosition, radius, 1.0f, ForceMode.Impulse);
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
