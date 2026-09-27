using CP.ObjectPlanter;
using CP.ProRoad;
using UnityEditor;
using UnityEngine;

namespace ProRoadMeshTools {

	/// <summary>
	/// ProRoadとObjectPlanterLineに追加のメッシュ処理ツールを提供します。
	/// Provides additional mesh processing tools for ProRoad and ObjectPlanterLine.
	/// </summary>
	internal class ProRoadMeshToolsWindow : EditorWindow {

		private GameObject m_RoadParent = null;
		private ProRoad m_Road = null;
		private PhysicsMaterial m_PhysicsMaterial = null;
		private GameObject m_PlanterLineParent = null;
		private ObjectPlanterLine m_PlanterLine = null;
		private Vector2 m_ScrollPosition = new Vector2( 0f, 0f );

		/// <summary>
		/// ProRoad Mesh Toolsウィンドウを開きます。
		/// Opens the ProRoad Mesh Tools window.
		/// </summary>
		[MenuItem( "Tools/ProRoad Mesh Tools", false, 143 )]
		private static void OpenWindow( ) {
			ProRoadMeshToolsWindow window = GetWindow<ProRoadMeshToolsWindow>( "ProRoad Mesh Tools" );
			window.Show( );
		}

		/// <summary>
		/// エディターウィンドウのユーザーインターフェースを描画します。
		/// Draws the editor window user interface.
		/// </summary>
		private void OnGUI( ) {
			m_ScrollPosition = EditorGUILayout.BeginScrollView( m_ScrollPosition );
			{
				GUILayout.Label( "ProRoad Mesh Tools", EditorStyles.boldLabel );
				EditorGUILayout.Space( 5f );

				DrawProRoadSection( );
				EditorGUILayout.Space( 5f );
				DrawObjectPlanterLineSection( );
			}
			EditorGUILayout.EndScrollView( );
		}

		/// <summary>
		/// ProRoadメッシュ処理用のコントロールを描画します。
		/// Draws the controls for processing ProRoad meshes.
		/// </summary>
		private void DrawProRoadSection( ) {
			GUILayout.Label( "ProRoad", EditorStyles.boldLabel );
			EditorGUILayout.BeginVertical( GUI.skin.box );
			{
				m_RoadParent = EditorGUILayout.ObjectField( "Parent Object", m_RoadParent, typeof( GameObject ), true ) as GameObject;
				EditorGUI.BeginDisabledGroup( m_RoadParent == null );
				{
					if ( GUILayout.Button( "Add Mesh Colliders to Roads" ) ) {
						ProRoadMeshColliderUtility.AddMeshCollidersToRoads( m_RoadParent, m_PhysicsMaterial );
					}
					if ( GUILayout.Button( "Recalculate All Mesh Normals" ) ) {
						ProRoadMeshNormalUtility.RecalculateRoadMeshNormals( m_RoadParent.GetComponentsInChildren<ProRoad>( true ) );
					}
				}
				EditorGUI.EndDisabledGroup( );

				EditorGUILayout.Space( 5f );

				m_Road = EditorGUILayout.ObjectField( "ProRoad", m_Road, typeof( ProRoad ), true ) as ProRoad;
				EditorGUI.BeginDisabledGroup( m_Road == null );
				{
					if ( GUILayout.Button( "Add Mesh Colliders to Road" ) ) {
						ProRoadMeshColliderUtility.AddMeshCollidersToRoad( m_Road, m_PhysicsMaterial );
					}
					if ( GUILayout.Button( "Recalculate Mesh Normals" ) ) {
						ProRoadMeshNormalUtility.RecalculateRoadMeshNormals( new ProRoad[ ] { m_Road } );
					}
				}
				EditorGUI.EndDisabledGroup( );

				m_PhysicsMaterial = EditorGUILayout.ObjectField( "Physics Material", m_PhysicsMaterial, typeof( PhysicsMaterial ), false ) as PhysicsMaterial;

				EditorGUILayout.HelpBox( "If no physics material is assigned, the collider is created without changing its material.", MessageType.Info );
				EditorGUILayout.HelpBox( "Recalculate mesh normals after regenerating a road with ProRoad.", MessageType.Info );
			}
			EditorGUILayout.EndVertical( );
		}

		/// <summary>
		/// ObjectPlanterLineの結合メッシュ処理用コントロールを描画します。
		/// Draws the controls for processing ObjectPlanterLine combined meshes.
		/// </summary>
		private void DrawObjectPlanterLineSection( ) {
			GUILayout.Label( "ObjectPlanterLine", EditorStyles.boldLabel );
			EditorGUILayout.BeginVertical( GUI.skin.box );
			{
				m_PlanterLineParent = EditorGUILayout.ObjectField( "Parent Object", m_PlanterLineParent, typeof( GameObject ), true ) as GameObject;
				EditorGUI.BeginDisabledGroup( m_PlanterLineParent == null );
				{
					if ( GUILayout.Button( "Activate Combined Meshes and Add Colliders" ) ) {
						ObjectPlanterLineUtility.ActivateCombinedMeshesAndAddColliders( m_PlanterLineParent );
					}
				}
				EditorGUI.EndDisabledGroup( );

				EditorGUILayout.Space( 5f );

				m_PlanterLine = EditorGUILayout.ObjectField( "ObjectPlanterLine", m_PlanterLine, typeof( ObjectPlanterLine ), true ) as ObjectPlanterLine;
				EditorGUI.BeginDisabledGroup( m_PlanterLine == null );
				{
					if ( GUILayout.Button( "Activate Combined Mesh and Add Collider" ) ) {
						ObjectPlanterLineUtility.ActivateCombinedMeshAndAddCollider( m_PlanterLine );
					}
				}
				EditorGUI.EndDisabledGroup( );
			}
			EditorGUILayout.EndVertical( );
		}
	}
}
