# Notice
As of 2.1.0u claims to have fixed the issue

# ChargedWaterFix
Pathfinder: Wrath Of The Righteous - Extended Range Charged Water Blast 0-damage fix

WOTR version as of writing: 2.0.7o
Currently there is a bug where Extended Range infusion of Charged Water Blast does only 1 damage
Further, that damage is one instance of Electric, with no Bludgeoning component.
My suspicion is that the Bludgeoning component is calculated first in full, then halved and the other half sent to the Electric component.
The dice roll in the combat log for Electric is a lie, only the Bludgeoning component matches the calculations.
With the conditional failing erronously, no Bludgeoning roll is made and half of that roll (i.e. 0) is sent to Electric

ExtendedRangeChargedWaterBlastAbility is the *only* Kinetic Blast to have
```
"Conditions": [
  {
	"$type": "IsEqual",
	"name": "IsEqual",
	"Not": false,
	"FirstValue": {
	  "$type": "DeliverEffectLayer",
	  "name": "DeliverEffectLayer"
	},
	"SecondValue": null
  }
 ]
```
instead of
```
"Conditions": [
  {
	"$type": "IsEqual",
	"name": "IsEqual",
	"Not": false,
	"FirstValue": {
	  "$type": "DeliverEffectLayer",
	  "name": "DeliverEffectLayer"
	},
	"SecondValue": {
	  "$type": "IntConstant",
	  "name": "IntConstant",
	  "Value": 0
	}
  }
 ]
```

Replacing the conditional with one with IntConstant 0 instead of null fixes the issue

---

Made using [WittleWolfie's Blueprint Core](https://github.com/WittleWolfie/WW-Blueprint-Core)
