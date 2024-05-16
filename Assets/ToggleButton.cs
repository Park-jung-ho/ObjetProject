using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public int maxSelection = 3; // 최대 선택 가능한 버튼 수
    private Toggle[] toggles; // 모든 토글 버튼 배열

    void Start()
    {
        toggles = GetComponentsInChildren<Toggle>(); // 자식 토글 버튼들 가져오기
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(ToggleValueChanged); // 이벤트 리스너 할당
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
            toggleClicked.isOn = !toggleClicked.isOn; // 마지막으로 클릭된 버튼의 상태 반전
        }
    }
}