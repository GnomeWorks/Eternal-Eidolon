using UnityEngine;
using System.Collections;
public class SelectUnitState : BattleState 
{
	protected override void OnMove (object sender, InfoEventArgs<Point> e)
	{
		SelectTile(e.info + pos);
	}
	
	// this is not "on fire," it means "on the fire button"
	protected override void OnFire (object sender, InfoEventArgs<int> e)
	{
		GameObject content = owner.currentTile.content;

		if (content != null)
		{
			owner.currentUnit = content.GetComponent<Unit>();
			owner.ChangeState<MoveTargetState>();
		}
	}
}