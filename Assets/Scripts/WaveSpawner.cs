using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [Header("Money")]
    public int defaultIncome = 100;
    public float incomeTimer = 3f;
    MoneyEditor ME;
    public GameObject moneyEditor;

    public Transform enemyPrefab;
    public Transform redEnemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float enemySpawnerIntervals = 0.5f;

    public Bee standardBee;
    public Bee superBee;
    
    public TextMeshProUGUI waveTimer;
    public TextMeshProUGUI AdditionalMoney;
    public TextMeshProUGUI Kills;
    public TextMeshProUGUI IncomeTimer;
    public TextMeshProUGUI Round;
    public float beginTimer = 10f;

    [Header("Private Variables")]
    private float countdown;
    private float moneyCountDown;
    private int waveIndex = 0;
    private int additionalIncome = 0;
    public int kills = 0;
    public int index = 0;

    private void Start()
    {
        ME = moneyEditor.GetComponent<MoneyEditor>();
        countdown = beginTimer;
    }
    void Update()
    {        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            index++;
        }

        if (moneyCountDown <= 0f)
        {
            moneyCountDown = incomeTimer;
            Income();
        }

        waveTimer.text = Mathf.Ceil(countdown).ToString(); // This will cut off all decimal numbers and keep it a whole number
        AdditionalMoney.text = "Additional $ " + additionalIncome;
        IncomeTimer.text = "+ $100 Timer: " + Mathf.Ceil(moneyCountDown).ToString();
        Kills.text = "Kills: " + kills;
        Round.text = "Wave " + index.ToString();

        SavedValues();

        // Time.deltaTime is the amount of time passed since the last time we drew a frame.
        // This will reduce countdown by 1 every sec.
        countdown -= Time.deltaTime;
        moneyCountDown -= Time.deltaTime;
    }

    public void SavedValues()
    {
        if(kills > PlayerPrefs.GetInt("Kills", 0))
        {
            PlayerPrefs.SetInt("KILLS", kills);
        }
        if (index > PlayerPrefs.GetInt("Waves", 0))
        {
            PlayerPrefs.SetInt("WAVES", index);
        }

        PlayerPrefs.SetInt("CURRENTKILLS", kills);
        PlayerPrefs.SetInt("CURRENTWAVES", index);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            // Spawn Enemy, then wait .5f seconds and repeat for however many times the waveNumber is
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnerIntervals);
        }
        for (int i = 0; i < waveIndex / 2; i++)
        {
            // Spawn Enemy, then wait .5f seconds and repeat for however many times the waveNumber is
            SpawnRedEnemy();
            yield return new WaitForSeconds(enemySpawnerIntervals);
        }
    }

    public void AdditionalIncome(int amount)
    {
        additionalIncome += amount;      
    }

    public void TotalKills(int x)
    {
        kills += x;
    }

    void Income()
    {
        ME.AddMoney(defaultIncome + additionalIncome);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnRedEnemy()
    {
        Instantiate(redEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
