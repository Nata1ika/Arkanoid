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
		_lifeController.LoseEvent += EndGame;
		WinEvent += EndGame;
		BonusTrigger.BonusEvent += Bonus;

		StartGame();
	}

	void OnDestroy()
	{
		GamePanel.StartGameEvent -= StartGame;
		_lifeController.LoseEvent -= EndGame;
		WinEvent -= EndGame;
		BonusTrigger.BonusEvent -= Bonus;
	}

	void StartGame()
	{
		count = 0;
		gameObject.SetActive(true);
		_fireBall = Random.Range(1, 99) < _fireBallBonusPercent;
		if (_text != null)
		{
			if (_fireBall)
			{
				_text.text = "fireball";
			}
			else
			{
				_text.text = "";
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ball")
		{
			ClashBall();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "ball")
		{
			ClashBall();
		}
	}

	void ClashBall()
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

	void Bonus(string name)
	{
		if (name.Contains("fireball"))
		{
			_fireBallTime = FIREBALL_MAXTIME;

			if (_collider == null)
			{
				_collider = gameObject.GetComponent<Collider2D>();
			}
			_collider.isTrigger = true;

			if (_image == null)
			{
				_image = gameObject.GetComponent<Image>();
			}
			_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0.5f);
		}
	}

	void Update()
	{
		if (_fireBallTime < 0 && _fireBallTime > -5) //сделать блоки без триггера
		{
			_collider.isTrigger = false;
			_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f);
			_fireBallTime = -10;
		}
		else if (_fireBallTime >= 0)
		{
			_fireBallTime -= Time.deltaTime;
		}
	}

	void EndGame()
	{
		if (_bonusObj != null)
		{
			GameObject.Destroy(_bonusObj);
			_bonusObj = null;
		}

		if (_collider == null)
		{
			_collider = gameObject.GetComponent<Collider2D>();
		}
		_collider.isTrigger = false;
		if (_image == null)
		{
			_image = gameObject.GetComponent<Image>();
		}
		_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f);

		_fireBallTime = -10;
	}

	[SerializeField] LifeController		_lifeController;
	[SerializeField] int 				_fireBallBonusPercent;
	[SerializeField] Text				_text;

	Collider2D				_collider;
	Image					_image;
	GameObject				_bonusObj; //если был создан бонус, то при окончании игры он будет уничтожен

	bool					_fireBall; //будет ли бонус фаербола при разрушении этого блока
	float					_fireBallTime = -10; //оставшееся время бонуса

	const float				FIREBALL_MAXTIME = 10f; //время для полученного бонуса
}
