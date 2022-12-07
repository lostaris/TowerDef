using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        //Debug.Log("Standard turret purchased");
        buildManager.SelectTurretToBuild(standardTurret);
        //Debug.Log("Standard turret selected");
    }

    public void SelectMissileTurret()
    {
        //Debug.Log("Missile turret purchased");
        buildManager.SelectTurretToBuild(missileTurret);
        //Debug.Log("Standard turret selected");
    }
    public void SelectLaserTurret()
    {
        //Debug.Log("Missile turret purchased");
        buildManager.SelectTurretToBuild(laserTurret);
        //Debug.Log("Standard turret selected");
    }
}
