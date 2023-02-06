using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class MainMenu : MonoBehaviour
{
    GameObject lastselect;
    
  

    [SerializeField]  UiController uiControllerP1;
    [SerializeField] UiController uiControllerP2;

    void Start()
    {
        Spawner.fighters.Clear();
        Spawner.fighters.Add(null);
        Spawner.fighters.Add(null);


        lastselect = new GameObject();
    }
 
    // Update is called once per frame
    void Update ()
    {
        
        if(uiControllerP1.done && uiControllerP2.done)
        {
            SceneManager.LoadScene(Random.Range(2, 4));
        }

        /*
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);

        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;

        }
        */
        

    }


}

