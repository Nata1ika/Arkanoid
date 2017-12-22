using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSlider : MonoBehaviour
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
		_controller.width = value;
		_text.text = ((int)value).ToString();
	}

	[SerializeField] Slider 			_slider;
	[SerializeField] Text				_text;
	[SerializeField] PlatformController	_controller;
}
