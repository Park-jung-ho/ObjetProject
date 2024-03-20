using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
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
    public Dictionary<string,Dialog> Dialog_Dict;

    private Queue<DialogText> dialogTexts; 


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
        dialogTexts = new Queue<DialogText>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialog();
        }
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
    public void StartDialog(string key)
    {
        Dialog dialog = Dialog_Dict[key];
        DialogUIanimator.SetTrigger("IsOn");
        OpenPanel();

        name.text = dialog.name;
        image.sprite = dialog.image;
        foreach (DialogText dialogText in dialog.sentences)
        {
            dialogTexts.Enqueue(dialogText);
        }
        
        ShowDialog();
    }

    public void ShowDialog()
    {
        if (dialogTexts.Count == 0)
        {
            EndDialog();
            return;
        }

        DialogText Currentdialog = dialogTexts.Dequeue();

        if (Currentdialog.dialogType == DialogType.Text)
        {
            ChoicePanel.SetActive(false);
            TextPanel.SetActive(true);
            text.text = Currentdialog.text;
            
        }
        if (Currentdialog.dialogType == DialogType.Choice)
        {
            ChoicePanel.SetActive(true);
            TextPanel.SetActive(false);

            choicetext.text = Currentdialog.text;
            for (int i = 0; i < 3; i++)
            {
                choices[i].text = Currentdialog.choices[i];
            }
        }
    }

    [Button]
    public void EndDialog()
    {
        DialogUIanimator.SetTrigger("IsOff");
        HidePanel();
    }
}
