using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private CuttingCounter cuttingCounter;

    private void Start()
    {
        cuttingCounter.OnObjectCut += CuttingCounter_OnObjectCut;
        image.fillAmount = 0;
        Hide();
    }

    private void CuttingCounter_OnObjectCut(object sender, CuttingCounter.OnObjectCutEventArgs e)
    {
        if (e.progressPercent == 0 || e.progressPercent == 1) 
        { 
            Hide();
        }
        else
        {
            Show();
            image.fillAmount = e.progressPercent;
        }   
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
