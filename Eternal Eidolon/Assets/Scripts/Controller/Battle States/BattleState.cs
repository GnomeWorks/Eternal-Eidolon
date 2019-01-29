using UnityEngine;
using System.Collections;
public abstract class BattleState : State 
{
	protected BattleController owner;
	public CameraRig cameraRig { get { return owner.cameraRig; }}
	public Board board { get { return owner.board; }}
	public LevelData levelData { get { return owner.levelData; }}
	public Transform tileSelectionIndicator { get { return owner.tileSelectionIndicator; }}
	public Point pos { get { return owner.pos; } set { owner.pos = value; }}

	protected virtual void Awake ()
	{
		owner = GetComponent<BattleController>();
	}

	protected override void AddListeners ()
	{
		InputController.moveEvent += OnMove;
		InputController.fireEvent += OnFire;
	}
	
	protected override void RemoveListeners ()
	{
		InputController.moveEvent -= OnMove;
		InputController.fireEvent -= OnFire;
	}
	protected virtual void OnMove (object sender, InfoEventArgs<Point> e)
	{
	
	}
	
	protected virtual void OnFire (object sender, InfoEventArgs<int> e)
	{
	
	}
	protected virtual void SelectTile (Point p)
	{
		if (pos == p || !board.tiles.ContainsKey(p))
		{
			/*
			EE-DPR-0001
				Some tile movement is not allowed
			RESOLUTION
				Point.cs overloaded == operator was checking for
				a.x == b.x
				and
				a.x == b.y
				which was resulting in unexpected behavior.

			Debug.Log("FLIP: " + p.x + ", " + p.y + "; pos: " + pos.x + ", " + pos.y);

			if(pos == p)
			{
				Debug.Log("how the flip are these even equal?!?");
			}

			if(!board.tiles.ContainsKey(p))
			{
				Debug.Log("somehow doesn't flipping exist?!?");
			}
			*/

			return;
		}

		pos = p;
		tileSelectionIndicator.localPosition = board.tiles[p].center;
	}
}