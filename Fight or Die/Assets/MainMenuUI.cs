using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public AudioClip selectSound, clickSound;

   
    
    public void loadScene(int sceneNum)
    {
        StartCoroutine(loadSceneTimer(sceneNum));
    }
    public void quit()
    {
        AudioManager.instance.SFX.PlayOneShot(clickSound);

        Application.Quit();
    }
    public void highlight()
    {
        AudioManager.instance.SFX.PlayOneShot(selectSound);
    }

    IEnumerator loadSceneTimer(int sceneNum)
    {
        AudioManager.instance.SFX.PlayOneShot(clickSound);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneNum);
    }
}
