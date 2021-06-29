using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ship>())
        {
            other.GetComponent<Destroing>().Destroy();
            EndGame.S.Death();
        }
    }
}
