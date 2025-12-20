using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    [SerializeField]private ContainerCounter containerCounter;
    private Animator animator;

     private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Start()
    {
        containerCounter.OnOpenOrClose += ContainerCounter_OnOpenOrClose;
    }

    private void ContainerCounter_OnOpenOrClose(object sender, System.EventArgs e)
    {
        animator.SetTrigger("OpenClose");
    }
}
