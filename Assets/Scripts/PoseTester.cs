using UnityEngine;

public class PoseTester : MonoBehaviour
{
    public void BodyAction(string actionType)
    {
        Debug.Log(actionType);
        Logger.Instance.LogInfo(actionType);   
    }
}
