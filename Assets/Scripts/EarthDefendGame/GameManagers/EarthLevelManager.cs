using System;
using EarthDefendGame.GameControllers;
using UnityEngine;

namespace EarthDefendGame.GameManagers
{
    public class EarthLevelManager : MonoBehaviour
    {

        private void Start()
        {
            GameController.instance.DisableControllers();
        }
    }
}
