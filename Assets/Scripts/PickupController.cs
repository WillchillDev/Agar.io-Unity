using UnityEngine;

public class PickupController : MonoBehaviour {
	private Color color = new Color(0, 0, 0, 1);
	private Vector3 newTransform;
	private Vector3 randomRotate;

	void Start()
	{
		//Randomize spawn location of pickup
		newTransform.x = UnityEngine.Random.Range(-240, 240);
		newTransform.y = 3;
		newTransform.z = UnityEngine.Random.Range(-240, 240);
		//Apply new transform to object
		transform.position = newTransform;

		//Randomise colour of pickup
		color.r = Random.Range(0.0f, 1.0f);
		color.g = Random.Range(0.0f, 1.0f);
		color.b = Random.Range(0.0f, 1.0f);
		//Apply colour of pickup
		GetComponent<Renderer>().material.color = color;

		randomRotate = new Vector3(Random.Range(-80f, 80f), Random.Range(-80f, 80f), Random.Range(-80f, 80f));
	}

	void Update()
	{
		//Make the pickup rotate
		transform.Rotate(randomRotate * Time.deltaTime);
	}
}
