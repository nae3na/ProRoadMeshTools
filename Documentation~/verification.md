# Manual verification

Use a private Unity 6 project containing a licensed copy of ProRoad to verify integration behavior. Do not copy ProRoad, ObjectPlanter, generated assets, or other licensed content into this repository.

Record the Unity Editor version, ProRoad version when identifiable, ProRoad Mesh Tools revision, completed checks, skipped checks, and observed errors for each verification run.

## Package loading

- Install ProRoad Mesh Tools as a local or Git package after importing ProRoad.
- Confirm that the project compiles without errors.
- Confirm that **Tools > ProRoad Mesh Tools** appears directly below the **ObjectPlanter** submenu and opens the editor window.
- Confirm that the Console contains no unexpected errors or warnings from this package.

## ProRoad mesh colliders

- Add mesh colliders for one ProRoad component.
- Add mesh colliders for multiple direct-child ProRoad components under a parent.
- Confirm that each generated mesh object receives one `MeshCollider` and repeated setup does not add duplicates.
- Confirm that the selected `PhysicsMaterial` is assigned through `MeshCollider.sharedMaterial`.
- Confirm that setup changes on prefab instances are recorded as expected overrides.
- Confirm that one Undo operation reverts the complete setup operation and Redo reapplies it.

## Mesh normal recalculation

- Recalculate normals for one ProRoad component.
- Recalculate normals for multiple direct-child ProRoad components under a parent.
- Confirm visually that the generated road shading is corrected.
- Confirm that a mesh shared by multiple `MeshFilter` components is processed only once.
- Confirm that unreadable meshes are skipped with a warning and do not stop the remaining operation.
- Save and reopen the project, then confirm that the recalculated normals remain applied.
- When explicitly validating behavior after ProRoad regeneration, use a disposable project and either enable ProRoad's `Do Not Modify Terrain` option or separately back up the affected Terrain data. Do not use Undo as a rollback for Terrain deformation.
- After that safe regeneration, rerun normal recalculation and confirm that the regenerated mesh is processed.
- Confirm that one Undo operation reverts the complete recalculation operation and Redo reapplies it.

## ObjectPlanterLine combined mesh colliders

- Activate the combined mesh and add its collider for one ObjectPlanterLine with combined meshes enabled.
- Activate combined meshes and add their colliders for multiple direct-child ObjectPlanterLine components under a parent.
- Confirm that the generated `<line name>_0_0` object remains active and its generated siblings become inactive.
- Confirm that the combined object receives one `MeshCollider` and repeated setup does not add duplicates.
- Confirm that setup changes on prefab instances are recorded as expected overrides.
- Confirm that one Undo operation reverts the complete setup operation and Redo reapplies it.

## Repository boundary

- Review repository changes after verification.
- Confirm that no ProRoad or ObjectPlanter binaries, source, documentation, samples, generated meshes, scenes, prefabs, or other licensed content were added.

## Latest verification record

Date: 2026-09-27

- Unity Editor: 6000.0.81f1
- ProRoad: version not identifiable from the imported files
- ProRoad Mesh Tools: 1.0.0 initial working tree
- Package installation: passed using a local UPM reference
- Compilation: passed with no errors from this package
- Editor menu placement and window: passed; **ProRoad Mesh Tools** priority 143 follows the **ObjectPlanter** submenu, whose final item uses priority 142, and opens the window
- ProRoad individual and two-road batch setup: passed
- `PhysicsMaterial` shared-reference assignment: passed
- Collider duplicate prevention: passed
- Collider processing Undo and Redo: passed for individual and batch operations
- Normal recalculation and shared-mesh deduplication: passed
- Unreadable mesh warning and skip, including duplicate shared references: passed
- Two-mesh normal Undo and Redo: passed
- Recalculated-normal persistence after forced asset reimport: passed
- Scene View before-and-after comparison: recalculated shading changed as expected
- ObjectPlanterLine individual and two-line batch setup: passed using a temporary combined-output hierarchy
- ObjectPlanterLine duplicate prevention, sibling activation, Undo, and Redo: passed
- Console: no errors; one expected unreadable-mesh warning and one ProRoad obsolete-API warning
- Cleanup: passed; the scene, generated road mesh, and ObjectPlanterLine objects were restored to their original state

The following checks were not completed:

- Prefab-instance override recording, because the supplied scene objects were not prefab instances.
- Regenerating the road with ProRoad and rerunning the tool. This was deliberately skipped because the supplied road could deform Terrain and that change must not be treated as Undo-safe.
- Testing against an ObjectPlanterLine output generated with `combineMeshes` enabled; the supplied line used individual objects, so a temporary equivalent hierarchy was used.
- Closing and restarting the Unity Editor after saving recalculated normals. Persistence was instead verified by saving and force-reimporting a temporary mesh asset.
