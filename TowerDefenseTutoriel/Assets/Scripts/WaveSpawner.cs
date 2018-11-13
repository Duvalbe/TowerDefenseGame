/*
 * Instantiation des spawns des Ennemies
 */
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;//coordonnée du spawner, start node dans unity mais peut etre changer

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;// temps avant la première vague, après sera égale au temps entre les vagues
    private int waveIndex = 0;// nombre d'ennemi qui vont spawn
    public Text waveCountdownText;

    public GameManager gameManager;

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;//Stop le script
        }
        //Manager pour la gestion du spawn   
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime; //Time.deltaTime = temps passer depuis la dernière frame

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = String.Format("{0:00.00}", countdown);
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
        
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveIndex++;
    }

    /* 
     * creation d'un enemi 
     */
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}

//"StartCoroutine(IEnumerator)" demarre une coroutine, parfait pour le comportement sur plusieur frame
//"Coroutine" class : c'est une fonction qui peut suspendre son exécution (Yield) jusqu'a un moment définis
//"Ienumerator" Interfaces 'occupe de simple itération sur une collection non générique
