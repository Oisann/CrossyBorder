﻿using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
	public GameObject carExplotion;
	GameMaster GM;
	public float moveSpeed = 6f;
	bool moveLeft;

	void Start ()
	{
		GM = GameObject.Find ("GameMaster").GetComponent<GameMaster> ();
	}

	void Update ()
	{
		if (!GM.gamePaused)
		{
			if (!moveLeft)
			{
				transform.Translate (Vector2.left * Time.deltaTime * moveSpeed);
			} else
			{
				transform.Translate (Vector2.right * Time.deltaTime * moveSpeed);
			}
		}


		if (transform.position.x > 30 || transform.position.x < -20)
		{
			DestroyImmediate (this.gameObject);
		}
	}

	public void MoveLeft ()
	{
		moveLeft = true;
	}

	public void MoveRight ()
	{
		moveLeft = false;

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !GM.gameReset)
		{
			GetComponent<CustomAudioSource> ().Play ();
			other.gameObject.GetComponent<PlayerController> ().Player.LoseLife ();
            
		}
	}

	public void DestroyCar ()
	{
		GameObject carExp = Instantiate (carExplotion, transform.position, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}

	public void DestroyCarScore ()
	{
        Vector3 carPos = Camera.main.WorldToScreenPoint(transform.position);
        GM.AddScore((moveSpeed == 6) ? 30 : 50, carPos.x, carPos.y); //30 score for normal cars, 50 score for FBI car
		GameObject carExp = Instantiate (carExplotion, transform.position, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}

}
