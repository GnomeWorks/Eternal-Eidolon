using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CutSceneState : BattleState 
{
	DialogController conversationController;
	ConversationData data;

	protected override void Awake ()
	{
		base.Awake ();
		conversationController = owner.GetComponentInChildren<DialogController>();
		data = Resources.Load<ConversationData>("Conversations/IntroScene");
	}

	protected override void OnDestroy ()
	{
		base.OnDestroy ();
		if (data)
			Resources.UnloadAsset(data);
	}

	public override void Enter ()
	{
		base.Enter ();
		conversationController.Show(data);
	}

	protected override void AddListeners ()
	{
		base.AddListeners ();
		DialogController.completeEvent += OnCompleteConversation;
	}

	protected override void RemoveListeners ()
	{
		base.RemoveListeners ();
		DialogController.completeEvent -= OnCompleteConversation;
	}

	protected override void OnFire (object sender, InfoEventArgs<int> e)
	{
		base.OnFire (sender, e);
		conversationController.Next();
	}

	void OnCompleteConversation (object sender, System.EventArgs e)
	{
		owner.ChangeState<SelectUnitState>();
	}
}