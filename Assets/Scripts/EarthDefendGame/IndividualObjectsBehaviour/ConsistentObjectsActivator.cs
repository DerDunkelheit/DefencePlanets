using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EarthDefendGame.IndividualObjectsBehaviour
{
    public class ConsistentObjectsActivator : MonoBehaviour
    {
        [SerializeField] private float activateRate = 0.05f;

        private readonly List<GameObject> childrenObject = new List<GameObject>();

        private void Awake()
        {
            foreach (Transform child in this.transform)
            {
                childrenObject.Add(child.gameObject);
            }
        }

        private void Start()
        {
            StartCoroutine(ChildrenActivationRoutine());
        }

        private IEnumerator ChildrenActivationRoutine()
        {
            foreach (var child in childrenObject)
            {
                child.SetActive(true);
                yield return new WaitForSeconds(activateRate);
            }
        }
    }
}
