using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Runs when this object's trigger collider touches another collider
    private void OnTriggerEnter(Collider other)
    {
        // If the food hits the Player, take away a life
        // if (other.CompareTag("Player"))
        // {
        //     SpawnManager.Instance.updateLive(1);
        //     Destroy(gameObject);
        // }
        // If the food hits an Animal, feed it and give the player points
        if (other.CompareTag("Animal"))
        {
            SpawnManager.Instance.UpdateScore(5);
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(gameObject);
        }
    }
}