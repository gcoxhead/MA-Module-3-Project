using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterCustomiser : MonoBehaviour
{
    public CharacterSO Character;
    public SkinnedMeshRenderer RightArm;
    public SkinnedMeshRenderer LeftArm;
    public SkinnedMeshRenderer RightCalf;
    public SkinnedMeshRenderer LeftCalf;
    public SkinnedMeshRenderer RightFoot;
    public SkinnedMeshRenderer LeftFoot;
    public SkinnedMeshRenderer RightForearm;
    public SkinnedMeshRenderer LeftForearm;
    public SkinnedMeshRenderer Hair;
    public SkinnedMeshRenderer RightHand;
    public SkinnedMeshRenderer LeftHand;
    public SkinnedMeshRenderer Legs;
    public SkinnedMeshRenderer Torso;
    public SkinnedMeshRenderer Belt;
    public SkinnedMeshRenderer Cape;
    public SkinnedMeshRenderer RightElbow;
    public SkinnedMeshRenderer LeftElbow;
    public SkinnedMeshRenderer Eyebrows;
    public SkinnedMeshRenderer RightKnee;
    public SkinnedMeshRenderer LeftKnee;
    public SkinnedMeshRenderer RightPauldron;
    public SkinnedMeshRenderer LeftPauldron;
    public SkinnedMeshRenderer Shield;
    public SkinnedMeshRenderer Sword;

    //Index Variables initialised to access element 0 of array's in CharacterSO.
    public int _hairIndex = 0;
    public int _capeIndex = 0;
    public int _armIndex = 0;
    public int _torsoIndex = 0;
    public int _beltIndex = 0;
    public int _legsIndex = 0;
    public int _shieldIndex = 0;
    public int _swordIndex = 0;


    // Generates a random character by selecting random elements from each of the Character SO array's.
    public void Randomise()
    {
        RightArm.sharedMesh = Character.RightArm[Random.Range(0, Character.RightArm.Length)];
        LeftArm.sharedMesh = Character.LeftArm[Random.Range(0, Character.LeftArm.Length)];
        RightCalf.sharedMesh = Character.RightCalf[Random.Range(0, Character.RightCalf.Length)];
        LeftCalf.sharedMesh = Character.LeftCalf[Random.Range(0, Character.LeftCalf.Length)];
        RightFoot.sharedMesh = Character.RightFoot[Random.Range(0, Character.RightFoot.Length)];
        LeftFoot.sharedMesh = Character.LeftFoot[Random.Range(0, Character.LeftFoot.Length)];
        RightForearm.sharedMesh = Character.RightForearm[Random.Range(0, Character.RightForearm.Length)];
        LeftForearm.sharedMesh = Character.LeftForearm[Random.Range(0, Character.LeftForearm.Length)];
        Hair.sharedMesh = Character.Hair[Random.Range(0, Character.Hair.Length)];
        RightHand.sharedMesh = Character.RightHand[Random.Range(0, Character.RightHand.Length)];
        LeftHand.sharedMesh = Character.LeftHand[Random.Range(0, Character.LeftHand.Length)];
        Legs.sharedMesh = Character.Legs[Random.Range(0, Character.Legs.Length)];
        Torso.sharedMesh = Character.Torso[Random.Range(0, Character.Torso.Length)];
        Belt.sharedMesh = Character.Belt[Random.Range(0, Character.Belt.Length)];
        Cape.sharedMesh = Character.Cape[Random.Range(0, Character.Cape.Length)];
        RightElbow.sharedMesh = Character.RightElbow[Random.Range(0, Character.RightElbow.Length)];
        LeftElbow.sharedMesh = Character.LeftElbow[Random.Range(0, Character.LeftElbow.Length)];
        Eyebrows.sharedMesh = Character.Eyebrows[Random.Range(0, Character.Eyebrows.Length)];
        RightKnee.sharedMesh = Character.RightKnee[Random.Range(0, Character.RightKnee.Length)];
        LeftKnee.sharedMesh = Character.LeftKnee[Random.Range(0, Character.LeftKnee.Length)];
        RightPauldron.sharedMesh = Character.RightPauldron[Random.Range(0, Character.RightPauldron.Length)];
        LeftPauldron.sharedMesh = Character.LeftPauldron[Random.Range(0, Character.LeftPauldron.Length)];
    }
    
    // Functions are attached to the UIcanvas via this script.
    // Methods are called attached and linked to the appropriate UI buttons. 
    public void NextHair()
    {
        _hairIndex ++;

        if (_hairIndex >= Character.Hair.Length)
        {
            _hairIndex = 0;
            Debug.Log("hair element" + _hairIndex + " selected");
            Hair.sharedMesh = Character.Hair[_hairIndex];
        }
            
        else
        {
            Hair.sharedMesh = Character.Hair[_hairIndex];
            Debug.Log("hair element" + _hairIndex + " selected");
        }

    }
    public void PreviousHair()
    {
        
        if (_hairIndex == 0)
        {
            _hairIndex = (Character.Hair.Length -1);
            Debug.Log("hair element" + _hairIndex + " selected");
            Hair.sharedMesh = Character.Hair[_hairIndex];
        }

        else
        {
            _hairIndex--;
            Hair.sharedMesh = Character.Hair[_hairIndex];
            Debug.Log("hair element" + _hairIndex + " selected");
        }
    }
    public void NextArms()
    {
        _armIndex++;

        if (_armIndex >= Character.RightArm.Length)
        {
            _armIndex = 0;
            Debug.Log("Arm element" + _armIndex + " selected");
            RightArm.sharedMesh = Character.RightArm[_armIndex];
            LeftArm.sharedMesh = Character.LeftArm[_armIndex];
        }

        else
        {
            RightArm.sharedMesh = Character.RightArm[_armIndex];
            LeftArm.sharedMesh = Character.LeftArm[_armIndex];
            Debug.Log("Arm element" + _hairIndex + " selected");
        }

    }
    public void PreviousArms()
    {

        if (_armIndex == 0)
        {
            _armIndex = (Character.RightArm.Length - 1);
            Debug.Log("arm element" + _armIndex + " selected");
            RightArm.sharedMesh = Character.RightArm[_armIndex];
            LeftArm.sharedMesh = Character.LeftArm[_armIndex];
        }

        else
        {
            _armIndex--;
            RightArm.sharedMesh = Character.RightArm[_armIndex];
            LeftArm.sharedMesh = Character.LeftArm[_armIndex];
            Debug.Log("Arm element" + _armIndex + " selected");
        }
    }
    public void NextCape()
    {
        _capeIndex++;

        if (_capeIndex >= Character.Cape.Length)
        {
            _capeIndex = 0;
            Cape.sharedMesh = Character.Cape[_capeIndex];
            Debug.Log("Cape element" + _capeIndex + " selected");
        }

        else
        {
            Debug.Log("Cape element" + _capeIndex + " selected");
            Cape.sharedMesh = Character.Cape[_capeIndex];
        }

    }
    public void PreviousCape()
    {

        if (_capeIndex == 0)
        {
            _capeIndex = (Character.Cape.Length - 1);
            Debug.Log("Cape element" + _capeIndex + " selected");
            Cape.sharedMesh = Character.Cape[_capeIndex];
        }

        else
        {
            _capeIndex--;
            Debug.Log("Cape element" + _capeIndex + " selected");
            Cape.sharedMesh = Character.Cape[_capeIndex];
        }
    }
    public void NextTorso()
    {
        _torsoIndex++;

        if (_torsoIndex >= Character.Torso.Length)
        {
            _torsoIndex = 0;
            Torso.sharedMesh = Character.Torso[_torsoIndex];
            Debug.Log("Torso element" + _torsoIndex + " selected");
        }

        else
        {
            Torso.sharedMesh = Character.Torso[_torsoIndex];
            Debug.Log("Torso element" + _torsoIndex + " selected");
        }

    }
    public void PreviousTorso()
    {

        if (_torsoIndex == 0)
        {
            _torsoIndex = (Character.Torso.Length - 1);
            Debug.Log("Torso element" + _torsoIndex + " selected");
            Torso.sharedMesh = Character.Torso[_torsoIndex];
        }

        else
        {
            _torsoIndex--;
            Debug.Log("Torso element" + _torsoIndex + " selected");
            Torso.sharedMesh = Character.Torso[_torsoIndex];
        }
    }
    public void NextBelt()
    {
        _beltIndex++;

        if (_beltIndex >= Character.Belt.Length)
        {
            _beltIndex = 0;
            Belt.sharedMesh = Character.Belt[_beltIndex];
            Debug.Log("Belt element" + _beltIndex + " selected");
        }

        else
        {
            Belt.sharedMesh = Character.Belt[_beltIndex];
            Debug.Log("Belt element" + _beltIndex + " selected");
        }

    }
    public void PreviousBelt()
    {

        if (_beltIndex == 0)
        {
            _beltIndex = (Character.Belt.Length - 1);
            Debug.Log("Belt element" + _beltIndex + " selected");
            Belt.sharedMesh = Character.Belt[_beltIndex];
        }

        else
        {
            _beltIndex--;
            Debug.Log("Belt element" + _beltIndex + " selected");
            Belt.sharedMesh = Character.Belt[_beltIndex];
        }
    }
    public void NextLegs()
    {
        _legsIndex++;

        if (_legsIndex >= Character.Legs.Length)
        {
            _legsIndex = 0;
            Legs.sharedMesh = Character.Legs[_legsIndex];
            Debug.Log("Legs element" + _legsIndex + " selected");
        }

        else
        {            
            Legs.sharedMesh = Character.Legs[_legsIndex];
            Debug.Log("Legs element" + _legsIndex + " selected");
        }

    }
    public void PreviousLegs()
    {

        if (_legsIndex == 0)
        {
            _legsIndex = (Character.Legs.Length - 1);
            Debug.Log("Legs element" + _legsIndex + " selected");
            Legs.sharedMesh = Character.Legs[_legsIndex];
        }

        else
        {
            _legsIndex--;
            Debug.Log("Legs element" + _legsIndex + " selected");
            Legs.sharedMesh = Character.Legs[_legsIndex];
        }
    }
}
// Custom tool created that provides functionality in the inspector to create random character set-up.
[CustomEditor(typeof(CharacterCustomiser))]
public class CustomiserEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var characterCustomiser = (CharacterCustomiser)target;

        if (GUILayout.Button("Randomise"))
        {
            characterCustomiser.Randomise();
        }
    }
}
