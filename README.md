# Roll-a-Ball-Custom-1stDev-2018
## 概要
このUnityプロジェクトは、Unity社が提供する「はじめてのUnity」をベースに、Unityに初めて触れる人が、ゲームを創ることがどういうものかを出来るだけ単純に体験するとを目的に制作したもので、Unity経験者が初心者にペアで利用することを想定ます。

- できるだけシンプルにするために、他のAssetはStanderdAssetsのMobileInputのみにしています
- ScriptのNameSpaceは、誰でも初期状態で利用できる、Unity社およびマイクロソフト社謹製のC#標準的なのもののみを利用しています
- プレイして体験した人が、これをInspactorでカスタマイズする、Prefabを配置して改造するまでを想定しています
- 「はじめてのUnity」がベースなので、スクラッチで作りたい人はそちらを先ず作ると、全体的な仕組みが理解できます
- 基本が理解できた人は、Scriptを開き、適宜、自分の作りたい動きをScriptのAssetにすることまでが比較的、やりやすいようにしています
- 初心者が誰かに付いて解説されながら利用するシーンを想定します、全くの初心者の方は別途、チュートリアル(準備中)を参考に進めてください。

## 使い方
Downloadでの、基本的な利用方法を説明します。
### プレイするまでの手順
1. DownloadしたZipを適宜、解凍してください
1. Unity(2017.4以降を推奨)を起動し、ProjectとしてDownloadしたフォルダを指定してください
1. Assets/Roll-a-Ball-Base/内のStage01.sceneを開いてください
1. エディタのプレイボタンでプレイできます
 1. キー操作はWASDかカーソルキー、ゲームパッドのアナログスティックで移動、スペースキーかゲームパッドのAボタンでジャンプします
 1. 画面上の緑色のカプセルを全部取るとクリアです、早くとると☆☆☆、遅いと☆が出ます
### はじめて触る初心者向け
ワークショップなどで初めていじる人を考えたものです。
当方で利用したスライドを公開しています、初心者はこれを見つつ以下を参考にするのが簡単です。各自で用意されてもいいと思います。
https://www.slideshare.net/junshimura/rakugaku2017-unity1st-dev
#### 簡単な配置のカスタマイズ
1. 上記のStage01を選択した状態で、[Edit]>[Dupulicate]を選んで複製します、するとStage02.sceneが出来上がります
1. 適宜、不要なオブジェクトを、エディタのSceneで削除してください。このとき、削除すると困るものを非アクティブで隠しているので、Hierarchyは触らないほうが無難です。初心者は教えない限り、あまり、触らないと思います。
1. 作ったらプレイしてみてください。
2. カプセルや触ると危険な壁などは、Prefabで用意しています。エディタのAssets/Roll-a-Ball-Base/Prefabを開いてください。必要に応じてドラッグして、追加してください。
#### Inspectorを操作したカスタマイズ
オブジェクトに応じて、いじれるパラメータが用意されています。適宜、変えて、動かし、失敗したらUnDoすることで、改造して遊べます。
- Transform 
- アタッチされたComponentで日本語で出るパラメータ
- 動く物体の速さ
- Playerのジャンプ力
- クリア後に出る文字列（☆など）と、出す基準タイム（現在は最速5秒以内で最大の誉め言葉）
### はじめてのUnityを経た人の利用方法
#### Script内のカスタマイズ
往復運動や回転などの動作は、単純なプログラミングで実現しています。適宜、開いて、変えられます。以下のようなバリエーションを考えてみるのも良いでしょう。基本的なプログラミングの学習ができます。
- 初級
  - 大きさが変わる
  - ランダムに動く
  - 正方形の軌跡を描く
  - 円運動を描く
- 中級
  - 加速、減速する
  - 複数動作の組み合わせ
- 上級
  - 色を変える
  - Palyerに向かって追いかけてくる
  - レベルの追加

### Unity経験者の利用方法
元は単純にできているので、更に特化した教材などにお役立てください。特に、以下について改造すると、Unity DeveloperのCertificationを学習するのにも役立つと思います。
- NavMeshの導入
- 効果音の追加
- Animationの追加
- Playerを別Assetにする
- パーティクルの実装
- Mobile向けの書き出し

## 注意事項
- Unityのバージョンは2017.4で確認していますが、機能的には5.6で開発したものがベースです
- 音とFontのみ外部製作の商用でライセンスに問題がないものを利用しています、そのままのデータによる商用利用（データの販売）などはライセンスに抵触するので、予めご注意ください

## 参考
https://unity3d.com/jp/learn/tutorials/projects/hajiuni-jp
