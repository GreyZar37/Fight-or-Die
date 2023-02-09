using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public static List<GameObject> fighters = new List<GameObject>(2);
    [SerializeField] PlayerInputManager manager;
    GameObject P1playerPref, P2playerPref;
    public LayerMask P1Layer, P2Layer;
    private void Awake()
    {

        if (fighters != null)
        {
            P2playerPref = Instantiate(fighters[1], spawnLocations[1].transform.position, Quaternion.identity);

            P1playerPref = Instantiate(fighters[0], spawnLocations[0].transform.position, Quaternion.identity);


            setPlayer();
        }
       

    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {

        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);
        playerInput.gameObject.GetComponent<BasePlayer>().StartPos = spawnLocations[playerInput.playerIndex].transform;

    }

    void setPlayer()
    {
        P1playerPref.tag = "P1";
        P2playerPref.tag = "P2";
        P1playerPref.layer = LayerMask.NameToLayer("Player1");
        P2playerPref.layer = LayerMask.NameToLayer("Player2");




    }
}
