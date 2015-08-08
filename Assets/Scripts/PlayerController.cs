using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;

	public Text SizeText;
	public float size = 0;

	public CameraController cam;

    void Start()
    {
        rb = GetComponent <Rigidbody>();
		SizeText.text = "Size: " + size.ToString();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);

        rb.AddForce(movement);
    }

	void OnTriggerEnter(Collider other)
	{
		//If the  collision is a pickup
		if (other.gameObject.CompareTag("Pickup"))
		{
			SizeManager(1.0f);
			//Destroy the object. This kills the object and all of its children.
			Destroy(other.gameObject);
		}
	}

	void SizeManager(float s)
	{
		size += s;
		SizeText.text = "Size: " + size.ToString();

		//Adjust the camera to fit the larger sphere
		cam.offset += new Vector3(0f, s, -s);
		//Increase the size
		transform.localScale += new Vector3(s, s, s); //Sally's silly snakes slithered sideways, shifting Sharon's silly sausages. SSS

		//Adjust the speed for slower movement
		rb.mass = size / 20;
	}
}
