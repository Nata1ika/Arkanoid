using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
	[HideInInspector]
	public int speed = 1000;
	public float size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
			_ballRect.sizeDelta = new Vector2(value, value);
			_collider.radius = size;
			_collider.offset = new Vector2(0, value);
		}
	}


	void Update()
	{
		if (!_isActive && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
		{
			_isActive = true;
			_rigitbody.AddForce(speed * new Vector2(1f, 3f));
		}
		else if (_isActive)
		{
			
		}
	}

	[SerializeField] Transform 			_parentFirstState;
	[SerializeField] CircleCollider2D	_collider;
	[SerializeField] RectTransform		_ballRect;
	[SerializeField] Rigidbody2D		_rigitbody;

	float						_size;
	bool 						_isActive = false;
}
