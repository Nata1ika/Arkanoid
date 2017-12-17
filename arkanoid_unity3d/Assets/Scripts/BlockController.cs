using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
	static int maxCount = 0;
	static int count = 0;
	public static System.Action WinEvent;

	void Start()
	{
		maxCount++;
		GamePanel.StartGameEvent += StartGame;
	}

	void StartGame()
	{
		count = 0;
		gameObject.SetActive(true);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ball")
		{
			count++;
			gameObject.SetActive(false);
			if (count == maxCount && WinEvent != null)
			{
				WinEvent();
			}
		}
	}
}
