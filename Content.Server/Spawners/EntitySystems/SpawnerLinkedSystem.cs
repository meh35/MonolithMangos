using System.ComponentModel;
using Content.Server.Spawners.Components;
using Robust.Shared.Prototypes;
using Robust.Shared.Spawners;
using Content.Server._Mono.Scourge;

namespace Content.Server.Spawners.SpawnerLinkedSystem;

// BABYS FIRST C#! <3
public sealed partial class SpawnerLinkedSystem : EntitySystem
{
    [Dependency] private IEntityManager _entity = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SpawnerLinkedComponent, ComponentShutdown>(OnDespawn);
        SubscribeLocalEvent<SpawnerLinkedComponent, MapInitEvent>(OnInit);
    }

    private void OnInit(EntityUid uid, SpawnerLinkedComponent component, ref MapInitEvent args)
    {
        var coordinates = Transform(uid).Coordinates;
        var entity = component.Prototype;

        component.LinkedEntity = _entity.SpawnAtPosition(entity, coordinates);
        
        if (_entity.TryGetComponent<WarpBulbComponent>(component.LinkedEntity, out var LinkedEntity))
        {
            LinkedEntity = uid;
        }
    }

    private void OnDespawn(EntityUid uid, SpawnerLinkedComponent component, ref ComponentShutdown args)
    {
        QueueDel(component.LinkedEntity);
    }
}