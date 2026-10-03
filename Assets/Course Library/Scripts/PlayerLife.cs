using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLife : MonoBehaviour
{  
    public Slider healthSliderPlayer;
    private int totalLives = 5;

    public TextMeshProUGUI GameOverText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        GameOverText.gameObject.SetActive(false);
        healthSliderPlayer.maxValue = totalLives;
        healthSliderPlayer.value = totalLives;

        healthSliderPlayer.fillRect.gameObject.SetActive(true);
    }
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal")){
            // If the player collides with the animal, remove a life
             UpdateLives(1);
          
            // Remove the animal from the scene
            Destroy(other.gameObject);
        }
    }
    public void UpdateLives(int livesToRemove){
        healthSliderPlayer.value -= livesToRemove;

        if(healthSliderPlayer.value <= 0){
            GameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
