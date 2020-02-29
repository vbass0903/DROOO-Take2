using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileWidth;
  
	private Vector3 startPosition;
	private GameObject sub;

	void Start ()
	{
		startPosition = transform.position;
		sub = GameObject.Find("Submarine");
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileWidth);
		transform.position = startPosition + Vector3.left * newPosition;
	}
}