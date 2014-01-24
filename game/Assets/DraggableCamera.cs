using UnityEngine;
using System.Collections;

public class DraggableCamera : MonoBehaviour
{
	private Vector3 velocity = Vector3.zero;
	private Vector3 targetPosition;
	public float dragSpeed = 5f;
	public float dampingSpeed = 0.07f;

	void Start()
	{
		targetPosition = transform.position;
	}

	void Update()
	{
		if (!Input.GetMouseButton(1) && Input.GetAxis("Mouse ScrollWheel") == 0)
			return;

		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
		float mouseScroll = Input.GetAxis("Mouse ScrollWheel") * 5;

		targetPosition -= new Vector3(mouseX, 0, mouseY) * dragSpeed;
		targetPosition.y += mouseScroll;

		if (transform.position != targetPosition)
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, dampingSpeed);
	}
}