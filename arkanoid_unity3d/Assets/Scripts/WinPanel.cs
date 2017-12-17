using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : Panel
{
	public override void Start()
	{
		base.Start();
		BlockController.WinEvent += base.Show;
	}

	void OnDestroy()
	{
		BlockController.WinEvent -= base.Hide;
	}
}
