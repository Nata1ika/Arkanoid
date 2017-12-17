using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : Panel
{
	public static System.Action StartGameEvent;

	public override void Start()
	{
		base.Start();
		_lifeController.LoseEvent += base.Hide;
		BlockController.WinEvent += base.Hide;
	}

	void OnDestroy()
	{
		_lifeController.LoseEvent -= base.Hide;
		BlockController.WinEvent -= base.Hide;
	}

	public override void Show()
	{
		base.Show();
		if (StartGameEvent != null)
		{
			StartGameEvent();
		}
	}

	[SerializeField] LifeController		_lifeController;
}
