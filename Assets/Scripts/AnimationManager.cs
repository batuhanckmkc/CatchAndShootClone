using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject[] Confetti;
    [SerializeField] Animator playAnim;
    [SerializeField] Animator play5xAnim;
    //[SerializeField] Animator play5xAnim;
    private bool animationEnded;
    void Start()
    {
        for (int i = 0; i < Confetti.Length; i++)
        {
            Confetti[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Friend" || other.gameObject.tag == "Ball")
        {
            Debug.Log(BallCatcher.friendIndex);
            Debug.Log("Animation!!!");
            playAnim.SetBool("playAnim", true);
            play5xAnim.SetBool("play5xAnim", true);
            Confetti[BallCatcher.friendIndex].SetActive(true);
        }
    }
}
