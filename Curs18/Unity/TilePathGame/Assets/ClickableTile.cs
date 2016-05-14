using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableTile : MonoBehaviour {

	public int tileX;
	public int tileY;
	public TileMap map;

	void OnMouseUp() {
		Debug.Log ("Click!");

		if(EventSystem.current.IsPointerOverGameObject())
			return;

		map.GeneratePathTo(tileX, tileY);
	}

}
