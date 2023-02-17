using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.UnitLogic.Abilities.Components;

namespace ChargedWaterFixBP
{
    public class ChargedWaterFixBP
  {

    public static void Configure()
    {
            IntConstant zero = new();
            zero.Value = 0;

            AbilityConfigurator
                .For(AbilityRefs.ExtendedRangeChargedWaterBlastAbility)
                .EditComponent<AbilityEffectRunAction>(component =>
            {
                Conditional conditions = (Conditional)component.Actions.Actions[0];
                component.Actions = ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New()
                    .AddIsEqual(
                        FirstValue: new DeliverEffectLayer(),
                        SecondValue: zero),
                ifTrue: conditions.IfTrue,
                ifFalse: conditions.IfFalse
                    )
                .Build();
            }).Configure()
                ;
        }
  }
}

