using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public static void createCoin(Transform tf, GameObject coinObject, GameObject enemy, GameObject powerup){
        print("created normal coin");
        foreach (Transform child in tf)
        {
            print(child.name);
            if (child.tag == "CanHaveCoin")
            {

                int randInt = Random.Range(0, 20);

                if(randInt > 10){
                    Instantiate(powerup, child.position + new Vector3(0, 1, 0), Quaternion.identity);
                }

                if (randInt < 5)
                {//single coin
                    Instantiate(coinObject, child.position + new Vector3(0, 1, 0), Quaternion.identity);
                } 

                if(randInt < 3){
                    Instantiate(enemy, child.position + new Vector3(0, 1, 0), Quaternion.identity);
                }

                if (randInt > 5 && randInt < 10)
                {//4x2 coin box
                    for (int x = 1; x < 4; x++)
                    {
                        for (int y = 1; y < 3; y++)
                        {
                            Instantiate(coinObject, child.position + new Vector3(x-2, y, 0), Quaternion.identity);
                        }
                    }
                }
            }

        }
    }

}
