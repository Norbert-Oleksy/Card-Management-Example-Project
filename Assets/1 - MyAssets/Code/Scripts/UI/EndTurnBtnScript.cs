using UnityEngine;
using UnityEngine.UI;

public class EndTurnBtnScript : MonoBehaviour
{
    private Button _button;
    public void BtnOnClick()
    {
        _button.interactable = false;
        TestManager.Instance.EndCurrentState();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_button.interactable && TestManager.Instance.IsPlayerTurn) _button.interactable = true;
        if(_button.interactable && !TestManager.Instance.IsPlayerTurn) _button.interactable = false;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }
}
