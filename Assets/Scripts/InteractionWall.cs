using TMPro;
using UnityEngine;

public class InteractionWall : MonoBehaviour
{
    [SerializeField] TMP_Text textOnTheWall;

    private int value;
    private string operatorText;
    

    private void Start()
    {
        value = Random.Range(1, 11);
        int whichOperatorToUse = Random.Range(1, 5);
        if (whichOperatorToUse == 1)
        {
            operatorText = "x";
        }
        if (whichOperatorToUse == 2)
        {
            operatorText = "÷";
        }
        if (whichOperatorToUse == 3)
        {
            operatorText = "+";
        }
        if (whichOperatorToUse == 4)
        {
            operatorText = "-";
        }

        textOnTheWall.text = operatorText + value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Duvara temas var");
            GameManager.instance.MakeCalculation(value, operatorText);
        }
    }
}
