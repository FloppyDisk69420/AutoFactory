using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	private static Controls _instance;
	private enum Layer { Menu, Game, Inventory, Interactable }
	private Layer layer = Layer.Game;
	private InputManager inputActions;
	
	[SerializeField]
	public Transform player;
	[SerializeField]
	public Transform blueprinter;
	[SerializeField]
	public float interactDistance = 4f;

	public static Controls Instance {
		get { return _instance;	}
	}
	
	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		}
		else {
			_instance = this;
		}
		inputActions = new InputManager();
	}

	private void OnEnable() {
		inputActions.Enable();
	}

	private void OnDisable() {
		inputActions.Disable();
	}

	public Vector2 GetMovement() {
		if (layer == Layer.Game) {
			return inputActions.Player.Movement.ReadValue<Vector2>();
		}
		return Vector2.zero;
	}

	public Vector2 GetLook() {
		if (layer == Layer.Game) {
			return inputActions.Player.Look.ReadValue<Vector2>();
		}
		return Vector2.zero;
	}

	public bool Jumped() {
		if (layer == Layer.Game) {
			return inputActions.Player.Jump.triggered;
		}
		return false;
	}

	public bool ToggledInventory() {
		if (layer == Layer.Inventory || layer == Layer.Game) {
			if (inputActions.UI.ToggleInventory.triggered) {
				layer = (layer == Layer.Game) ? Layer.Inventory : Layer.Game;
				Cursor.lockState = (layer == Layer.Game) ? CursorLockMode.Locked : CursorLockMode.None;
				return true;
			}
		}
		return false;
	}

	public bool IsRunning() {
		if (layer != Layer.Game) {
			return false;
		}
		return inputActions.Player.Run.triggered; /// --------------------DOES NOT WORK CURRENTLY-------------------------
	}

	public bool ToggledInteract() {
		if (layer == Layer.Game || layer == Layer.Interactable) {
			if (inputActions.UI.Interact.triggered) {
				Vector3 dist3 = blueprinter.position - player.position;
				dist3.x *= dist3.x;
				dist3.y *= dist3.y; // Squares all dimensions;
				dist3.z *= dist3.z;
				float dist = dist3.x + dist3.y + dist3.z;
				if (dist < Mathf.Pow(interactDistance, 3)) {
					layer = (layer == Layer.Game) ? Layer.Interactable : Layer.Game;
					Cursor.lockState = (layer == Layer.Game) ? CursorLockMode.Locked : CursorLockMode.None;
					return true;
				}
			}
		}
		return false;
	}

	public void Log(string message) {
		Debug.Log("working...");
		Debug.Log(message);
	}
}
