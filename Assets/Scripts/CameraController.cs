using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player;
	public float smoothing = 5f;
    public Vector3 offset;
	public float tiltAngle = 30.0f;

	void Start()
	{
		offset = transform.position - player.transform.position;
	}

	void FixedUpdate()
	{
		//transform.position = target.transform.position + offset;
		Vector3 desiredPosition = player.transform.position + offset;
		transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothing);
		transform.LookAt(player.transform.position);
	}
}
