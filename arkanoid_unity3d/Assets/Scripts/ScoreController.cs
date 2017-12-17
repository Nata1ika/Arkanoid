using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	void Start()
	{
		_lifeController.LoseEvent += FinishGame;
		BlockController.WinEvent += FinishGame;
		BlockController.DestroyEvent += DestoyBlock;
	}

	void OnDestroy()
	{
		_lifeController.LoseEvent -= FinishGame;
		BlockController.WinEvent -= FinishGame;
		BlockController.DestroyEvent -= DestoyBlock;
	}

	void DestoyBlock()
	{
		_allScore++;
		_currentScore++;

		_allScoreText.text = _allScore.ToString();
		_currentScoreText.text = _currentScore.ToString();
	}

	void FinishGame()
	{
		_currentScore = 0;
		_currentScoreText.text = _currentScore.ToString();
	}

	[SerializeField] LifeController	_lifeController;
	[SerializeField] Text			_allScoreText;
	[SerializeField] Text			_currentScoreText;

	int _allScore;
	int _currentScore;
}
