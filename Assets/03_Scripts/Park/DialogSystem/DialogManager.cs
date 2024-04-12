using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogManager : SerializedMonoBehaviour
{
    public static DialogManager instance;

    
    [Title("Setting")]
    public GameObject DialogPanel;
    public Animator DialogUIanimator;
    public Image image;
    public TMP_Text NPCname;
    public float typingTime;
    [Title("TEXT PANEL")]
    public GameObject TextPanel;
    public TMP_Text text;
    [Title("CHOICE PANEL")]
    public GameObject ChoicePanel;
    // public TMP_Text choicetext;
    public TMP_Text[] choices;

    [Title("Dialog Dict")]
    public Dictionary<string,Dialog> StoryList;

    private Dialog currentDialog; 

    [SerializeField]
    private DialogText currentDialogText;

    [SerializeField]
    private bool isTyping;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("DialogManager 중복!!");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        HidePanel();
    }

    void Update()
    {
    
    }
    
    public void OnClick()
    {
        if (isTyping)
        {
            isTyping = false;
            return;
        }
        if (currentDialogText.dialogType == DialogType.Choice) return;
        ShowDialog(currentDialogText.next);
    }
    public void SelectChoice(int choiceIdx)
    {
        ShowDialog(currentDialogText.choices[choiceIdx].next);
    }

    void OpenPanel()
    {
        DialogPanel.SetActive(true);
        // image.gameObject.SetActive(true);
        // NPCname.gameObject.SetActive(true);
    }
    void HidePanel()
    {
        DialogPanel.SetActive(false);
        // image.gameObject.SetActive(false);
        // NPCname.gameObject.SetActive(false);
        // TextPanel.SetActive(false);
        // ChoicePanel.SetActive(false);
    }

    public void setStory(int stroyID)
    {
        
    }

    public void StartDialog(string stroyID)
    {
        OpenPanel();
        DialogUIanimator.SetTrigger("IsOn");

        currentDialog = StoryList[stroyID];

        NPCname.text = currentDialog.NPCname;
        
        ShowDialog(0);
        PlayerController2D.instance.ChangeState(PlayerState.dialog);
    }

    IEnumerator typing()
    {
        isTyping = true;
        float waitTime = typingTime;
        text.text = "";
        TextPanel.SetActive(true);
        if (currentDialogText.dialogType != DialogType.Choice)
        {
            for (int i = 0; i < currentDialogText.choices.Length; i++)
            {
                choices[i].transform.parent.gameObject.SetActive(false);
            }
            ChoicePanel.SetActive(false);
        }
        foreach (var c in currentDialogText.text)
        {
            if (!isTyping)
            {
                text.text = currentDialogText.text;
                isTyping = true;
                break;
            }
            text.text += c;
            // add typing sound here
            yield return new WaitForSeconds(waitTime);
        }
        if (currentDialogText.dialogType == DialogType.Choice)
        {
            ChoicePanel.SetActive(true);
            for (int i = 0; i < currentDialogText.choices.Length; i++)
            {
                choices[i].text = currentDialogText.choices[i].text;
                choices[i].transform.parent.gameObject.SetActive(true);
            }
        }
        if (currentDialogText.dialogType == DialogType.Quest)
        {
            QuestManager.instance.StartQuest(currentDialogText.qusetID);
        }




        isTyping = false;
    }

    public void ShowDialog(int id)
    {
        if (id == -1)
        {
            EndDialog();
            if (currentDialogText.isCutscene)
            {
                TimelineController.instance.playCutscene(currentDialogText.cutSceneID);
            }
            if (currentDialogText.GoToNextStory)
            {
                // set next story
                GameManager.instance.SetStory(currentDialogText.nextStoryNode);
            }
            return;
        }

        currentDialogText = currentDialog.sentences[id];

        image.sprite = currentDialogText.image;

        StartCoroutine("typing");
    }

    public void EndDialog()
    {
        DialogUIanimator.SetTrigger("IsOff");
        text.text = "";
        NPCname.text = "";
        if (currentDialogText.dialogType == DialogType.Choice)
        {
            for (int i = 0; i < currentDialogText.choices.Length; i++)
            {
                choices[i].transform.parent.gameObject.SetActive(false);
            }
        }
        HidePanel();
        PlayerController2D.instance.ChangeState(PlayerState.play);
    }
}
