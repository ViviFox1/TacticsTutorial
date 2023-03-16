using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Temporary state for demo. Allows user to select a unit for movement.
/// </summary>
public class SelectUnitState : BattleState
{
    protected override void OnMove(object sender, InfoEventArgs<Point> e)
    {
        SelectTile(e.info + pos);
    }

    protected override void OnFire(object sender, InfoEventArgs<int> e)
    {
        GameObject content = owner.currentTile.content;
        if (content != null)
        {
            owner.currentUnit = content.GetComponent<Unit>();
            owner.ChangeState<MoveTargetState>();
        }
    }
}
