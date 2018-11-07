/*
 * Instantiation des spawns des Ennemies
 */
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;//Prefab de l'ennemi qu'on veut faire spawn
    public Transform spawnPoint;//coordonnée du spawner, start node dans unity mais peut etre changer

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;// temps avant la première vague, après sera égale au temps entre les vagues
    private int waveIndex = 0;// nombre d'ennemi qui vont spawn
    public Text waveCountdownText;

    void Update()
    {
        //Manager pour la gestion du spawn   
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; //Time.deltaTime = temps passer depuis la dernière frame

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    /* 
     * responsable du spawn d'un groupe d'ennemi
     */
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    /* 
     * creation d'un enemi 
     */
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

//"StartCoroutine(IEnumerator)" demarre une coroutine, parfait pour le comportement sur plusieur frame
//"Coroutine" class : c'est une fonction qui peut suspendre son exécution (Yield) jusqu'a un moment définis
//"Ienumerator" Interfaces 'occupe de simple itération sur une collection non générique
