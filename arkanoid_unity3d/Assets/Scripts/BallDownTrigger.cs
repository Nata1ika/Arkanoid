using System.Collections;
using UnityEngine;

public class BallDownTrigger : MonoBehaviour
{
	public System.Action BallDownEvent;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "ball" && BallDownEvent != null)
		{
			BallDownEvent();
		}
		if (other.tag == "bonus")
		{
			GameObject.Destroy(other.gameObject);
		}
	}
}
