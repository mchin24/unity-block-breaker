using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]    
public class PowerUpDrop : MonoBehaviour
{
    public BasePowerUp PowerUpPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(PowerUpPrefab, transform.position,  Quaternion.identity);
    }
}