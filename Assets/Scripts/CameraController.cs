using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject target;
	public float smoothing = 2f;
    public Vector3 offset;

	void Start()
	{
	}

	void FixedUpdate()
	{
		if(GameObject.FindGameObjectWithTag("Player") == target)
		{
			offset = new Vector3(0.0f, target.GetComponent<PlayerController>().size / 2 + 15, -target.GetComponent<PlayerController>().size / 2- 20);
		} else {
			offset = new Vector3(0.0f, target.GetComponent<EnemyController>().size  / 2 + 15, -target.GetComponent<EnemyController>().size / 2 - 20);
		}
			
			transform.position = target.transform.position + offset;
			//transform.LookAt(target.transform.position);
	}
}
