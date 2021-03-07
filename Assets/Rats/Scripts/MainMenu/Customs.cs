using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customs : MonoBehaviour
{

    [SerializeField]
    private FloatParamUI floatParamUI_prefab;

    [SerializeField]
    private BoolParamUI boolParamUI_prefab;

    [SerializeField]
    private Text text_prefab;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private List<GameObject> paramsObjects = new List<GameObject>();

    public void Reset()
    {
        foreach (var item in GameParameterBase.GetGameParameters())
        {
            item.ResetValue();
        }
        DeleteParams();
        CreateParams();
    }

    private void Awake()
    {
        //CreateParams();
    }

    public void DeleteParams()
    {
        foreach (var item in paramsObjects)
        {
            Destroy(item.gameObject);
        }
        paramsObjects.Clear();
    }

    public void CreateParams()
    {
        List<Group> groups = new List<Group>();
        foreach (var item in GameParameterBase.GetGameParameters())
        {
            if (item.isUnlocked() == false) continue;
            bool isGroupFinded = false;
            foreach (var item_group in groups)
            {
                if (item_group.group == item.GetGroup())
                {
                    item_group.parameters.Add(item);
                    isGroupFinded = true;
                    break;
                }
            }
            if (isGroupFinded == false)
            {
                Group newGroup = new Group();
                newGroup.group = item.GetGroup();
                newGroup.parameters.Add(item);
                groups.Add(newGroup);
            }
        }

        foreach (var item in groups)
        {
            Text newText = Instantiate(text_prefab, parent);
            newText.text = item.group;
            paramsObjects.Add(newText.gameObject);
            foreach (var item_param in item.parameters)
            {
                if (item_param is FloatParameter)
                {
                    FloatParamUI floatParamUI = Instantiate(floatParamUI_prefab, parent);
                    floatParamUI.Setup((FloatParameter)item_param);
                    paramsObjects.Add(floatParamUI.gameObject);
                }
                else if (item_param is BoolParameter)
                {
                    BoolParamUI boolParamUI = Instantiate(boolParamUI_prefab, parent);
                    boolParamUI.Setup((BoolParameter)item_param);
                    paramsObjects.Add(boolParamUI.gameObject);
                }
            }
        }
    }

    [System.Serializable]
    private class Group
    {
        public string group;
        public List<GameParameterBase> parameters = new List<GameParameterBase>();
    }

}