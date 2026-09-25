using UnityEngine;

public class OnTriggerinteraction : MonoBehaviour
{

    [SerializeField] private Animator pikachuAnimator;
    private void OnTriggerEnter(Collider other)
    {
        pikachuAnimator.SetBool("IsInteracting", true);

    }

    private void OnTriggerExit(Collider other)
    {
        pikachuAnimator.SetBool("IsInteracting", false);

    }
}