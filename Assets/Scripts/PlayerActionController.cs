
using UnityEngine;

[CreateAssetMenu]
public class PlayerActionController : ScriptableObject
{
    public void LiftActionResponse()
    {
        Debug.Log("LiftActionResponse()");
    }

    public void GlideActionResponse()
    {
        Debug.Log("GlideActionResponse()");
    }

    public void ShiftLeftActionResponse()
    {
        Debug.Log("ShiftLeftActionResponse()");
    }

    public void ShiftRightActionResponse()
    {
        Debug.Log("ShiftRightActionResponse()");
    }
}
