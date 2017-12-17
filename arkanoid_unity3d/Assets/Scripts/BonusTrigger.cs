using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTrigger : MonoBehaviour
{
	public static System.Action<string> BonusEvent;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "platform")
		{
			if (BonusEvent != null)
			{
				BonusEvent(gameObject.name);
			}
			GameObject.Destroy(gameObject);
		}

		if (other.name == "downTrigger")
		{
			GameObject.Destroy(gameObject);
		}
	}
}
