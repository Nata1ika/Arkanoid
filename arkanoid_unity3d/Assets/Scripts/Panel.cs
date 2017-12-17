using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
	public virtual void Start()
	{
		if (_showOnStart)
		{
			Show();
		}
	}

	public virtual void Show()
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
