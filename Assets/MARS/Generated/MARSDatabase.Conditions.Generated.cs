// This file is automatically generated - DO NOT EDIT MANUALLY!
using System.Collections.Generic;
using Unity.MARS.Query;

namespace Unity.MARS.Data
{
    public partial class MARSDatabase
    {
        bool FindTraitsInternal(ProxyConditions conditions, CachedTraitCollection cache)
        {
            if (conditions.GetTypeCount(out ISemanticTagCondition[] semanticTagConditions) > 0)
            {
                if(!cache.TryGetType(out List<Dictionary<int, System.Boolean>> semanticTagCollections))
                    return false;

                for(var i = 0; i < semanticTagConditions.Length; i++)
                {
                    var condition = semanticTagConditions[i];
                    if(!SemanticTagTraitProvider.TryGetAllTraitValues(condition.traitName, out Dictionary<int, System.Boolean> traits))
                        if(condition.matchRule == SemanticTagMatchRule.Match)
                            return false;

                    semanticTagCollections[i] = traits;
                }
            }

            if (conditions.GetTypeCount(out ICondition<System.Int32>[] intConditions) > 0)
            {
                if(!cache.TryGetType(out List<Dictionary<int, System.Int32>> intCollections))
                    return false;

                for(var i = 0; i < intConditions.Length; i++)
                {
                    var condition = intConditions[i];
                    if(!IntTraitProvider.TryGetAllTraitValues(condition.traitName, out Dictionary<int, System.Int32> traits))
                        return false;

                    intCollections[i] = traits;
                }
            }

            if (conditions.GetTypeCount(out ICondition<System.Single>[] floatConditions) > 0)
            {
                if(!cache.TryGetType(out List<Dictionary<int, System.Single>> floatCollections))
                    return false;

                for(var i = 0; i < floatConditions.Length; i++)
                {
                    var condition = floatConditions[i];
                    if(!FloatTraitProvider.TryGetAllTraitValues(condition.traitName, out Dictionary<int, System.Single> traits))
                        return false;

                    floatCollections[i] = traits;
                }
            }

            if (conditions.GetTypeCount(out ICondition<System.String>[] stringConditions) > 0)
            {
                if(!cache.TryGetType(out List<Dictionary<int, System.String>> stringCollections))
                    return false;

                for(var i = 0; i < stringConditions.Length; i++)
                {
                    var condition = stringConditions[i];
                    if(!StringTraitProvider.TryGetAllTraitValues(condition.traitName, out Dictionary<int, System.String> traits))
                        return false;

                    stringCollections[i] = traits;
                }
            }

            if (conditions.GetTypeCount(out ICondition<UnityEngine.Pose>[] poseConditions) > 0)
            {
                if(!cache.TryGetType(out List<Dictionary<int, UnityEngine.Pose>> poseCollections))
                    return false;

                for(var i = 0; i < poseConditions.Length; i++)
                {
                    var condition = poseConditions[i];
                    if(!PoseTraitProvider.TryGetAllTraitValues(condition.traitName, out Dictionary<int, UnityEngine.Pose> traits))
                        return false;

                    poseCollections[i] = traits;
                }
            }

            if (conditions.GetTypeCount(out ICondition<UnityEngine.Vector2>[] vector2Conditions) > 0)
            {
                if(!cache.TryGetType(out List<Dictionary<int, UnityEngine.Vector2>> vector2Collections))
                    return false;

                for(var i = 0; i < vector2Conditions.Length; i++)
                {
                    var condition = vector2Conditions[i];
                    if(!Vector2TraitProvider.TryGetAllTraitValues(condition.traitName, out Dictionary<int, UnityEngine.Vector2> traits))
                        return false;

                    vector2Collections[i] = traits;
                }
            }
            return true;
        }

        public bool UpdateQueryMatchInternal(int dataID,
            ProxyConditions conditions, ProxyTraitRequirements requirements, QueryResult result)
        {
            if (conditions.TryGetType(out ICondition<System.Int32>[] intConditions))
            {
                foreach (var condition in intConditions)
                {
                    if (!IntTraitProvider.TryGetTraitValue(dataID, condition.traitName, out var traitValue))
                        return false;
                    if (condition.PassesCondition(ref traitValue))
                        result.SetTrait(condition.traitName, traitValue);
                    else
                        return false;
                }
            }

            if (conditions.TryGetType(out ICondition<System.Single>[] floatConditions))
            {
                foreach (var condition in floatConditions)
                {
                    if (!FloatTraitProvider.TryGetTraitValue(dataID, condition.traitName, out var traitValue))
                        return false;
                    if (condition.PassesCondition(ref traitValue))
                        result.SetTrait(condition.traitName, traitValue);
                    else
                        return false;
                }
            }

            if (conditions.TryGetType(out ICondition<System.String>[] stringConditions))
            {
                foreach (var condition in stringConditions)
                {
                    if (!StringTraitProvider.TryGetTraitValue(dataID, condition.traitName, out var traitValue))
                        return false;
                    if (condition.PassesCondition(ref traitValue))
                        result.SetTrait(condition.traitName, traitValue);
                    else
                        return false;
                }
            }

            if (conditions.TryGetType(out ICondition<UnityEngine.Vector2>[] vector2Conditions))
            {
                foreach (var condition in vector2Conditions)
                {
                    if (!Vector2TraitProvider.TryGetTraitValue(dataID, condition.traitName, out var traitValue))
                        return false;
                    if (condition.PassesCondition(ref traitValue))
                        result.SetTrait(condition.traitName, traitValue);
                    else
                        return false;
                }
            }

            return true;
        }

        internal void FillSemanticTagRequirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            if (requirement.Required)
            {
                var value = SemanticTagTraitProvider.dictionary[requirement.TraitName][dataId];
                result.SetTrait(requirement.TraitName, value);
            }
            else
            {
                if (!SemanticTagTraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                    return;
                if(traitValues.TryGetValue(dataId, out var value))
                    result.SetTrait(requirement.TraitName, value);
            }
        }

        internal void FillIntRequirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            if (requirement.Required)
            {
                var value = IntTraitProvider.dictionary[requirement.TraitName][dataId];
                result.SetTrait(requirement.TraitName, value);
            }
            else
            {
                if (!IntTraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                    return;
                if(traitValues.TryGetValue(dataId, out var value))
                    result.SetTrait(requirement.TraitName, value);
            }
        }

        internal void FillFloatRequirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            if (requirement.Required)
            {
                var value = FloatTraitProvider.dictionary[requirement.TraitName][dataId];
                result.SetTrait(requirement.TraitName, value);
            }
            else
            {
                if (!FloatTraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                    return;
                if(traitValues.TryGetValue(dataId, out var value))
                    result.SetTrait(requirement.TraitName, value);
            }
        }

        internal void FillStringRequirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            if (requirement.Required)
            {
                var value = StringTraitProvider.dictionary[requirement.TraitName][dataId];
                result.SetTrait(requirement.TraitName, value);
            }
            else
            {
                if (!StringTraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                    return;
                if(traitValues.TryGetValue(dataId, out var value))
                    result.SetTrait(requirement.TraitName, value);
            }
        }

        internal void FillVector2Requirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            if (requirement.Required)
            {
                var value = Vector2TraitProvider.dictionary[requirement.TraitName][dataId];
                result.SetTrait(requirement.TraitName, value);
            }
            else
            {
                if (!Vector2TraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                    return;
                if(traitValues.TryGetValue(dataId, out var value))
                    result.SetTrait(requirement.TraitName, value);
            }
        }

        internal bool UpdateSemanticTagRequirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            return TryUpdateRequirementType(requirement, dataId, result, SemanticTagTraitProvider);
        }

        internal bool UpdateIntRequirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            return TryUpdateRequirementType(requirement, dataId, result, IntTraitProvider);
        }

        internal bool UpdateFloatRequirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            return TryUpdateRequirementType(requirement, dataId, result, FloatTraitProvider);
        }

        internal bool UpdateStringRequirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            return TryUpdateRequirementType(requirement, dataId, result, StringTraitProvider);
        }

        internal bool UpdateVector2Requirement(TraitRequirement requirement, int dataId, QueryResult result)
        {
            return TryUpdateRequirementType(requirement, dataId, result, Vector2TraitProvider);
        }

        void AddRequirementUpdateMethods(MARSDatabase self)
        {
            TypeToRequirementUpdate[(MarsDataType) typeof(System.Boolean)] = UpdateSemanticTagRequirement;
            TypeToRequirementFill[(MarsDataType) typeof(System.Boolean)] = FillSemanticTagRequirement;

            TypeToRequirementUpdate[(MarsDataType) typeof(System.Int32)] = UpdateIntRequirement;
            TypeToRequirementFill[(MarsDataType) typeof(System.Int32)] = FillIntRequirement;

            TypeToRequirementUpdate[(MarsDataType) typeof(System.Single)] = UpdateFloatRequirement;
            TypeToRequirementFill[(MarsDataType) typeof(System.Single)] = FillFloatRequirement;

            TypeToRequirementUpdate[(MarsDataType) typeof(System.String)] = UpdateStringRequirement;
            TypeToRequirementFill[(MarsDataType) typeof(System.String)] = FillStringRequirement;

            TypeToRequirementUpdate[(MarsDataType) typeof(UnityEngine.Vector2)] = UpdateVector2Requirement;
            TypeToRequirementFill[(MarsDataType) typeof(UnityEngine.Vector2)] = FillVector2Requirement;
        }

        bool DataPassesAllConditionsInternal(ProxyConditions conditions, int dataId)
        {
            if(conditions.TryGetType(out ICondition<System.Int32>[] intConditions))
            {
                if(!ConditionsPass(IntTraitProvider, intConditions, dataId))
                    return false;
            }

            if(conditions.TryGetType(out ICondition<System.Single>[] floatConditions))
            {
                if(!ConditionsPass(FloatTraitProvider, floatConditions, dataId))
                    return false;
            }

            if(conditions.TryGetType(out ICondition<System.String>[] stringConditions))
            {
                if(!ConditionsPass(StringTraitProvider, stringConditions, dataId))
                    return false;
            }

            if(conditions.TryGetType(out ICondition<UnityEngine.Pose>[] poseConditions))
            {
                if(!ConditionsPass(PoseTraitProvider, poseConditions, dataId))
                    return false;
            }

            if(conditions.TryGetType(out ICondition<UnityEngine.Vector2>[] vector2Conditions))
            {
                if(!ConditionsPass(Vector2TraitProvider, vector2Conditions, dataId))
                    return false;
            }

            return true;
        }
    }
}
