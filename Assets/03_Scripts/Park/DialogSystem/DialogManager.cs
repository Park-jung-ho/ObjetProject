using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public GameObject NextIcon;
    public TMP_Text text;
    [Title("CHOICE PANEL")]
    public GameObject ChoicePanel;
    // public TMP_Text choicetext;
    public TMP_Text[] choices;

    [Title("Dialog Dict")]
    public Dictionary<string,Dialog> DialogList;

    [SerializeField]
    private Dialog currentDialog; 

    [SerializeField]
    private DialogText currentDialogText;

    [SerializeField]
    private bool isTyping;
    private bool CantClick = false;
    private bool OnDialog;


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
        if (DialogList == null) DialogList = new Dictionary<string, Dialog>();
    }
    void Start()
    {
        HidePanel();
    }

    void Update()
    {
    
    }
    public void NotClick(bool on)
    {
        CantClick = on;
    }
    public void OnClick()
    {
        if (CantClick)
        {
            return;
        }
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
    }
    public void HidePanel()
    {
        DialogPanel.SetActive(false);
    }

    public void AddDialog(Dialog dialog)
    {
        if (!DialogList.ContainsKey(dialog.name))
        {
            DialogList.Add(dialog.name,dialog);
        }
    }

    public void StartDialog(Dialog dialog)
    {
        if (OnDialog) return;
        if (dialog == null)
        {
            Debug.LogWarning("input dialog is NULL!!!!!");
            return;
        }
        OnDialog = true;
        currentDialog = dialog;
        NPCname.text = currentDialog.NPCname;
        image.sprite = currentDialog.sentences[0].image;

        OpenPanel();
        
        DialogUIanimator.SetTrigger("IsOn");
        // ShowDialog(0);
        if (PlayerController2D.instance != null)
        {
            PlayerController2D.instance.ChangeState(PlayerState.dialog);
        }
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
        if (currentDialogText.dialogType == DialogType.Text)
        {
            NextIcon.SetActive(true);
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
        EventTest.ChangeDialogID(id);
        if (id == -1)
        {
            EndDialog();
            if (currentDialogText.isCutscene)
            {
                TimelineController.instance.loopOut();
            }
            return;
        }

        currentDialogText = currentDialog.sentences[id];

        image.sprite = currentDialogText.image;
        NextIcon.SetActive(false);
        StartCoroutine("typing");
    }

    public void EndDialog()
    {
        if (!OnDialog)
        {
            return;
        }
        OnDialog = false;
        DialogUIanimator.SetTrigger("IsOff");
        
        if (currentDialogText.GoToNextStory)
        {
            GameManager.instance.SetStory(currentDialogText.nextStoryNode);
        }
        text.text = "";
        NPCname.text = "";
        if (currentDialogText.dialogType == DialogType.Choice)
        {
            for (int i = 0; i < currentDialogText.choices.Length; i++)
            {
                choices[i].transform.parent.gameObject.SetActive(false);
            }
        }
        
        if (PlayerController2D.instance != null)
        {
            PlayerController2D.instance.ChangeState(PlayerState.play);
        }
    }
}
