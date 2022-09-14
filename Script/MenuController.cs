using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //teste primeiro GIt
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Bt_Start()
    {
        Debug.Log("Mudou de Scena");
        Application.LoadLevel("Level1");
    }
    public void Bt_Option()
    {
        Debug.Log("Opçao ativada");
    }

    public void Bt_Exit()
    {
        Debug.Log("voce fecho o jogo");
        Application.Quit();
    }
}
