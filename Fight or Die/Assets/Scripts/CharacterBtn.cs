using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CharacterBtn : MonoBehaviour
{
    public GameObject Character;
    public GameObject CharacterDooll;
    public GameObject currentObj;

    private void Start()
    {
    }
    private void Update()
    {

    }
    public void click(PlayerInput player)
    {
        player.GetComponent<UiController>().playerCharacter = Character;
        player.GetComponent<UiController>().playerDoll = CharacterDooll;

        player.GetComponent<UiController>().selected = true;


    }

}
