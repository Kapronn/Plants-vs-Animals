using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
   [SerializeField] private int starCost = 100;
   [SerializeField] private float health = 100f;
   [SerializeField] private float noRegenHealth = 200f;
   

   public void HealthRegen(float healthRegeneration) //using with event.
   {
      if (health >= noRegenHealth)
      {
         return;
      }
      else if (health <noRegenHealth)
      {
         health += healthRegeneration;
      }
   }
   public void DealDamage(float damage)
   {
      health -= damage;
      if (health <= 0)
      {
         Destroy(gameObject);
      }
   }
   public void AddStars(int amount) //using with event.
   {
      FindObjectOfType<StarDisplay>().AddStars(amount);
   }

   public int GetStarCost()
   {
      return starCost;
   }
}
