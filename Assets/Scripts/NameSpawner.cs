using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSpawner : MonoBehaviour
{
    public GameObject namePrefab;
    List<NamePositioner> names = new List<NamePositioner>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddObject(string name, Transform tr)
    {
        GameObject newName = Instantiate(namePrefab, Vector3.zero, Quaternion.identity);
        newName.transform.SetParent(transform);
        NamePositioner namePositioner = newName.GetComponent<NamePositioner>();
        namePositioner.SetLabeledObject(tr);
        namePositioner.SetName(name);
        names.Add(namePositioner);
    }
}
