using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class PlayAgainEmpty : MonoBehaviour
{   
    public string playScene, menuScene, gameOverScene, howToPlayScene, settingsScene;


    public void playButtonSceneChange()
    {
        SceneManager.LoadScene(playScene);
    }
    public void menuButtonSceneChange()
    {
        SceneManager.LoadScene(menuScene);
    }
    public void settingsButtonSceneChange()
    {
        SceneManager.LoadScene(settingsScene);
    }
    public void gameOverSceneChange()
    {
        SceneManager.LoadScene(gameOverScene);
    }
    public void howToPlaySceneChange()
    {
        SceneManager.LoadScene(howToPlayScene);
    }
}
