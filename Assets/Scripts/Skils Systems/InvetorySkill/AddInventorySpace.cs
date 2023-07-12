using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player.Skill;

[CreateAssetMenu(menuName = "Skill/Inventory/Add Space")]
public sealed class AddInventorySpace : InventorySkill
{
    [Header("����������� ����������� ���� � ��������")]
    [SerializeField]
    private int countItemsAdd = 0;

    public int CountItemsAdd { get => countItemsAdd; private set => countItemsAdd = value; }
}
