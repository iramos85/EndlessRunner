using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] environmentElement;
    [SerializeField] Transform referencePoint;
    [SerializeField] Vector3 offset;

    void Start()
    {
      StartCoroutine(CreateEnivronmentElement());
    }

    IEnumerator CreateEnivronmentElement()
    {
        Instantiate(environmentElement[Random.Range(0, environmentElement.Length)], referencePoint.position + offset, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3, 6));
        StartCoroutine(CreateEnivronmentElement());
    }
}

