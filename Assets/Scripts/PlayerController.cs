using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
	[SerializeField]
	public float gravity = -9.81f;
	[SerializeField]
	public float jumpForce = 2f;
	[SerializeField]
	public float speed = 14f;
	[SerializeField]
	public float sensitivity = 10f;

	private Controls playerControls;
	private CharacterController controller;
	private bool isGrounded;
	private float velocity;

	private float rotation = 0f;
	private Camera playerCamera;
	private Transform playerTransform;

	void Start() {
		controller = GetComponent<CharacterController>();
		playerCamera = GetComponentInChildren<Camera>();
		playerTransform = GetComponent<Transform>();
		playerControls = Controls.Instance;
		velocity = 0f;
		isGrounded = true;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void DoPlayerMovement() {
		Vector2 movement = playerControls.GetMovement();
		Vector3 move = playerTransform.right * movement.x + playerTransform.forward * movement.y;
		controller.Move(move * Time.deltaTime * speed);
	}

	void DoPlayerJump() {
		if (isGrounded && velocity < 0) velocity = 0f;
		
		if (playerControls.Jumped() && isGrounded) {
			velocity += Mathf.Sqrt(jumpForce * -3.0f * gravity);
		}
		velocity += gravity * Time.deltaTime;
		controller.Move(Vector3.up * velocity * Time.deltaTime);
	}

	void DoPlayerLook() {
		Vector2 mouseDelta = playerControls.GetLook();
		Vector2 look = mouseDelta * sensitivity * Time.deltaTime;

		rotation -= look.y;
		rotation = Mathf.Clamp(rotation, -90f, 90f);

		playerCamera.transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
		playerTransform.Rotate(Vector3.up * look.x);
	}

	void DoPlayerInteract() {
		
	}

	void Update() {
		isGrounded = controller.isGrounded;
		if (playerControls.IsRunning()) {
			speed = 21f;
		}
		else {
			speed = 14f;
		}

		DoPlayerInteract();
		DoPlayerMovement();
		DoPlayerJump();
		DoPlayerLook();
	}
}
