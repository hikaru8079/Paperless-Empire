# Paperless Empire

## 開発規則
* masterブランチでは作業しないでください。
* 出来る限り誰が見ても分かるよう、「何をしているか」のブロック単位だけでもコメントアウトしてコードの内容を示して下さい。
* 自身の名前のブランチで作業を行ってください。
* 今回の開発では機能ごと、バージョンごとにブランチ分割は行いません。
* コミット時は必ずディスクリプションを付けてください。内容は前回コミットからの変更内容でお願いします。
* 変数の記法ですが、明確に指定はしませんがアッパーキャメルケース(パスカルケース)(KonnaKanjideSengen)かキャメルケース(konnaKanjidesengen)で宣言してもらえれば助かります。

---

## 便利なコマンドとか
* `dotnet watch`
変更内容をリアルタイムで反映しながらサイトの動きを確認できます。

* コードブロック
~~~html
<pre>
    <code>ここにソースコード</code>
</pre>
~~~
コードブロックをいい感じで作れます(プラグインが入ってます)。言語は自動で識別してくれるハズ。
多分使わんけど。

* 入れとくと便利かもしてないVSCodeのプラグイン
    - indent-rainbow
    - Japanese Language Pack for Visual Studio Code
    - Path Autocomplete
    - HTML CSS Support
    - JavaScript (ES6) code snippets
    - Auto Rename Tag
    - Auto Close Tag
    - zenkaku
バチクソにVSCode使いまくると思うんで楽に開発できるプラグイン挙げときます。
左上らへんに何個かアイコンがならんでるやつの□があるやつ(拡張機能)ってとこクリックして名前で検索かければ入れれます。