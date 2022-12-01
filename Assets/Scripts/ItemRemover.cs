using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    // Start is called before the first frame update
    void OnBecameInvisible()
    {
         if(this.gameObject.name == "Fireball(Clone)" || this.gameObject.name == "Rock(Clone)" || this.gameObject.name == "Stalagmite(Clone)" || this.gameObject.name == "Coin(Clone)" )
         {
            Destroy(this.gameObject);
         }
         else if(this.gameObject.name != "Background")
         {
            Destroy(this.gameObject);
         }
    }
}