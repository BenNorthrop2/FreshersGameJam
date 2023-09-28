using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cinemachine;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField] private float startingTime;

    [Header("Switch Settings")]
    [SerializeField] private GameObject catModel;
    [SerializeField] private GameObject ownerModel;
    [SerializeField] private GameObject catCamera;
    [SerializeField] private GameObject ownerCamera;

    private float timeRemaining;

    private void Awake() 
    {
        timeRemaining = startingTime;
        catModel.SetActive(true);
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if(timeRemaining == 0 && catModel.activeInHierarchy)
        {
            timeRemaining = 0;
            StartCoroutine(SwitchToOwner());
        }
        else if(timeRemaining == 0 && ownerModel.activeInHierarchy)
        {
            timeRemaining = 0;
            StartCoroutine(SwitchToCat());
        }
    }

    IEnumerator SwitchToCat()
    {
        catModel.SetActive(true);
        ownerCamera.SetActive(false);
        catCamera.SetActive(true);

        yield return new WaitForSeconds(5);

        ownerModel.SetActive(false);
        timeRemaining = startingTime;
    }

    IEnumerator SwitchToOwner()
    {
        ownerCamera.SetActive(true);
        catCamera.SetActive(false);
        ownerCamera.SetActive(true);

        yield return new WaitForSeconds(5);

        catModel.SetActive(false);
        timeRemaining = startingTime;
    }
}
