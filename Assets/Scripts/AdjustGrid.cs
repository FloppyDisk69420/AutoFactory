using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class AdjustGrid : MonoBehaviour {	
	private static int rows = 4;
	private static int columns = 9;
	public struct Padding {
		public float left;
		public float right;
		public float bottom;
		public float top;
		public Padding(float l, float r, float b, float t) {
			left = l;
			right = r;
			bottom = b;
			top = t;
		}
	};
	[SerializeField]
	public Padding padding;
	private RectTransform[] slots;

	void Start() {
		slots = GetInventorySlots();
		RectTransform rect = GetComponent<RectTransform>();
		Vector2 res = new Vector2(rect.rect.width, rect.rect.height);
		padding = new Padding(res.x / 50, res.x / 50, res.y / 50, res.y / 50);
		Vector2 overlaySize = new Vector2(res.x - padding.left - padding.right, res.y - padding.top - padding.bottom);
		float colSize = overlaySize.x / columns;
		float rowSize = overlaySize.y / rows;
		float size = (colSize < rowSize) ? colSize : rowSize;

		Vector2 center = new Vector2 (
			(colSize - size) / 2, 
			(rowSize - size) / 2
		);

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				slots[i * columns + j].anchoredPosition = new Vector3 (
					(j * colSize) + center.x + padding.left,
					(-i * rowSize) - center.y - padding.top
				);
				slots[i * columns + j].sizeDelta = new Vector2(size, size);
				slots[i * columns + j].pivot = new Vector2(0, 1);
			}
		}
	}

	RectTransform[] GetInventorySlots() {
		RectTransform[] children = GetComponentsInChildren<RectTransform>();
		RectTransform[] invSlots = new RectTransform[rows * columns];
		int index = 0;
		for (int i = 0; i < children.Length; i++) {
			if (children[i].CompareTag("InventorySlot")) {
				invSlots[index] = children[i];
				index++;
			}
		}
		return invSlots;
	}
}
