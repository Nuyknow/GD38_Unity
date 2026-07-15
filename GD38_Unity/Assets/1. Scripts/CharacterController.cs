using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public Button[] buttons;
    public ButtonAction CharacterButtonAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttons[0].onClick.AddListener(CharacterButtonAction.MoveUp);
        buttons[1].onClick.AddListener(CharacterButtonAction.MoveDown);
        buttons[2].onClick.AddListener(CharacterButtonAction.MoveLeft);
        buttons[3].onClick.AddListener(CharacterButtonAction.MoveRight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
