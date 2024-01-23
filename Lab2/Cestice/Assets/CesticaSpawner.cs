using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CesticaSpawner : MonoBehaviour
{
    AudioSource audioSource;

    public GameObject CesticaPrefab;

    public float spawnRate;

    public int MaxCestica;

    public Queue<GameObject> CesticaQ;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = this.GetComponent<AudioSource>();

        //audioSource.Play();

        CesticaQ = new Queue<GameObject>();

        for (int i = 0; i < MaxCestica; i++) {
            GameObject NewCube = Instantiate(CesticaPrefab, this.transform.position, Quaternion.identity);
            NewCube.transform.parent = this.transform;
            CesticaQ.Enqueue(NewCube);
            NewCube.SetActive(false);
        }

        StartCoroutine(LansirajCesticu());




        
    }

    IEnumerator LansirajCesticu() {

        GameObject TrenutnaCestica = CesticaQ.Dequeue();

        TrenutnaCestica.SetActive(true);

        TrenutnaCestica.GetComponent<Cestica>().resetScale();

        TrenutnaCestica.transform.position = this.transform.position;

        Vector3 sila = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

        TrenutnaCestica.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

        TrenutnaCestica.GetComponent<Rigidbody>().AddForce(sila);

        CesticaQ.Enqueue(TrenutnaCestica);

        yield return new WaitForSeconds(1 / spawnRate);

        StartCoroutine(LansirajCesticu());

    }


}
