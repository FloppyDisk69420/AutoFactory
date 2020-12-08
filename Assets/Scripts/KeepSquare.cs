using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSquare : MonoBehaviour {
	RectTransform form;
	
	void Start() {
		form = GetComponent<RectTransform>();
		float size = form.rect.width > form.rect.height ? form.rect.height : form.rect.width;
		form.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
		form.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
	}
}