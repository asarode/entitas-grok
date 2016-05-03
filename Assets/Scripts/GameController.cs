using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

	Systems _systems;
		
	void Start () {
		Random.seed = 42;

		_systems = createSystems(Pools.pool);
		_systems.Initialize();
	}

	void Update () {
		_systems.Execute();
	}

	Systems createSystems(Pool pool) {
		return new Feature("Systems")
			.Add(pool.CreateSystem<GameBoardSystem>())
			.Add(pool.CreateSystem<AddViewSystem>())
			.Add(pool.CreateSystem<RenderPositionSystem>());
	}	
}
