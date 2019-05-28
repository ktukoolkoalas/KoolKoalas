using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAsLastSiblingController : MonoBehaviour
{
    public GameObject LastObject;

    public void SetAsLast()
    {
        LastObject.transform.SetAsLastSibling();
    }
}
