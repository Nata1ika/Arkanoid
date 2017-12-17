using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : Panel
{
	public override void Start()
	{
		base.Start();
		_lifeController.LoseEvent += base.Show;
	}

	void OnDestroy()
	{
		_lifeController.LoseEvent -= base.Show;
	}

	[SerializeField] LifeController		_lifeController;
}
