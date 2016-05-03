using UnityEngine;

public class InputController : MonoBehaviour {
	
	void Update () {
		var input = Input.GetMouseButton(0);

		if (input) {
			var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
			Debug.Log(hit.distance);
			if (hit.collider != null) {
				Debug.Log("hit not null");
				var pos = hit.collider.gameObject.GetComponent<PositionComponent>();
				Pools.pool.CreateEntity()
					.AddInput(pos.x, pos.y);
			}
		}
	}
}
