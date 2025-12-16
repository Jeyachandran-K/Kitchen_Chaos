using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField]private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        Player.Instance.OnCounterSelected += Player_OnCounterSelected;
    }

    private void Player_OnCounterSelected(object sender, Player.OnCounterSelectedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
