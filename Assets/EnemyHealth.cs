using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    float currentHitPoints;

    void OnEnable()
    {
        currentHitPoints = hitPoints;
    }
    public void TakeDamage(float damage)
    {
        GetComponentInParent<EnemyAI>().OnDamageTaken();
        currentHitPoints -= damage;
        if(currentHitPoints <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

}
