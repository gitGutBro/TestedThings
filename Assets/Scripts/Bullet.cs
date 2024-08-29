using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public void OnTriggerEnter(Collider objectPoint)
    {
        if (objectPoint.CompareTag("Player"))
        {
            objectPoint.GetComponent<PlayerHealth>().TakeDamage(20);
            Destroy(objectPoint.gameObject);
            Destroy(this.gameObject);
        }
        else if(objectPoint.CompareTag("Enemy"))
        {
            objectPoint.GetComponent<EnemyHealth>().TakeDamage(20);
            Destroy(this.gameObject);
            
        }
    }
    
}
