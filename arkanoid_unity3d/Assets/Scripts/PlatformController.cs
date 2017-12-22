using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformController : MonoBehaviour
{
	void Start()
	{
		_koef = _canvas.referenceResolution.x / Camera.main.pixelWidth;
	}

	public float width
	{		
		get
		{
			return _standartWidth;
		}
		set
		{
			_standartWidth = value;
			_platformRect.sizeDelta = new Vector2(value, _platformRect.sizeDelta.y);
			_collider.size = new Vector2(value, _collider.size.y);
		}
	}



	void Update()
	{
		float x = Mathf.Clamp(Input.mousePosition.x * _koef, _leftPosition.position.x * _koef + width / 2f, _rightPosition.position.x * _koef - width / 2f);
		_platform.position = new Vector3(x / _koef, _platform.position.y, _platform.position.z);
	}

	[SerializeField] CanvasScaler	_canvas;

	[SerializeField] Transform		_platform;
	[SerializeField] RectTransform	_platformRect;
	[SerializeField] BoxCollider2D	_collider;

	[SerializeField] Transform		_leftPosition;
	[SerializeField] Transform		_rightPosition;

	float _standartWidth;
	float _koef = 1f;
}
