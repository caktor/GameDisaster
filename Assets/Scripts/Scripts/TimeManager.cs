using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;
	private float countingTime;

	private Text theText;

	public GameObject gameOverScreen;

	public PlayerController player;


	// Use this for initialization
	void Start () 
	{
		countingTime = startingTime;

		theText = GetComponent<Text> ();

		player = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		countingTime -= Time.deltaTime;

		if (countingTime <= 0) 
		{
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

		theText.text = "" + Mathf.Round (countingTime);
	}
}
