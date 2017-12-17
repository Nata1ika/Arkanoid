using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour
{
	static int maxCount = 0;
	static int count = 0;
	public static System.Action WinEvent;

	void Start()
	{
		maxCount++;
		GamePanel.StartGameEvent += StartGame;
		WinEvent += Win;
	}

	void OnDestroy()
	{
		GamePanel.StartGameEvent -= StartGame;
		WinEvent -= Win;
	}

	void StartGame()
	{
		count = 0;
		gameObject.SetActive(true);
		_fireBall = Random.Range(1, 99) < _fireBallBonusPercent;
		if (_fireBall && _text != null)
		{
			_text.text = "fireball";
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ball")
		{
			count++;
			gameObject.SetActive(false);
			if (count == maxCount)
			{
				if (WinEvent != null)
				{
					WinEvent();
				}
			}
			else if (_fireBall)
			{
				_bonusObj = (GameObject)GameObject.Instantiate(Resources.Load<Object>("Bonus/fireball"));
				Transform tr = _bonusObj.transform;
				tr.SetParent(gameObject.transform.parent);
				tr.position = gameObject.transform.position;
				tr.localScale = Vector3.one;
			}
		}
	}

	void Win()
	{
		if (_bonusObj != null)
		{
			GameObject.Destroy(_bonusObj);
			_bonusObj = null;
		}
	}

	[SerializeField] int 	_fireBallBonusPercent;
	[SerializeField] Text	_text;

	bool					_fireBall;
	GameObject				_bonusObj;
}
