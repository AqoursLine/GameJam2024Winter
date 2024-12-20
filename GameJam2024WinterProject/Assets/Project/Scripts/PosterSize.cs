using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterSize : MonoBehaviour {
	//抜ける範囲の参照元
	[SerializeField]
	private GameObject storage;

	//ゴミ箱
	[SerializeField]
	private GameObject trash;

	[SerializeField]
	private Vector2 largeSize;

	[SerializeField]
	private Vector2 normalSize;

	[SerializeField]
	private Vector2 smallSize;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		//ストレージより上に行ったら
		bool isStorageUpper = false;

		isStorageUpper = transform.position.y > (storage.transform.position.y + storage.transform.localScale.y * 0.5f);

		bool outTrash = IsOutsideBounds2D(transform.position, trash.transform);

		if (isStorageUpper) {
			transform.localScale = largeSize;
		} else if (!outTrash) {
			transform.localScale = smallSize;
		} else {
			transform.localScale = normalSize;
		}
	}

	private bool IsOutsideBounds2D(Vector3 position, Transform boundsObject) {
		// オブジェクトBの2Dサイズと中心を計算
		Vector3 size = boundsObject.localScale; // オブジェクトBのサイズ (Scale)
		Vector3 center = boundsObject.position; // オブジェクトBの中心位置

		// 境界の範囲を計算 (xとyのみ)
		float minX = center.x - size.x / 2;
		float maxX = center.x + size.x / 2;
		float minY = center.y - size.y / 2;
		float maxY = center.y + size.y / 2;

		// オブジェクトAが範囲外にいる場合にtrueを返す
		return position.x < minX || position.x > maxX ||
			   position.y < minY || position.y > maxY;
	}
}
