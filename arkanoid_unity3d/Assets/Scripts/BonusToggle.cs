using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusToggle : MonoBehaviour
{
	void Start()
	{
		_bonusToggle.onValueChanged.AddListener(ChangeBonus);
		_bonusBlockToggle.onValueChanged.AddListener(ChangeBonusBlock);

		_bonusToggle.isOn = false;
		_bonusBlockToggle.isOn = false;
	}

	void OnDestroy()
	{
		_bonusToggle.onValueChanged.RemoveListener(ChangeBonus);
		_bonusBlockToggle.onValueChanged.RemoveListener(ChangeBonusBlock);
	}

	void ChangeBonus(bool value)
	{
		BonusTrigger.removeBonusAfterRemoveLife = value;
	}

	void ChangeBonusBlock(bool value)
	{
		BlockController.removeBonusAfterRemoveLife = value;
	}

	[SerializeField] Toggle		_bonusToggle;
	[SerializeField] Toggle		_bonusBlockToggle;
}
