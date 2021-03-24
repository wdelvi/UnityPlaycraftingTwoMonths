using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookRotator : MonoBehaviour
{
	public float speed = 3;
	public List<Transform> childrenToRotate;
	public float maxLookRotation;
	public float minLookRotation;

	private Vector2 cameraRotation = new Vector2(0, 0);
	private Vector2 playerRotation = new Vector2(0, 0);

	void Update()
	{
		//First, we have to rotate the camera on both x and y
		cameraRotation.x += -Input.GetAxis("Mouse Y");
		cameraRotation.y += Input.GetAxis("Mouse X");

		cameraRotation.x = Mathf.Clamp(cameraRotation.x, minLookRotation, maxLookRotation);

		foreach (Transform childTransform in childrenToRotate)
        {
			childTransform.eulerAngles = (Vector2)cameraRotation * speed;
		}

		//Next, rotate the player on just x
		playerRotation.y += Input.GetAxis("Mouse X");

		transform.eulerAngles = (Vector2)playerRotation * speed;
	}
}

