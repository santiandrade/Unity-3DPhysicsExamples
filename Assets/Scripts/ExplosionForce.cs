using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
	public float radius = 5.0F;
	public float power = 10.0F;
	public KeyCode keyToExplode = KeyCode.Space;

	void Update()
	{
		if (Input.GetKeyDown(keyToExplode))
		{
			ExplodeBomb();
		}
	}

	private void ExplodeBomb()
	{
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.AddExplosionForce(power, explosionPos, radius);
				rb.useGravity = true;
			}
		}

		Destroy(gameObject);
	}
}
