using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpeedSlider : MonoBehaviour
{
	void Start()
	{
		_slider.onValueChanged.AddListener(ChangeValue);
		ChangeValue(_slider.value);
	}

	void OnDestroy()
	{
		_slider.onValueChanged.RemoveListener(ChangeValue);
	}

	void ChangeValue(float value)
	{
		_controller.ballSpeedKoef = (int)value;
		_text.text = ((int)value).ToString();
	}

	[SerializeField] Slider 			_slider;
	[SerializeField] Text				_text;
	[SerializeField] BallController		_controller;
}
