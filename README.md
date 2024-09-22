# MonitorShot
## これは何?
Windowsで、画面のスクリーンショットを取得するプログラムです。
単にスクショを撮るだけなら、Windowsキー+Print Screenでもよいですが、 
マルチモニタの場合、設定により、特定のひとつのモニタだけをスクショします。

スクショ取得の時刻を画像内に埋め込む機能、スクショ取得時点のカーソル位置を半透明の○で画像内に埋め込む機能もあります。

IT屋さんが、テストや作業のエビデンスを取得するのに便利なように作ったつもりです。

Visual Studio 2019 + .NET Framework4.7.2で作っています。

## 設定
App.config(MonitorShot.exe.config)で、以下の設定を行います。
```
  <appSettings>
    <add key="targetScreen" value="1" />
    <add key="captureKey" value="Insert"/>
    <add key="defaultFolder" value="C:\maebashi\develop\MonitorShot\save"/>
  </appSettings>
```
- targetScreen...対象とするモニタの番号です。1から始まる番号で、デスクトップ→「ディスプレイ設定」の設定画面で示される番号に相当します。
- captureKey...キャプチャに使うキーです。.NET FrameworkのSystem.Windows.Forms.Keys列挙型の名称を指定します。
- defaultFolder...画像の保存フォルダです。実際には、MonitorShotは、このフォルダの下に、
  起動ごとにyyyyMMddHHmmss形式の名前のフォルダを作り、実際の画像はその下に保存します。
  画像のファイル名は、<4桁0埋め連番>_<yyyyMMddHHmmss>.pngです(画像形式はPNG固定)。
  

## ライセンスについて
NYSL Version 0.9982とします。作者は一切の著作権を主張しませんので、改変するなり煮るなり焼くなり好きにしてください。
http://www.kmonos.net/nysl/
