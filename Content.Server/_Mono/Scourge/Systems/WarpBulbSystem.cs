using System.ComponentModel;
using System.Threading.Tasks.Dataflow;
using Content.Server._Mono.Scourge.Components.WarpBulbComponent;
using Content.Shared.Actions.Events;
using Robust.Shared.Prototypes;
using Robust.Shared.Spawners;
using Robust.Shared.Map;
using Robust.Shared.GameObjects;

namespace Content.Server.Spawners.WarpBulbSystem;

public sealed partial class WarpBulbSystem : EntitySystem
{
    [Dependency] private SharedTransformSystem _transform = default!;
    
    [Dependency] private IEntityManager _entMan = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<WarpBulbComponent, JumpToBulbEvent>(OnWarp);
    }

    private void OnWarp(EntityUid uid, WarpBulbComponent component, JumpToBulbEvent args)
    {
        _transform.SetCoordinates(uid, Transform(component.LinkedEntity).Coordinates);
    }
}