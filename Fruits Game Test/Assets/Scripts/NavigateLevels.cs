using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsNavigate : MonoBehaviour
{
    public void openLevel(int levelID) {
        string levelName = "Level" + levelID;
        SceneManager.LoadScene(levelName);
    }

    public void backButton() {
        SceneManager.LoadSceneAsync("HomeScreen");
    }

}
