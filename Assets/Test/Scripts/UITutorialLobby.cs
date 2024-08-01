using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITutorialLobby : MonoBehaviour
{
    #region public 변수
    public Dropdown dropdown;
    public Button button;
    public List<string> sceneNames = new List<string>();
    #endregion

    #region private 변수
    int selectedSceneIndex;
    #endregion

    void Awake()
    {
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        foreach(string sceneName in sceneNames)
        {
            options.Add(new Dropdown.OptionData(sceneName));
        }

        dropdown.options = options;
        dropdown.onValueChanged.AddListener(SceneSelectionChange);

        button.onClick.AddListener(MoveButtonClick);
    }

    public void SceneSelectionChange(int index)
    {
        selectedSceneIndex = index;
    }

    public void MoveButtonClick()
    {
        SceneManager.LoadScene(selectedSceneIndex);
    }
}