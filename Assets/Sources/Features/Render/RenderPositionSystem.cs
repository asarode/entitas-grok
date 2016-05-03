using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class RenderPositionSystem : IReactiveSystem {
	public TriggerOnEvent trigger {
		get {
			return Matcher.AllOf(Matcher.Position, Matcher.View).OnEntityAdded();
		}
	}

	public void Execute(List<Entity> entities) {
		foreach (var e in entities) {
			var pos = e.position;
			// Converting from grid position where (0,0) is the top left corner, to game position
			var x = (float)pos.x - 9.5f;
			var y = (float)pos.y - 4.5f;
			e.view.gameObject.transform.position = new Vector3(x, y, 0f);
		}
	}
}
