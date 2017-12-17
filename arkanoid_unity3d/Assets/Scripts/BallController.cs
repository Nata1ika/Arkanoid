using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
	void Start()
	{
		_ballDownTrigger.BallDownEvent += SetPassive;
		BlockController.WinEvent += SetPassive;
	}

	void OnDestroy()
	{
		_ballDownTrigger.BallDownEvent -= SetPassive;
		BlockController.WinEvent -= SetPassive;
	}

	void GetBallComponent()
	{
		_ballRect = _ball.GetComponent<RectTransform>();
		_ballTransform = _ball.GetComponent<Transform>();
		_ballRigitbody = _ball.GetComponent<Rigidbody2D>();
		_ballCollider = _ball.GetComponent<CircleCollider2D>();
		_ballScale = _ballTransform.localScale;
	}

	public int ballSpeedKoef { get; set; }

	public float size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
			if (_ballRect == null || _ballCollider == null)
			{
				GetBallComponent();
			}

			_ballRect.sizeDelta = new Vector2(value, value);
			_ballCollider.radius = size;
			_ballCollider.offset = new Vector2(0, value);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (_isActive && other.gameObject.name == "platform")
		{
			float percentPosition = _platformController.GetPosition(_ballTransform.position.x);
			SetActive(new Vector2(percentPosition * 3, 2f));
		}
	}


	void Update()
	{
		if (!_isActive && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
		{
			_isActive = true;

			if (_ballRigitbody == null || _ballTransform == null)
			{
				GetBallComponent();
			}

			SetActive(new Vector2(1, 3));

			_ballTransform.SetParent(_parentActiveposition, true);
			_ballTransform.localScale = _ballScale;
		}
	}

	void SetActive(Vector2 force)
	{
		_ballRigitbody.Sleep();
		_ballRigitbody.WakeUp();
		_ballRigitbody.AddForce(ballSpeedKoef * 1000 * force.normalized);
	}

	void SetPassive()
	{
		if (!_isActive)
		{
			return;
		}

		if (_ballTransform == null)
		{
			GetBallComponent();
		}
		_isActive = false;
		_ballTransform.SetParent(_parentStartPosition);
		_ballTransform.localScale = _ballScale;
		_ballTransform.localPosition = Vector3.zero;
		_ballRigitbody.Sleep();
	}

	[SerializeField] GameObject			_ball;

	[SerializeField] Transform			_parentStartPosition;
	[SerializeField] Transform			_parentActiveposition;

	[SerializeField] BallDownTrigger	_ballDownTrigger;
	[SerializeField] PlatformController	_platformController;


	float						_size;
	bool 						_isActive = false;

	RectTransform				_ballRect;
	Transform					_ballTransform;
	Rigidbody2D					_ballRigitbody;
	CircleCollider2D			_ballCollider;
	Vector3						_ballScale;
}
