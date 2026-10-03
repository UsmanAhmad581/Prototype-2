using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    // Drag this animal's Slider (child UI object) into this field in the Inspector
    public Slider healthSliderAnimal;

    // How much food this animal needs before it's fully fed (set per animal type)
    public int amountToBeFed;

    // Tracks how much food it has received so far
    private int currentFedAmount = 0;


    void Start()
    {
        // Set up the slider's range based on this animal's needs
        healthSliderAnimal.maxValue = amountToBeFed;
        healthSliderAnimal.value = 0;

        // Hide the fill bar until the animal has been fed at least once
        healthSliderAnimal.fillRect.gameObject.SetActive(false);

    }

    // Called whenever a piece of food hits this animal
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            // Feed the animal by 1 unit
            FeedAnimal(1);

            // Remove the food object since it's been "eaten"
            Destroy(other.gameObject);
        }
    }

    // Increases how fed the animal is and updates the bar
    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;

        // Show the bar now that it's been fed
        healthSliderAnimal.fillRect.gameObject.SetActive(true);
        healthSliderAnimal.value = currentFedAmount;

        // Check if the animal is fully fed
        if (currentFedAmount >= amountToBeFed)
        {
            // Reward the player through the SpawnManager
            SpawnManager.Instance.UpdateScore(amountToBeFed);

            // Remove the animal after a short delay
            Destroy(gameObject, 0.1f);
        }
    }

}