# Usage

Open **Tools > ProRoad Mesh Tools**. The item appears directly below ProRoad's **ObjectPlanter** submenu.

ProRoad Mesh Tools does not invoke ProRoad road generation and does not modify Terrain. Generate or regenerate roads through ProRoad itself. If ProRoad generation is allowed to deform Terrain, do not rely on this package's Undo operations to restore that Terrain; use a disposable project or a separate backup of the affected Terrain data.

## ProRoad mesh colliders

Assign a parent object to process each direct child with a ProRoad component, or assign one ProRoad component. Optionally assign a physics material, then select the corresponding **Add Mesh Colliders** button.

The setup operation adds a `MeshCollider` to each generated object under the ProRoad `Meshes` child. When a physics material is assigned, its shared reference is applied to each collider. All changes from one setup operation are grouped into one Undo step.

## Mesh normal recalculation

Use the individual or batch normal recalculation button after ProRoad generates or regenerates road meshes.

The operation:

- Processes `MeshFilter.sharedMesh` references under each ProRoad `Meshes` child.
- Processes each shared mesh only once.
- Skips unreadable meshes and reports a warning.
- Registers Undo, marks modified meshes dirty, and saves asset changes.

## ObjectPlanterLine combined mesh colliders

Assign a parent object to process each direct child with an ObjectPlanterLine component, or assign one ObjectPlanterLine component.

For lines with combined meshes enabled, select the corresponding **Activate Combined Mesh and Add Collider** button. The operation keeps the generated `<line name>_0_0` object active, disables its sibling generated objects, and adds a `MeshCollider` to the combined object. All changes from one operation are grouped into one Undo step.
