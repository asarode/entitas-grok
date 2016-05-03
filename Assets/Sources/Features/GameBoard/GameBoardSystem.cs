using Entitas;
using System.Collections.Generic;
using UnityEngine;


public class GameBoardSystem : IInitializeSystem, IReactiveSystem, ISetPool {
	public TriggerOnEvent trigger {
		get {
			return Matcher.GameBoard.OnEntityAdded();
		}
	}

	private Pool _pool;
//	private Group _gameBoardElements;

	public void SetPool(Pool pool) {
		_pool = pool;
//		_gameBoardElements = _pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position));
	}

	public void Initialize() {
		var gameBoard = _pool.SetGameBoard(20, 10).gameBoard;
		for (int row = 0; row < gameBoard.rows; row++) {
			for (int col = 0; col < gameBoard.columns; col++) {
				_pool.CreateEntity()
					.IsGameBoardElement(true)
					.AddPosition(col, row)
					.AddResource(Res.GridBlock);
			}
		}
	}

	public void Execute(List<Entity> entities) {
		
	}
}
