using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField] private Renderer _redLight;
    [SerializeField] private Renderer _yellowLight;
    [SerializeField] private Renderer _greenLight;
    [SerializeField] private TextMeshProUGUI _trafficLightText;

    private float _changeLightTime = 2f;
    private float _remainingTime;
    void Start()
    {
        _redLight.material.color = Color.clear;
        _yellowLight.material.color = Color.clear;
        _greenLight.material.color = Color.clear;
        StartCoroutine(ChangeLight(_changeLightTime));
    }

    private void Update()
    {
        _remainingTime -= Time.deltaTime;
        _trafficLightText.text = "Il semaforo si aggionerà tra " +
            _remainingTime + " secondi";
    }

    IEnumerator ChangeLight(float pause)
    {
        WaitForSeconds wfs = new WaitForSeconds(pause);
        _greenLight.material.color = Color.green;
        _remainingTime = pause;
        yield return wfs;
        _greenLight.material.color = Color.clear;
        _yellowLight.material.color = Color.yellow;
        _remainingTime = pause;
        yield return wfs;
        _yellowLight.material.color = Color.clear;
        _redLight.material.color = Color.red;
        _remainingTime = pause;
        yield return wfs;
        _redLight.material.color = Color.clear;
        _remainingTime = pause;
        yield return wfs;
        StartCoroutine(ChangeLight(_changeLightTime));
    }
}
