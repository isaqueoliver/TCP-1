using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teste : MonoBehaviour {
    public Button teste;
    Color novoJogo_Original;
    MeshRenderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        novoJogo_Original = m_Renderer.material.color;
    }
    private void OnMouseOver()
    {
        //teste.GetComponent<Image>().color = Color.yellow;
        m_Renderer.material.color = Color.yellow;
    }
    private void OnMouseExit()
    {
        m_Renderer.material.color = novoJogo_Original;
    }
}
