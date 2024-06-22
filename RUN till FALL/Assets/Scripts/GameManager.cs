using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        StartCoroutine(IntroTransition());
    }
    IEnumerator IntroTransition()
    {
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("gotomenu");
        SceneManager.LoadScene(1);
    }
}
