
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public SceneFader fader;

    public Button[] levelButtons;//utinise l'inspecteur de unity pour lui donner la liste des boutons concernés

    public void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);///// ????
        //Désactive les buttons de level pas encore unlock
        for(int i = 0; i < levelButtons.Length; i++)
        {
            //Permet de savoir a partir de quel bouton on désactive
            if( i+1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
