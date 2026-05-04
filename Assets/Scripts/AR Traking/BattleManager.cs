using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> peleadores;
    [SerializeField] private bool peleaEnCurso;
    [SerializeField] private float tiempoEspera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFighter(GameObject fighter)
    {
        Debug.Log("Fighter añadido: " + fighter.name);
        peleadores.Add(fighter);

        if(peleadores.Count >= 2 )
        {
            peleaEnCurso = true;
            StartCoroutine(StartBattle());
        }
    }

    IEnumerator StartBattle()
    {
        Debug.Log("Batalla iniciada!");

        Debug.Log("Fighter 0: " + peleadores[0].transform.position);
        Debug.Log("Fighter 1: " + peleadores[1].transform.position);

        peleadores[0].transform.LookAt(peleadores[1].transform);
        peleadores[1].transform.LookAt(peleadores[0].transform);

        yield return new WaitForSeconds(tiempoEspera);

        int perdedor = Random.Range(0, 2);

        peleadores[perdedor].GetComponent<Animator>().SetTrigger("Die");
    }
}
