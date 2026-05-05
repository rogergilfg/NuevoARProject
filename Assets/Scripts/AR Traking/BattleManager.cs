using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> peleadores;
    [SerializeField] private bool peleaEnCurso;
    [SerializeField] private bool segundaPeleaEnCurso;
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

        if(peleadores.Count >= 2 && !peleaEnCurso)
        {
            peleaEnCurso = true;
            StartCoroutine(StartBattle(0, 1));
        }
        if (peleadores.Count == 4 && !segundaPeleaEnCurso)
        {
            segundaPeleaEnCurso = true;
            StartCoroutine(StartBattle(2, 3));
        }
    }

    IEnumerator StartBattle(int indexA, int indexB)
    {
        peleadores[indexA].transform.LookAt(peleadores[indexB].transform);
        peleadores[indexB].transform.LookAt(peleadores[indexA].transform);

        yield return new WaitForSeconds(tiempoEspera);

        int perdedor = Random.Range(0, 2);

        int ganador = 1 - perdedor;


        Debug.Log("Animator perdedor: " + peleadores[perdedor].GetComponentInChildren<Animator>());

        peleadores[ganador].GetComponentInChildren<Animator>().SetBool("Win", true);
        peleadores[perdedor].GetComponentInChildren<Animator>().SetBool("Die", true);


    }
}
