using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using Assets.Scripts.Save_System;
using Assets.Scripts.Player.Skill;
using System;
using UnityEngine.SceneManagement;
using System.Reflection;



public class SkillTreeTest : MonoBehaviour
{

    [UnityTest]
    public IEnumerator Skill_Tree_Menu_Initialize_1()
    {
        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        SkillView[] Objects = FindObjectsByType<SkillView>(FindObjectsSortMode.None);

        Type SkillViewType = typeof(SkillView);

        PropertyInfo Skill = SkillViewType.GetProperty("Skill");        

        foreach (var i in Objects)
            if (Skill.GetValue(i) == null)
                Assert.True(false);

        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator Skill_Tree_Menu_Initialize_2()
    {
        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        SkillBranchView[] Objects = FindObjectsByType<SkillBranchView>(FindObjectsSortMode.None);

        Type BranchType = typeof(SkillBranchView);

        PropertyInfo Next = BranchType.GetProperty("Next");

        PropertyInfo Prev = BranchType.GetProperty("Prev");

        foreach (var i in Objects)
            if (Next.GetValue(i) == null || Prev.GetValue(i) == null)
                Assert.True(false);

        Assert.True(true);
    }
}
