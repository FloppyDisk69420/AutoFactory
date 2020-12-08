using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
	private Controls uiControls;

	[SerializeField]
	public GameObject inventory;
	[SerializeField]
	public GameObject blueprinterUI;
	[SerializeField]
	public GameObject world;
	
	void Start() {
		uiControls = Controls.Instance;
		gameObject.SetActive(true);
		inventory.SetActive(false);
		blueprinterUI.SetActive(false);
	}
	
	void Update() {
		if (uiControls.ToggledInventory()) {
			inventory.SetActive(!inventory.activeSelf);
			world.SetActive(!blueprinterUI.activeSelf);
		}
		if (uiControls.ToggledInteract()) {
			blueprinterUI.SetActive(!blueprinterUI.activeSelf);
			world.SetActive(!blueprinterUI.activeSelf);
		}
	}
}
