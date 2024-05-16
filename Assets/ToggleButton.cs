using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public int maxSelection = 3; // �ִ� ���� ������ ��ư ��
    private Toggle[] toggles; // ��� ��� ��ư �迭

    void Start()
    {
        toggles = GetComponentsInChildren<Toggle>(); // �ڽ� ��� ��ư�� ��������
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(ToggleValueChanged); // �̺�Ʈ ������ �Ҵ�
        }
    }

    void ToggleValueChanged(bool value)
    {
        int selectedCount = 0;
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn)
            {
                selectedCount++;
            }
        }

        if (selectedCount > maxSelection)
        {
            Toggle toggleClicked = toggles[toggles.Length - 1];
            toggleClicked.isOn = !toggleClicked.isOn; // ���������� Ŭ���� ��ư�� ���� ����
        }
    }
}