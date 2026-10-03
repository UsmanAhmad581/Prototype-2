using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SpawnManager : MonoBehaviour
{   
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float spawnRangeTopZ = 19;
    private float spawnRangeBottomZ = 4;
    private float spawnPosX = 30;
    public GameObject[] animalPrefabs;

    private float startDelayTop = 1;
    private float spawnIntervalTop = 3f;

    private float startDelayLeft = 2;
    private float spawnIntervalLeft = 4f;

    private float startDelayRight = 3;
    private float spawnIntervalRight = 7f;
    
    public TextMeshProUGUI scoreText;
    private float score = 0;


    public InputAction spawnAction;
    public static SpawnManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        Instance = this;

        spawnAction.Enable();
        InvokeRepeating("SpawnRandomAnimalTop", startDelayTop, spawnIntervalTop);
        InvokeRepeating("SpawnRandomAnimalLeft", startDelayLeft, spawnIntervalLeft);
        InvokeRepeating("SpawnRandomAnimalRight", startDelayRight, spawnIntervalRight);
    }
    
    public void UpdateScore(float scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score; 
    }
   

    void SpawnRandomAnimalTop(){
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    void SpawnRandomAnimalLeft(){
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(spawnRangeBottomZ, spawnRangeTopZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 270, 0));
    }
    void SpawnRandomAnimalRight(){
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(spawnRangeBottomZ, spawnRangeTopZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));
    }
}
