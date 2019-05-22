using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public int verticalSpeed = 5;
    public int horizontalSpeed = 5;
    public Sprite plastic;
    public Sprite glass;
    public Sprite paper;
    public GameObject PaperObject;
    public GameObject PlasticObject;
    public GameObject GlassObject;
    private GameObject[] TrashObjects = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        PlasticObject.GetComponent<SpriteRenderer>().sprite = plastic;
        GlassObject.GetComponent<SpriteRenderer>().sprite = glass;
        PaperObject.GetComponent<SpriteRenderer>().sprite = paper;
        TrashObjects[0] = PaperObject;
        TrashObjects[1] = PlasticObject;
        TrashObjects[2] = GlassObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalData.TrashGameDropping && TrashObjects[0] != null && TrashObjects[1] != null && TrashObjects[2] != null)
        {
            GlobalData.TrashGameDropping = true;
            TrashObjects[Random.Range(0, 3)].GetComponent<FallingTrashScript>().Drop(verticalSpeed, horizontalSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GlobalData.RecyclingGameLifeCount <= 0)
        {
            GlobalData.KoinChange += GlobalData.RecyclingGameScore - 10;
        }
    }
}
