# ProRoad Mesh Tools

ProRoadのワークフローに追加のメッシュ処理を提供するUnityエディターツールです。

## 要件

- Unity 6以降
- 既に正規ライセンスを所有し、別途インポートされた[ProRoad](https://assetstore.unity.com/packages/tools/terrain/proroad-119351)

このパッケージにはProRoadおよびObjectPlanterは含まれていません。

ProRoadは現在Unity Asset Storeから新規購入できません。上記リンクは製品情報の参照用です。このパッケージは、既に有効なProRoadライセンスを所有しているユーザーを対象としています。

## インストール

先に所有済みの正規ライセンス版ProRoadをUnityプロジェクトへインポートし、Unity Package Managerから次のGit URLを指定して、このリポジトリを追加してください。

```text
https://github.com/nae3na/ProRoadMeshTools.git
```

## 使用方法

Unityエディターの`Tools > ProRoad Mesh Tools`からウィンドウを開きます。この項目はProRoadの**ObjectPlanter**サブメニューの直下に表示されます。

ウィンドウでは次の処理を実行できます。

- ProRoadが生成したメッシュへの`MeshCollider`追加と、任意のPhysics Material割り当て
- 単体のProRoad、または指定した親以下にあるすべてのProRoadが生成したメッシュの法線再計算
- ObjectPlanterLineが生成した結合オブジェクトの有効化と`MeshCollider`追加

ProRoadで道路を再生成した場合は、法線再計算をもう一度実行してください。

ProRoadの`Do Not Modify Terrain`が無効な状態で道路を生成すると、Terrainが変形される場合があります。ProRoad Mesh Tools自身は道路生成やTerrain変更を行わず、本ツールのUndoでTerrain変形を元に戻すことは想定していません。

## 互換性

このパッケージはUnity 6以降を対象とし、`PhysicsMaterial`を使用します。

## ライセンス

ProRoad Mesh ToolsはMIT Licenseで提供されます。詳細は[LICENSE.md](LICENSE.md)を参照してください。

このパッケージは非公式のアドオンであり、ProRoadの販売元との提携や承認を受けたものではありません。
