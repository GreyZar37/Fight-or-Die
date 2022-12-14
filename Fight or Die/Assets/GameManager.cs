using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum gameState
{
   starting, Combat, ending, end
}
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI discriptionText;
    public Image[] PlayerOnePoints;
    public Image[] PlayerTwoPoints;

    public static bool gameEnding;

    public static gameState gameState;

    public static int scoreP1, scoreP2;

    // Start is called before the first frame update

    private void Start()
    {
        discriptionText.text = "FIGHT!";
        discriptionText.enabled = true;
        StartCoroutine(disableText());
        gameState = gameState.starting;

        if(scoreP1 == 2)
        {
            discriptionText.text = "JACOB WON!";
            StartCoroutine(resetGame());
        }
        else if(scoreP2 == 2)
        {
            discriptionText.text = "SIMON WON!";
            StartCoroutine(resetGame());

        }



        if (scoreP1 > 0) {
            for (int i = 0; i < scoreP1; i++)
            {
                PlayerOnePoints[i].enabled = true;

            }
        }

        if (scoreP2 > 0)
        {

            for (int i = 0; i < scoreP2; i++)
            {

                PlayerTwoPoints[i].enabled = true;
            }
        }

        
    }
    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator endGame(player playernum)
    {
        if(playernum == player.PlayerTwo)
        {
            scoreP1++;
            discriptionText.text = "SIMON GOT SHIT ON";
            discriptionText.enabled = true;

        }
        else
        {
            scoreP2++;
            discriptionText.text = "JACOB GOT SHIT ON!!";
            discriptionText.enabled = true;
        }

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);

    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2f);
        gameState = gameState.Combat;
        discriptionText.enabled = false;


    }
    IEnumerator resetGame()
    {
        yield return new WaitForSeconds(3f);
        scoreP1 = 0;
        scoreP2 = 0;
        SceneManager.LoadScene(0);
    }
}
