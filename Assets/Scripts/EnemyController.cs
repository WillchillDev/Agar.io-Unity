using UnityEngine;
using System;

public class EnemyController : MonoBehaviour {

	public GameObject player;
	public Rigidbody rb;
	public float size = 0;
	private float speed = 5;

	private float timeSinceEat;
	private float timeSinceDecay;

	private Vector3 newTransform;

	private GameObject target;

	void Start()
	{
		//Initialise Player Gameobject
		player = GameObject.FindGameObjectWithTag("Player");

		//Randomize spawn location of pickup
		newTransform.x = UnityEngine.Random.Range(-240, 240);
		newTransform.y = 1;
		newTransform.z = UnityEngine.Random.Range(-240, 240);
		//Apply new transform to object
		transform.position = newTransform;

		//Assign a random colour
		Color colour = new Color();
		//Randomise colour of pickup
		colour.r = UnityEngine.Random.Range(0.0f, 1.0f);
		colour.g = UnityEngine.Random.Range(0.0f, 1.0f);
		colour.b = UnityEngine.Random.Range(0.0f, 1.0f);
		//Apply colour of pickup
		GetComponent<Renderer>().material.color = colour;

		rb = GetComponent<Rigidbody>();

		timeSinceEat = 0;
		timeSinceDecay = 0;
	}

	void FixedUpdate()
	{
		//Movement()
		System.Random rand = new System.Random();
        bool x = rand.NextDouble() >= 0.5;
		bool z = rand.NextDouble() >= 0.5;
		int xint = 0;
		int zint = 0;
		if (x) xint = 1; else xint = -1;
		if (z) zint = 1; else zint = -1;
        Vector3 movement = new Vector3(xint * speed, 0f, zint * speed);
		rb.AddForce(movement);
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
				timeSinceDecay = 0;
			}
		}
	}

	/*void Movement()
	{
		//Find closest GameObject with the tag "Enemy" using Linq
		GameObject closestEnemy = GameObject.FindGameObjectsWithTag("Player").OrderBy(go => Vector3.Distance(go.transform.position, transform.position)).FirstOrDefault();
		
		//Check the size of the enemy
		if (closestEnemy.GetComponent<PlayerController>().size < size)
		{
			//Set the target to the weaker blob
			target = closestEnemy;
		}

		//Add force
		if (target != null)
		{
			rb.AddForce(target.transform.position * speed);
		} else
		{
			print("Target is null");
		}
	}*/

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

		//If the collision is a player
		if (other.gameObject.CompareTag("Player") && other.GetComponent<PlayerController>().size < size)
		{
			AddSize(other.GetComponent<PlayerController>().size * 2);
			other.gameObject.SetActive(false);

			//CODE TO LOCK CAMERA ONTO THE BLOB WHO KILLED THE PLAYER
			//other.GetComponent<PlayerController>().cam.target = this.gameObject;
			//If the eaten object is the camera's target, set this object to be the target
			if (player.GetComponent<PlayerController>().cam.target == other.gameObject)
			{
				player.GetComponent<PlayerController>().cam.target = this.gameObject;
			}
			timeSinceEat = 0;
		}
		//If the collision is an enemy
		if (other.gameObject.CompareTag("Enemy") && other.GetComponent<EnemyController>().size < size)
		{
			AddSize(other.GetComponent<EnemyController>().size * 2);

			if (player.GetComponent<PlayerController>().cam.target == other.gameObject)
			{
				player.GetComponent<PlayerController>().cam.target = this.gameObject;
			}
			Destroy(other.gameObject);
			timeSinceEat = 0;
		}
		
	}

	void AddSize(float s)
	{
		size += s;

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
		if (speed > 2)
		{
			speed -= s / 20;
		}
	}

	void AddScale(Vector3 Scale)
	{
		//Adjust size of sphere
		transform.localScale += Vector3.Lerp(transform.localScale, Scale, 2f);
	}
}
