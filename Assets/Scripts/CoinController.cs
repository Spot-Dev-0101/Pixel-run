﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public static void createCoin(Transform tf, GameObject coinObject){
        print("created normal coin");
        foreach (Transform child in tf)
        {
            print(child.name);
            if (child.tag == "CanHaveCoin")
            {

                int randInt = Random.Range(0, 10);

                if (randInt < 5)
                {//single coin
                    Instantiate(coinObject, child.position + new Vector3(0, 1, 0), Quaternion.identity);
                }

                if (randInt > 5)
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