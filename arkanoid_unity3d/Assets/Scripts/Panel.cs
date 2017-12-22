using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
	void Start()
	{
		if (_showOnStart)
		{
			Show();
		}
	}

	public void Show()
	{
		_parent.SetActive(true);
	}

	public void Hide()
	{
		_parent.SetActive(false);
	}

	[SerializeField] GameObject		_parent;
	[SerializeField] bool			_showOnStart;
}
