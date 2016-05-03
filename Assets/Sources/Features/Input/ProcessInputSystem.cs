using Entitas;
using System.Collections.Generic;
using UnityEngine;


public class ProcessInputSystem : IReactiveSystem, ISetPool {
	public TriggerOnEvent trigger {
		get {
			return Matcher.Input.OnEntityAdded();
		}
	}

	Pool _pool;

	public void SetPool(Pool pool) {
		_pool = pool;
	}

	public void Execute(List<Entity> entities) {
		var inputEntity = entities.SingleEntity();
		var input = inputEntity.input;

		if (isInGameboard(input.x, input.y)) {
			var e = _pool.gameBoardCache.grid[input.x, input.y];
			if (e != null) {
				e.isSelect = true;
			}
		}

		_pool.DestroyEntity(inputEntity);
	}

	bool isInGameboard(int x, int y) {
		return (x >= 0 && x < _pool.gameBoard.columns)
			&& (y >= 0 && y <_pool.gameBoard.rows);
	}
}
