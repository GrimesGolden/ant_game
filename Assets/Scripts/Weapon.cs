using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;
 //   EnemyHealth enemyHealth;
    void Awake()
    {
        // Get this main script from the parent (player)
        // This starter assets script is created by the FirstPersonController, a controller given by unity for moduler input binding. 
        starterAssetsInputs = gameObject.GetComponentInParent<StarterAssetsInputs>();
    }
    
    //void Start()
   // {   
        // One way of getting the script, though you could also just serialize. 
    //    enemyHealth = GameObject.FindAnyObjectByType<Robot>().GetComponent<EnemyHealth>(); 
  //  }
    void Update()
    {
        HandleShoot(); 
    }

    void HandleShoot()
    {
        // Use the cameras position (reference is precached by unity, no need to save variable)
        // Then cast in the forward direction from the camera
        // Use out keyword with raycast hit
        // Raycast will travel for a distance of Infinity (essentially no distance cap)

        // Note that RayCastHit will only return a value if we hit a collider. This prevents null ref

        RaycastHit hit;
        const int damageAmount = 45; 

        if(!starterAssetsInputs.shoot)
        {   
            // eliminate one indentation block
            return; 
        }

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity) && hit.collider.tag == "Enemy")
        {   
            // You could also just check that enemyHealth just returns null with if(enemyHealth) but I chose to use a tag. 
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageAmount);
        }
        starterAssetsInputs.ShootInput(false); // use the method to turn the public bool back to false. 
        // could also just have gotten the public shoot bool and turned it false, but using the method is clearer. 
    }
}
