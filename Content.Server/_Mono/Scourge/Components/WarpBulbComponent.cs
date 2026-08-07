using Content.Server.Spawners.EntitySystems;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using Robust.Shared.Map;
using System.Numerics;

namespace Content.Server._Mono.Scourge.Components.WarpBulbComponent;

/// <summary>
/// Saves the position for the warp bulb event to send you back to
/// </summary>
[RegisterComponent]
public sealed partial class WarpBulbComponent : Component
{
    public EntityUid LinkedEntity;
}
