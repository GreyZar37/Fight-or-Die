using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiController : MonoBehaviour
{
    public EventSystem system;
    public GameObject playerCharacter;
    public GameObject playerDoll;
    Transform dollPos;

    public int PlayerNum;

    public bool selected;
    public bool done;

    GameObject currentDoll;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerNum == 0)
        {
            dollPos = GameObject.FindGameObjectWithTag("P1").gameObject.transform;
            dir = new Vector3(0, 0, 0);
        }
        else
        {
            dollPos = GameObject.FindGameObjectWithTag("P2").gameObject.transform;
            dir = new Vector3(0, 180,0);

        }
    }

    // Update is called once per frame
    void Update()
    {

        if(selected == true)
        {
            Spawner.fighters[PlayerNum] = playerCharacter;

            if(currentDoll != null)
            {
                Destroy(currentDoll);
            }

            currentDoll = Instantiate(playerDoll, dollPos.transform.position, Quaternion.Euler(dir));

            selected = false;
            done = true;
        }

    }

    

}
