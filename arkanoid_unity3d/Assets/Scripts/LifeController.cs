using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
	public System.Action LoseEvent;
	public static System.Action	RemoveLife;

	public int life
	{
		get
		{
			return _life;
		}
		set
		{
			_life = value;
			if (value >= 0)
			{
				_text.text = value.ToString();
			}
		}
	}

	void Start()
	{
		_ballDownTrigger.BallDownEvent += BallDown;
	}

	void OnDestroy()
	{
		_ballDownTrigger.BallDownEvent -= BallDown;
	}

	void BallDown()
	{
		life--;
		if (RemoveLife != null)
		{
			RemoveLife();
		}
		if (life < 0 && LoseEvent != null)
		{
			LoseEvent();
		}
	}

	[SerializeField] BallDownTrigger		_ballDownTrigger;
	[SerializeField] Text					_text;

	int 									_life;
}
