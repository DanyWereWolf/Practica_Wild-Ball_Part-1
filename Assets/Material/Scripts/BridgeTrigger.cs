using UnityEngine;
using WildBall.inputs;

public class BridgeTrigger : MonoBehaviour
{
    public GameController gameController;
    public Animator bridgeAnim;
    public GameObject TrigZone;
    public GameObject OpenKey;
    public GameObject InfoKey;
    public bool InTrigPl = false;

    private void Update()
    {
        if (InTrigPl == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) // ��������� ������� ������� E
            {
                bridgeAnim.SetTrigger("LowerBridge"); // ��������� ��������� �����
                OpenKey.SetActive(false);
                InfoKey.SetActive(false);
                Destroy(TrigZone);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameController.hasKey) // ���������, ��� ��� ����� � � ���� ���� ����
        {
            OpenKey.SetActive(true);
            InTrigPl = true;
        }
        else
        {
            InfoKey.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OpenKey.SetActive(false);
        InfoKey.SetActive(false);
    }
}
