using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Resetart_game()
    {
        SceneManager.LoadScene(0);
    }
}
