using UnityEngine;
using System.Collections;

public class AddCards : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject crd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject cards = Instantiate(crd);
            cards.name = "" + i;
            cards.transform.SetParent(puzzleField, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
