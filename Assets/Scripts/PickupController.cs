using UnityEngine;

public class PickupController : MonoBehaviour
{
	Color color = new Color(0, 0, 0, 1);
	private Vector3 newTransform;
	void Start()
	{
		//Randomize spawn location of pickup
		newTransform.x = UnityEngine.Random.Range(-120, 120);
		newTransform.y = 1;
		newTransform.z = UnityEngine.Random.Range(-120, 120);
		//Apply new transform to object
		transform.position = newTransform;

		//Randomise colour of pickup
		color.r = Random.Range(0.0f, 1.0f);
		color.g = Random.Range(0.0f, 1.0f);
		color.b = Random.Range(0.0f, 1.0f);
		//Apply colour of pickup
		GetComponent<Renderer>().material.color = color;
	}

	void Update()
	{
		//Make the pickup rotate
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
