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
    public Animator DialogUIanimator;
    public Image image;
    public TMP_Text name;
    [Title("TEXT PANEL")]
    public GameObject TextPanel;
    public TMP_Text text;
    [Title("CHOICE PANEL")]
    public GameObject ChoicePanel;
    public TMP_Text choicetext;
    public TMP_Text[] choices;

    [Title("Dialog Dict")]
    public List<Dialog> StoryList;

    private Dialog currentDialog; 

    [SerializeField]
    private DialogText currentDialogText;


    private PlayerInput playerInput;
    private bool isChangeNow;



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
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        isChangeNow = true;
        HidePanel();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
    
    }
    public void SetInput(bool isOn)
    {
        if (isOn) isChangeNow = true;
        playerInput.enabled = isOn;
    }
    void OnClick()
    {
        if (isChangeNow)
        {
            isChangeNow = false;
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
        image.gameObject.SetActive(true);
        name.gameObject.SetActive(true);
    }
    void HidePanel()
    {
        image.gameObject.SetActive(false);
        name.gameObject.SetActive(false);
        TextPanel.SetActive(false);
        ChoicePanel.SetActive(false);
    }

    [Button]
    public void StartDialog(int stroyID)
    {
        PlayerController2D.instance.SetInput(false);

        SetInput(true);
        OpenPanel();

        DialogUIanimator.SetTrigger("IsOn");

        currentDialog = StoryList[stroyID];

        name.text = currentDialog.name;
        
        ShowDialog(0);
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
            // set next story
            return;
        }

        currentDialogText = currentDialog.sentences[id];

        image.sprite = currentDialogText.image;

        if (currentDialogText.dialogType == DialogType.Text)
        {
            ChoicePanel.SetActive(false);
            TextPanel.SetActive(true);
            text.text = currentDialogText.text;
            
        }
        if (currentDialogText.dialogType == DialogType.Choice)
        {
            ChoicePanel.SetActive(true);
            TextPanel.SetActive(false);

            choicetext.text = currentDialogText.text;
            for (int i = 0; i < currentDialogText.choices.Length; i++)
            {
                choices[i].text = currentDialogText.choices[i].text;
                choices[i].transform.parent.gameObject.SetActive(true);
            }
        }
        if (currentDialogText.dialogType == DialogType.Quest)
        {
            ChoicePanel.SetActive(false);
            TextPanel.SetActive(true);
            text.text = currentDialogText.text;
            QuestManager.instance.StartQuest(currentDialogText.qusetID);
        }
    }

    [Button]
    public void EndDialog()
    {
        SetInput(false);
        PlayerController2D.instance.SetInput(true);
        DialogUIanimator.SetTrigger("IsOff");
        HidePanel();
    }
}
