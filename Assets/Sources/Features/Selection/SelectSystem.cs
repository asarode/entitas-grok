using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class SelectSystem : IReactiveSystem {
	public TriggerOnEvent trigger {
		get {
			return Matcher.Select.OnEntityAdded();
		}
	}

	public void Execute(List<Entity> entities) {
		foreach (var e in entities) {
			var selectedMat = Resources.Load<Material>(Res.SelectedMaterial);
			e.view.gameObject.GetComponent<Renderer>().material = selectedMat;
		}
	}
}
