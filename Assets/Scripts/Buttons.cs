using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void StartGame() {
        SceneManager.LoadScene("02_Game");
    }

    public void QuitGame() {
        Debug.Log("quit request");
    }

    public void Back() {
        SceneManager.LoadScene("01_Menu");

    }
}
