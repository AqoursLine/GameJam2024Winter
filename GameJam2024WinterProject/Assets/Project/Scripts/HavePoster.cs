using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HavePoster : MonoBehaviour {
	//動かすポスター
	private GameObject poster = null;

	private void Start() {
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
			if (hit.collider) {
				poster = hit.collider.gameObject;
			}
		}

		if (Input.GetMouseButton(0)) {
			if (poster != null) {
				Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				pos.z = 0;
				poster.transform.position = pos;
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			if (poster != null) {
				poster = null;
			}
		}

	}
}
