# Custom Stat Extension

Makes it easy to share custom stats between different mod creators without forcing them to add another mod as a dependency or to build a copy of the stat from the ground up.

----
## Custom Stat Manager

This manager provides the various utilities needed for creating and utilizing custom stats.

By using `CustomStatExtension.Utils.CustomStatManager.instance.RegisterStat()` it's possible to register a custom stat that will automatically be transferred from a card to a player in `ApplyCardStats`.

In `SetupCard`, `statModifiers.GetCustomStats().stats` will access a `Dictionary<string, object>` of all the registered custom stats. In `OnAddCard`, `characterStats.GetCustomStats().stats` functions similarly, save that it's the current value of each custom stat on the player.

<details>
<summary>Properties</summary>

### instance
```cs
CustomStatManager instance { get; }
```
#### Description
Static reference of the class for accessiblity purposes.

### RegisteredStats
```cs
ReadOnlyDictionary<string, object> RegisteredStats { get; }
```
#### Description
The currently registered stats and their default values.
</details>

<details>
<summary>Functions</summary>

### RegisterStat()
```cs
bool RegisterStat(string name, object defaultValue, Func<object, object, object> applyStatsOperation)
```
#### Description
Registers a stat with the Custom Stat Manager for automated usage.

Returns true if the stat is added, or false if a stat with that name existed already.

#### Parameters
- *string* `name` the name of the stat.
- *object* `defaultValue` the default value that the stat is initialized with.
- *Func<object, object, object>* `applyStatsOperation` the function run in `ApplyCardStats` to transfer values from the card to the player.
  - *object* `currentValue` the current value on the player.
  - *object* `incomingValue` the current value on the card.
  - *object* `finalValue` the returned value that the player is set to.

#### Example Usage
```CSHARP
CustomStatExtension.Utils.CustomStatManager.instance.RegisterStat("Armor", 0f, ());

public object AddArmor(object start, object add)
{
    return ((float) start + (float) add);
}
```
</details>