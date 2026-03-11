using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Renderer[] renderers= new Renderer[0];
    public static GameManager Instance;
    public Material cardBackMaterial;
    private void OnMouseDown()
    {
        Debug.Log("Mouse down on GameManager");
    }
}
