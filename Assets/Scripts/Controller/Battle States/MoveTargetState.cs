using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// State which occurs when unit is selected for an action.
/// </summary>
public class MoveTargetState : BattleState
{
    List<Tile> tiles;

    /// <summary>
    /// Adds functionality to enter to identify the movement type of the moving unit. Also highlights tiles within range.
    /// </summary>
    public override void Enter()
    {
        base.Enter();
        Movement mover = owner.currentUnit.GetComponent<Movement>();
        tiles = mover.GetTilesInRange(board);
        board.SelectTiles(tiles);
    }

    /// <summary>
    /// Tiles in range are deselected on state exit.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
        board.DeSelectTiles(tiles);
        tiles = null;
    }

    protected override void OnMove(object sender, InfoEventArgs<Point> e)
    {
        SelectTile(e.info + pos);
    }

    protected override void OnFire(object sender, InfoEventArgs<int> e)
    {
        if (tiles.Contains(owner.currentTile))
            owner.ChangeState<MoveSequenceState>();
    }
}