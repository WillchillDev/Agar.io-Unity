using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public PlayerController player;
    public Vector3 offset;
	
	void Start()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
	}
}
