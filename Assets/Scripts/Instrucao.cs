using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Instrucao : MonoBehaviour {

    public Button proximo;
    public GameObject personagem1, personagem2, inst2;
    bool andar = true, andar2 = true;
    private void Start()
    {
        Button next = proximo.GetComponent<Button>();
        next.onClick.AddListener(Instrucao2);
    }
    private void Update()
    {
        if (andar)
        {
            personagem1.GetComponent<RectTransform>().anchoredPosition += new Vector2(3, 0);
            personagem1.GetComponent<RectTransform>().localScale = new Vector3(0.8034972f, 0.8034972f, 0.8034972f);
            if (personagem1.GetComponent<RectTransform>().anchoredPosition.x > 140)
                andar = false;
        }
        if (!andar)
        {
            personagem1.GetComponent<RectTransform>().anchoredPosition += new Vector2(-3, 0);
            personagem1.GetComponent<RectTransform>().localScale = new Vector3(-0.8034972f, 0.8034972f, 0.8034972f);
            if (personagem1.GetComponent<RectTransform>().anchoredPosition.x < -180)
                andar = true;
        }
        if (andar2)
        {
            personagem2.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 4);
            if (personagem2.GetComponent<RectTransform>().anchoredPosition.y > 160)
                andar2 = false;
        }
        if (!andar2)
        {
            personagem2.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -2);
            if (personagem2.GetComponent<RectTransform>().anchoredPosition.y < -9)
                andar2 = true;
        }
    }
    void Instrucao2()
    {
        inst2.SetActive(true);
        this.gameObject.SetActive(false);
    }
    }
