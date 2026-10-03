using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {   
        ScoreManager.Instance.AddScore(1);
        Destroy(gameObject);
    }
}
