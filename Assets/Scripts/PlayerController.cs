using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;

	public Text SizeText;
	public float size = 0;

	public CameraController cam;

	private float timeSinceEat;
	private float timeSinceDecay;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		SizeText.text = "Size: " + size.ToString();
		timeSinceEat = 0;
		timeSinceDecay = 0;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);
		Vector3 torque = new Vector3(moveVertical * speed, 0.0f, -moveHorizontal * speed);
		rb.AddForce(movement);
		rb.AddTorque(torque, ForceMode.Force);
	}

	void Update()
	{
		timeSinceDecay += Time.deltaTime;
		timeSinceEat += Time.deltaTime;

		if (timeSinceDecay > 0.1)
		{
			if (timeSinceEat > 3.0 && size > 9)
			{
				float sizeLost = (size - size * Mathf.Pow(0.998f, Time.time - timeSinceEat)) / 10;
				AddSize(-sizeLost);
				print(sizeLost.ToString());

				timeSinceDecay = 0;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//If the  collision is a pickup
		if (other.gameObject.CompareTag("Pickup"))
		{
			AddSize(1.0f);
			//Destroy the object. This kills the object and all of its children.
			Destroy(other.gameObject);
			timeSinceEat = 0;
		}
	}

	void AddSize(float s)
	{
		size += s;
		SizeText.text = "Size: " + size.ToString();

		if (size < 10)
		{
			//Increase the size by S units
			AddScale(new Vector3(s, s, s));
		}
		else if (size < 20)
		{
			//Increase the size by S / 1.5 units
			AddScale(new Vector3(s / 1.5f, s / 1.5f, s / 1.5f));
		}
		else if (size < 50)
		{
			//Increase the size by S / 2 units
			AddScale(new Vector3(s / 2f, s / 2f, s / 2f));
		}
		else if (size < 100)
		{
			//Increase the size by S / 3 units
			AddScale(new Vector3(s / 3, s / 3, s / 3));
		}
		else if (size < 200)
		{
			//Increase the size by S / 5 units
			AddScale(new Vector3(s / 5, s / 5, s / 5));
		}

		//Adjust the speed for slower movement		
		if (rb.mass < 2)
		{
			rb.mass += s / 20;
		}
	}

	void AddScale(Vector3 Scale)
	{
		//Adjust the camera to fit the larger sphere
		cam.offset += Vector3.Lerp(cam.transform.position, new Vector3(0f, Scale.y, -Scale.z), 2f);
		//Adjust size of cube
		transform.localScale += Vector3.Lerp(transform.localScale, Scale, 2f);
	}
}
