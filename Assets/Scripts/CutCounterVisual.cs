using UnityEngine;

public class CutCounterVisual : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnObjectCut += CuttingCounter_OnObjectCut;
    }

    private void CuttingCounter_OnObjectCut(object sender, CuttingCounter.OnObjectCutEventArgs e)
    {
        animator.SetTrigger("Cut");
    }
}
