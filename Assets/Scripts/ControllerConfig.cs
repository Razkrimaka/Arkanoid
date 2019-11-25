using UnityEngine;

[CreateAssetMenu(fileName ="InputConfig", menuName ="Configs/InputConfig")]
public class ControllerConfig : ScriptableObject, IControllerConfig
{
    #region IControllerConfig

    public float MoveSensity => _moveSensity;

    #endregion

    [SerializeField]
    private float _moveSensity;

}
