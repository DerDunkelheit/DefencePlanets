using System.Collections;
using System.Collections.Generic;
using EarthDefendGame.GameControllers;
using EarthDefendGame.PlanetGuns;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private BasePlanetGun tripleGun = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameController.PlanetController.ActivePowerUp(tripleGun);
        }
    }
}
