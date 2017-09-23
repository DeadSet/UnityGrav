using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {


    public float startingHealth = 1f;

    private float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void ApplyDamage(float damageInput)
    {
        currentHealth -= damageInput;
    }
}

