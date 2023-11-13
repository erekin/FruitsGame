using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellController : FruitsController
{
    public int BellID = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bell"))
        {
            mainManager.TouchFruits(BellID, this.gameObject);
        }
    }

}
