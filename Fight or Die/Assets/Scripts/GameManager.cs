using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
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

    [SerializeField] AudioClip[] start;
    [SerializeField] AudioClip[] won1, won2;
    [SerializeField] AudioClip[] ko;

    [SerializeField]  GameObject skeletonHead;
    [SerializeField] Slider playerOneSl, PlayerTwoSl;
    // Start is called before the first frame update

    public float matchTimer = 30f;
    bool matchDone;
    [SerializeField] WallDamage walls2;
    [SerializeField] WallDamage walls1;

    [SerializeField] Light2D[] MapLight;
    [SerializeField] AudioClip[] death;
    private void Start()
    {
        ShakeScreen.duration = 0.1f;
        discriptionText.text = "FIGHT!";
        discriptionText.enabled = true;
        StartCoroutine(disableText());
        gameState = gameState.starting;

      



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
        matchTimer -= Time.deltaTime;
        if(matchTimer <= 0 && matchDone == false)
        {
            walls1.move = true;
            walls2.move = true;
            matchDone = true;
 
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(0);
        }

        if(playerOneSl.value > PlayerTwoSl.value)
        {
            skeletonHead.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            skeletonHead.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

    public IEnumerator endGame(player playernum)
    {
        AudioManager.instance.playSound(death, 1);
        for (int i = 0; i < MapLight.Length; i++)
        {
            MapLight[i].enabled = false;
        }
        if(playernum == player.PlayerTwo)
        {
            scoreP1++;
            for (int i = 0; i < scoreP1; i++)
            {
                PlayerOnePoints[i].enabled = true;

            }
          
        }
        else
        {
            scoreP2++;
            for (int i = 0; i < scoreP2; i++)
            {
                PlayerTwoPoints[i].enabled = true;

            }
        }

        discriptionText.text = "KO!";
        discriptionText.enabled = true;

        AudioManager.instance.playSound(ko, 1);

        yield return new WaitForSeconds(5f);

        if(scoreP1 < 2 && scoreP2 <2)
        {
            SceneManager.LoadScene(Random.Range(2,4));

        }
        else
        {
            if (scoreP1 == 2)
            {
                discriptionText.text = "Payer 1 WON!";
                AudioManager.instance.playSound(won1, 1);
                StartCoroutine(resetGame());
            }
            else if (scoreP2 == 2)
            {
                discriptionText.text = "Payer 2 WON!";
                AudioManager.instance.playSound(won2, 1);

                StartCoroutine(resetGame());

            }
        }
    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2f);
        gameState = gameState.Combat;
        discriptionText.enabled = false;
        AudioManager.instance.playSound(start, 1);


    }
    IEnumerator resetGame()
    {
        yield return new WaitForSeconds(3f);
        scoreP1 = 0;
        scoreP2 = 0;
      Spawner.fighters = new List<GameObject>(1);
      SceneManager.LoadScene(1);
    }
}
