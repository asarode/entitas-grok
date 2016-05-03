using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class AddViewSystem : IReactiveSystem {
	public TriggerOnEvent trigger {
		get {
			return Matcher.Resource.OnEntityAdded();
		}
	}

	readonly Transform viewContainer = new GameObject("Views").transform;

	public void Execute(List<Entity> entities) {
		foreach (var e in entities) {
			var res = Resources.Load<GameObject>(e.resource.name);
			var gameObject = UnityEngine.Object.Instantiate(res);
			gameObject.transform.SetParent(viewContainer);
			e.AddView(gameObject);
		}
	}
}
