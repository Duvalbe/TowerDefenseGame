using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;

	// Use this for initialization
	public void Play () {
        sceneFader.FadeTo(levelToLoad);
	}
	
	// Update is called once per frame
	public void Quit () {
        Debug.Log("Quit");
        Application.Quit();
	}
}
