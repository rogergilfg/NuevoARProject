using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> peleadores;
    [SerializeField] private bool peleaEnCurso;
    [SerializeField] private bool segundaPeleaEnCurso;

    [Header("Tiempo Peleas")]
    [SerializeField] private float Pelea1;
    [SerializeField] private float Pelea2;

    [Header("SFX")]
    [SerializeField] private AudioClip punch;
    [SerializeField] private AudioClip victory;

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
        peleadores.Add(fighter);

        if(peleadores.Count >= 2 && !peleaEnCurso)
        {
            peleaEnCurso = true;
            StartCoroutine(StartBattle(0, 1, Pelea1));
            AudioManager.instance.PlaySFX(punch, 0.1f, true, transform.position);
        }
        if (peleadores.Count == 4 && !segundaPeleaEnCurso)
        {
            segundaPeleaEnCurso = true;
            StartCoroutine(StartBattle(2, 3, Pelea2));
            AudioManager.instance.PlaySFX(punch, 0.1f, true, transform.position);
        }
    }

    IEnumerator StartBattle(int indexA, int indexB, float tiempoDeEspera)
    {
        peleadores[indexA].transform.LookAt(peleadores[indexB].transform);
        peleadores[indexB].transform.LookAt(peleadores[indexA].transform);

        yield return new WaitForSeconds(tiempoDeEspera);

        int perdedor = Random.Range(0, 2);
        int ganador = 1 - perdedor;

        if(perdedor == 0)
        {
            perdedor = indexA;
            ganador = indexB;
        }
        else
        {
            perdedor = indexB;
            ganador = indexA;
        }

        AudioManager.instance.PlaySFX(victory, 0.4f, false, transform.position);
        peleadores[ganador].GetComponentInChildren<Animator>().SetBool("Win", true);
        peleadores[perdedor].GetComponentInChildren<Animator>().SetBool("Die", true);
    }
}
