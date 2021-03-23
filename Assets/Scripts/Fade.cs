using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleDeath()
    {
        animator.SetTrigger("Blackout");
        StartCoroutine(WaitBeforeRestart());
    }

    public void HandleLevelCompletion()
    {
        animator.SetTrigger("Blackout");
        StartCoroutine(WaitBeforeLoad());
    }

    IEnumerator WaitBeforeLoad()
    {
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<DataKeeper>()?.Count();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator WaitBeforeLoad(int index)
    {
        yield return new WaitForSeconds(1.0f);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(index);
    }

    IEnumerator WaitBeforeRestart()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
