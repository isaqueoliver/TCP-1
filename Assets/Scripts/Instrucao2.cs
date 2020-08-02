using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Instrucao2 : MonoBehaviour
{

    public Button menu;
    public GameObject backMenu;
    public GameObject balao1, balao2, balao3, perdeu;
    float animacao = 0;
    bool ani1 = true;

    private void Start()
    {
        Button voltarMenu = menu.GetComponent<Button>();
        voltarMenu.onClick.AddListener(BackMenu);
    }
    void Update()
    {
        animacao += Time.deltaTime;
        if (ani1)
        {

            if (animacao >= 1.5f)
                balao1.SetActive(false);
            if (animacao >= 3)
                balao2.SetActive(false);
            if (animacao >= 4.5f)
            {
                balao3.SetActive(false);

                if(animacao >= 6)
                    perdeu.SetActive(true);
                if(animacao >= 7)
                    ani1 = false;
            }
        }
        if(!ani1)
        {
            perdeu.SetActive(false);
            balao1.SetActive(true);
            balao2.SetActive(true);
            balao3.SetActive(true);
            animacao = 0;
            ani1 = true;
        }

    }
    void BackMenu()
    {
        backMenu.SetActive(true);
        this.gameObject.SetActive(false);

    }
}