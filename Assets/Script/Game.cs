using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	int banker = 0;
    int player = 0;
    int card = 0;
    int attempts = 5;
    bool bust = false;
	bool isGameOver = false;
	public float time = 5.0f;

	public AudioSource cardAudio;
	public AudioSource winAudio;

	public GameObject hud;
	public Button bttYes;
	public Button bttNot;
	public Button bttPlayAgain;
	public Text text;
	public Text textScorePlayer;
	public Text textScoreBanker;
	public Text timer;

	public GameObject blackSpace1;
	public GameObject blackSpace2;
	public GameObject blackSpace3;
	public GameObject blackSpace4;
	public GameObject blackSpace5;

	public GameObject cardBlack1;
	public GameObject cardBlack2;
	public GameObject cardBlack3;
	public GameObject cardBlack4;
	public GameObject cardBlack5;
	public GameObject cardBlack6;
	public GameObject cardBlack7;
	public GameObject cardBlack8;
	public GameObject cardBlack9;
	public GameObject cardBlack10;
	public GameObject cardBlack11;
	public GameObject cardBlack12;
	public GameObject cardBlack13;

	// Start is called before the first frame update
	void Start()
    {
        banker = getCard(15, 21);
		hud.SetActive(false);
		textScorePlayer.text = player.ToString();
	}

    // Update is called once per frame
    void Update()
    {
		if (timeCountDown() == true && attempts > 0)
		{
			if(isGameOver == false) { 
				nextRound();
			}
		}
		
		if(isGameOver == true || attempts == 0)
		{
			gameOver();
		}

		if (bust == true)
		{
			cleanHud("You lost,\n your hand got over 21.");
		}

	}

	bool timeCountDown() {

		if (time > 0.0f)
		{
			time -= Time.deltaTime;
			timer.text = Convert.ToInt32(Math.Floor(time)).ToString();
			return false;
		}
		else {
			time = 5.0f;
			return true;			
		}

	}

	void cleanHud(string message) {
		hud.SetActive(true);
		text.text = message;		
		bttYes.gameObject.SetActive(false);
		bttNot.gameObject.SetActive(false);
		timer.gameObject.SetActive(false);
		bttPlayAgain.gameObject.SetActive(true);
	}

	public void nextRound() {
		hud.SetActive(true);
		timer.gameObject.SetActive(false);
		text.text = "Your hand is " + player + ". Do you want a card ?";		
	}

    static int getCard(int low, int up)
    {
        return UnityEngine.Random.Range(low, up + 1);
    }

	public void yesAnswer() {		
		card = getCard(1, 13);
				
		player += card;
		textScorePlayer.text = player.ToString();
		hud.SetActive(false);

		switch (attempts)
		{
			case 5:
				createNewCard(card, blackSpace1);
				break;
			case 4:
				createNewCard(card, blackSpace2);
				break;
			case 3:
				createNewCard(card, blackSpace3);
				break;
			case 2:
				createNewCard(card, blackSpace4);
				break;
			case 1:
				createNewCard(card, blackSpace5);
				break;
		}

		timer.gameObject.SetActive(true);
		attempts--;
		time = 5.0f;
		
		if(player > 21)
		{
			bust = true;
			textScoreBanker.text = banker.ToString();
		}
	}

	public void gameOver() {
		isGameOver = true;
		textScoreBanker.text = banker.ToString();
		
		if (player > banker)
		{
			winAudio.Play();
			cleanHud("You Won !");			
		}
		else if (banker > player)
		{
			winAudio.Play();
			cleanHud("You Lost !");			
		}
		else
		{
			winAudio.Play();
			cleanHud("That was a Draw !");			
		}
	}

	void createNewCard(int card, GameObject blackSpace)
	{
		switch (card)
		{
			case 1:
				GameObject card1Black = Instantiate(cardBlack1) as GameObject;
				card1Black.transform.position = blackSpace.transform.position;
				break;
			case 2:
				GameObject card2Black = Instantiate(cardBlack2) as GameObject;
				card2Black.transform.position = blackSpace.transform.position;
				break;
			case 3:
				GameObject card3Black = Instantiate(cardBlack3) as GameObject;
				card3Black.transform.position = blackSpace.transform.position;
				break;
			case 4:
				GameObject card4Black = Instantiate(cardBlack4) as GameObject;
				card4Black.transform.position = blackSpace.transform.position;
				break;
			case 5:
				GameObject card5Black = Instantiate(cardBlack5) as GameObject;
				card5Black.transform.position = blackSpace.transform.position;
				break;
			case 6:
				GameObject card6Black = Instantiate(cardBlack6) as GameObject;
				card6Black.transform.position = blackSpace.transform.position;
				break;
			case 7:
				GameObject card7Black = Instantiate(cardBlack7) as GameObject;
				card7Black.transform.position = blackSpace.transform.position;
				break;
			case 8:
				GameObject card8Black = Instantiate(cardBlack8) as GameObject;
				card8Black.transform.position = blackSpace.transform.position;
				break;
			case 9:
				GameObject card9Black = Instantiate(cardBlack9) as GameObject;
				card9Black.transform.position = blackSpace.transform.position;
				break;
			case 10:
				GameObject card10Black = Instantiate(cardBlack10) as GameObject;
				card10Black.transform.position = blackSpace.transform.position;
				break;
			case 11:
				GameObject card11Black = Instantiate(cardBlack11) as GameObject;
				card11Black.transform.position = blackSpace.transform.position;
				break;
			case 12:
				GameObject card12Black = Instantiate(cardBlack12) as GameObject;
				card12Black.transform.position = blackSpace.transform.position;
				break;
			case 13:
				GameObject card13Black = Instantiate(cardBlack13) as GameObject;
				card13Black.transform.position = blackSpace.transform.position;
				break;
		}

		cardAudio.Play();
	}

	public void playAgain() {
		SceneManager.LoadScene(1);
	}

}
