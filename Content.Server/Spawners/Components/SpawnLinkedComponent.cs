using Content.Server.Spawners.EntitySystems;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Spawners.Components;

/// <summary>
/// Spawns a prototype and links it to the components owner so they are both destroyed
/// </summary>
[RegisterComponent]
public sealed partial class SpawnerLinkedComponent : Component
{
    /// <summary>
    /// Entity prototype to spawn.
    /// </summary>
    [DataField(required: true)]
    public EntProtoId Prototype = string.Empty;
    public EntityUid LinkedEntity;

    public ComponentRegistry Components = new();
}
